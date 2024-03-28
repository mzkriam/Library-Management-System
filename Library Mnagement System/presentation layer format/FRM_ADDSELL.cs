using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class FRM_ADDSELL : Form
    {
        FRM_MAIN main = new FRM_MAIN();
        Business_layer_class.cls_BOOKS class_books = new Business_layer_class.cls_BOOKS();
        Business_layer_class.cls_customers class_customers = new Business_layer_class.cls_customers();
        Business_layer_class.cls_seels class_sell = new Business_layer_class.cls_seels();
        Business_layer_class.cls_boro class_p = new Business_layer_class.cls_boro();
        public int id;
        public string state;
        public string isbn;
        public string number_card;
        public FRM_ADDSELL()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pn_message.Visible = false;
        }      
        private void txt_se_books_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = class_books.search_for_seels(txt_se_books.Text);
                datagrid_books.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txt_se_stu_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = class_customers.search_for_seels(txt_se_stu.Text);
                datagrid_boro.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_add_boro_Click(object sender, EventArgs e)
        {
            if (txt_prise_.Text == "" || txt_isbn_book.Text == "" || txt_name_customer.Text == "")
            {
                lb_message.Text = "الرجاءادخال معلومات الكتاب ومعلومات المستعير";
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                if (id == 0)
                {
                    try
                    {
                        string isbn1 = txt_isbn_book.Text;
                        DataTable dt = new DataTable();
                        dt = class_p.select_num(isbn1);
                        object o = dt.Rows[0]["num_book_avilable"];
                        object idbook = dt.Rows[0]["Id"];
                        int id_book = Convert.ToInt32(idbook);
                        int num_book = Convert.ToInt32(o);
                        if (num_book == 0)
                        {
                            MessageBox.Show(" عذرا هذا الكتاب غير متوفر حاليا ربما في وقت لاحق", "الكتاب غير متوفر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataTable idcus = new DataTable();
                            idcus = class_p.select_card(txt_number_card_customer.Text);
                            object idcust = idcus.Rows[0]["Id"];
                            int id_customers = Convert.ToInt32(idcust);
                            int new_num = num_book - 1;
                            class_p.update_number_book(new_num, isbn1);
                            class_sell.insert(Convert.ToString(datagrid_boro.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_boro.CurrentRow.Cells[1].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[1].Value), Convert.ToString(date_sell.Value), Convert.ToInt32(txt_prise_.Text), id_book, id_customers);
                            lb_message.Text = "تم اضافة عملية بيع جديدة بنجاح";
                            pic_dell.Visible = true;
                            pn_message.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //edite_poro
                else
                {
                    try
                    {
                        DataTable new_num_book_avilable = new DataTable();
                        new_num_book_avilable = class_p.select_num(txt_isbn_book.Text);
                        object new_num_avilable_dt = new_num_book_avilable.Rows[0]["num_book_avilable"];
                        object id_booke_dt = new_num_book_avilable.Rows[0]["Id"];
                        int id_book = Convert.ToInt32(id_booke_dt);
                        int new_num_book_avilable_n = Convert.ToInt32(new_num_avilable_dt);
                        if (new_num_book_avilable_n == 0)
                        {
                            MessageBox.Show(" عذرا هذا الكتاب غير متوفر حاليا ربما في وقت لاحق", "الكتاب غير متوفر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataTable old_num_book_avlibale_dt = new DataTable();
                            old_num_book_avlibale_dt = class_p.select_num(isbn);
                            object obj_old_num_book_avlibale = old_num_book_avlibale_dt.Rows[0]["num_book_avilable"];
                            int old_num_book_avlibale = Convert.ToInt32(obj_old_num_book_avlibale);
                            int new_num_book_avlibale_old = old_num_book_avlibale + 1;
                            int new_num_book_avlibale_new = new_num_book_avilable_n - 1;
                            class_p.update_number_book(new_num_book_avlibale_old, isbn);
                            class_p.update_number_book(new_num_book_avlibale_new, txt_isbn_book.Text);
                            DataTable idcus = new DataTable();
                            idcus = class_p.select_card(txt_number_card_customer.Text);
                            object idcust = idcus.Rows[0]["Id"];
                            int id_customers = Convert.ToInt32(idcust);
                            class_sell.update(Convert.ToString(datagrid_boro.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_boro.CurrentRow.Cells[1].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[1].Value), Convert.ToString(date_sell.Value), Convert.ToInt32(txt_prise_.Text), id, id_book, id_customers);
                            lb_message.Text = "تم  تعديل عملية البيع بنجاح";
                            pic_dell.Visible = true;
                            pn_message.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void datagrid_books_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txt_isbn_book.Text = datagrid_books.SelectedRows[0].Cells[1].Value.ToString();
                txt_name_book.Text = datagrid_books.SelectedRows[0].Cells[0].Value.ToString();
                txt_prise_.Text = datagrid_books.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void datagrid_boro_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                txt_name_customer.Text = datagrid_boro.SelectedRows[0].Cells[0].Value.ToString();
                txt_number_card_customer.Text = datagrid_boro.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
    