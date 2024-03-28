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
    public partial class FRM_ADDBORO : Form
    {
        FRM_MAIN main = new FRM_MAIN();
        Business_layer_class.cls_BOOKS class_books = new Business_layer_class.cls_BOOKS();
        Business_layer_class.cls_customers class_customers = new Business_layer_class.cls_customers();
        Business_layer_class.cls_boro class_boro = new Business_layer_class.cls_boro();
        public int id;
        public string state;
        public string isbn;
        public string number_card;
        public FRM_ADDBORO()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pn_message.Visible = false;
        }
        private void number_only(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case ',':
                case (char)Keys.Back:
                    e.Handled = false;
                    break;
                default:
                    lb_message.Text = "الرجاء استخدام ارقام فقط";
                    pic_errore.Visible = true;
                    pn_message.Visible = true;
                    e.Handled = true;
                    break;
            }
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
                        DataTable dt = new DataTable();
                        dt = class_boro.select_num(txt_isbn_book.Text);
                        object id_book = dt.Rows[0]["Id"];
                        int id_books = Convert.ToInt32(id_book);
                        object o = dt.Rows[0]["num_book_avilable"];
                        int num_book = Convert.ToInt32(o);
                        if (num_book == 0)
                        {
                            MessageBox.Show(" عذرا هذا الكتاب غير متوفر حاليا ربما في وقت لاحق", "الكتاب غير متوفر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataTable same_book = new DataTable();
                            same_book = class_boro.select_same_poro(txt_isbn_book.Text, txt_number_card_customer.Text, "غير مستعاد");
                            if (same_book.Rows.Count > 0)
                            {
                                MessageBox.Show(" لا يمكن القيام بعملية الاستعارة العميل لديه نفس الكتاب مستعار مسبقاً  ", "استعارة جديدة للعميل نفسه", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                            }
                            else
                            {
                                string card = txt_number_card_customer.Text;
                                DataTable dt1 = new DataTable();
                                dt1 = class_boro.select_card(card);
                                object id_cus = dt1.Rows[0]["Id"];
                                int id_customers = Convert.ToInt32(id_cus);
                                object o1 = dt1.Rows[0]["num_book_pro"];
                                int num_poro = Convert.ToInt32(o1);
                                int new_num_poro = num_poro + 1;
                                if (num_poro > 0 && num_poro < 3) 
                                {
                                    if (MessageBox.Show(" العميل لديه " + num_poro + " كتاب مستعار مسبقاً هل تريد اتمام عملية الاستعارة ", "استعارة جديدة للعميل نفسه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        class_boro.update_number_poro(new_num_poro, card);
                                        int new_num = num_book - 1;
                                        class_boro.update_number_book(new_num, txt_isbn_book.Text);
                                        class_boro.insert_data(Convert.ToString(datagrid_boro.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_boro.CurrentRow.Cells[1].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[1].Value), Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), "غير مستعاد", id_books, id_customers);
                                        lb_message.Text = "تم اضافة عملية استعارة جديدة بنجاح";
                                        pic_dell.Visible = true;
                                        pn_message.Visible = true;
                                    }
                                }
                               else if (num_poro == 3)
                                {
                                    MessageBox.Show("لا يمكن اليام بعملية استعارة العميل لديه ثلاث كتب مستعارة", "استعارة متكررة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    class_boro.update_number_poro(new_num_poro, card);
                                    int new_num = num_book - 1;
                                    class_boro.update_number_book(new_num, txt_isbn_book.Text);
                                    class_boro.insert_data(Convert.ToString(datagrid_boro.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_boro.CurrentRow.Cells[1].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[0].Value), Convert.ToString(datagrid_books.CurrentRow.Cells[1].Value), Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), "غير مستعاد",id_books,id_customers);
                                    lb_message.Text = "تم اضافة عملية استعارة جديدة بنجاح";
                                    pic_dell.Visible = true;
                                    pn_message.Visible = true;
                                }
                            }
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

                        if (txt_number_card_customer.Text == number_card && isbn == txt_isbn_book.Text)
                        {
                            DataTable old_num_book_poro_dt = new DataTable();
                            old_num_book_poro_dt = class_boro.select_card(number_card);
                            object obj_old_num_book_poro_dt = old_num_book_poro_dt.Rows[0]["num_book_pro"];
                            object id_cus = old_num_book_poro_dt.Rows[0]["Id"];
                            int Id_customers = Convert.ToInt32(id_cus);
                            DataTable new_num_book_avilable = new DataTable();
                            new_num_book_avilable = class_boro.select_num(txt_isbn_book.Text);
                            object new_num_avilable_dt = new_num_book_avilable.Rows[0]["num_book_avilable"];
                            object Id_book = new_num_book_avilable.Rows[0]["Id"];
                            int id_books = Convert.ToInt32(Id_book);
                            class_boro.update(id, txt_name_customer.Text, txt_number_card_customer.Text, txt_name_book.Text, txt_isbn_book.Text, Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), id_books, Id_customers);
                            lb_message.Text = "تم تعديل عملية الاستعارة بنجاح";
                            pic_update.Visible = true;
                            pn_message.Visible = true;
                        }
                        else
                        {

                            DataTable new_num_book_avilable = new DataTable();
                            new_num_book_avilable = class_boro.select_num(txt_isbn_book.Text);
                            object new_num_avilable_dt = new_num_book_avilable.Rows[0]["num_book_avilable"];
                            object Id_book = new_num_book_avilable.Rows[0]["Id"];
                            int id_books = Convert.ToInt32(Id_book);
                            int new_num_book_avilable_n = Convert.ToInt32(new_num_avilable_dt);
                            if (new_num_book_avilable_n == 0)
                            {
                                MessageBox.Show(" عذرا هذا الكتاب غير متوفر حاليا ربما في وقت لاحق", "الكتاب غير متوفر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DataTable old_num_book_poro_dt = new DataTable();
                                old_num_book_poro_dt = class_boro.select_card(number_card);
                                object obj_old_num_book_poro_dt = old_num_book_poro_dt.Rows[0]["num_book_pro"];
                                object id_cus = old_num_book_poro_dt.Rows[0]["Id"];
                                int Id_customers = Convert.ToInt32(id_cus);
                                int old_num_book_poro = Convert.ToInt32(obj_old_num_book_poro_dt);
                                DataTable same_book = new DataTable();
                                same_book = class_boro.select_same_poro(txt_isbn_book.Text, txt_number_card_customer.Text, "غير مستعاد");
                                if (same_book.Rows.Count > 0)
                                {
                                    MessageBox.Show("  العميل لديه نفس الكتاب مستعار مسبقاً  ", "استعارة جديدة للعميل نفسه", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                    class_boro.update(id, txt_name_customer.Text, txt_number_card_customer.Text, txt_name_book.Text, txt_isbn_book.Text, Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), id_books, Id_customers);
                                }
                                else
                                {
                                    if (old_num_book_poro > 0 && old_num_book_poro < 3)
                                    {
                                        if (MessageBox.Show(" العميل لديه " + old_num_book_poro + " كتاب مستعار مسبقاً هل تريد اتمام عملية الاستعارة ", "استعارة جديدة للعميل نفسه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            if (txt_isbn_book.Text == isbn)
                                            {
                                                DataTable old_num_book_avlibale_dt = new DataTable();
                                                old_num_book_avlibale_dt = class_boro.select_num(isbn);
                                                object obj_old_num_book_avlibale = old_num_book_avlibale_dt.Rows[0]["num_book_avilable"];
                                                int old_num_book_avlibale = Convert.ToInt32(obj_old_num_book_avlibale);
                                                //int new_num_book_avlibale_old = old_num_book_avlibale + 1;
                                                int new_num_book_poro_old = old_num_book_poro - 1;
                                                class_boro.update_edite_poro(isbn, old_num_book_avlibale, number_card, new_num_book_poro_old);
                                                DataTable new_num_book_poro = new DataTable();
                                                new_num_book_poro = class_boro.select_card(txt_number_card_customer.Text);
                                                object new_num_book_poro_dt = new_num_book_poro.Rows[0]["num_book_pro"];
                                                object id_cusn = new_num_book_poro.Rows[0]["Id"];
                                                int Id_customer = Convert.ToInt32(id_cusn);
                                                int new_num_book_poro_n = Convert.ToInt32(new_num_book_poro_dt);
                                                //int new_num_book_avlibale_new = new_num_book_avilable_n - 1;
                                                int new_num_book_poro_new = new_num_book_poro_n + 1;
                                                class_boro.update_edite_poro(txt_isbn_book.Text, old_num_book_avlibale, txt_number_card_customer.Text, new_num_book_poro_new);
                                                class_boro.update(id, txt_name_customer.Text, txt_number_card_customer.Text, txt_name_book.Text, txt_isbn_book.Text, Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), id_books, Id_customer);
                                                lb_message.Text = "تم تعديل عملية الاستعارة بنجاح";
                                                pic_update.Visible = true;
                                                pn_message.Visible = true;
                                            }
                                            else
                                            {
                                                DataTable old_num_book_avlibale_dt = new DataTable();
                                                old_num_book_avlibale_dt = class_boro.select_num(isbn);
                                                object obj_old_num_book_avlibale = old_num_book_avlibale_dt.Rows[0]["num_book_avilable"];
                                                int old_num_book_avlibale = Convert.ToInt32(obj_old_num_book_avlibale);
                                                int new_num_book_avlibale_old = old_num_book_avlibale + 1;
                                                int new_num_book_poro_old = old_num_book_poro - 1;
                                                class_boro.update_edite_poro(isbn, new_num_book_avlibale_old, number_card, new_num_book_poro_old);
                                                DataTable new_num_book_poro = new DataTable();
                                                new_num_book_poro = class_boro.select_card(txt_number_card_customer.Text);
                                                object new_num_book_poro_dt = new_num_book_poro.Rows[0]["num_book_pro"];
                                                object id_cu = new_num_book_poro.Rows[0]["Id"];
                                                int Id_custom = Convert.ToInt32(id_cu);
                                                int new_num_book_poro_n = Convert.ToInt32(new_num_book_poro_dt);
                                                int new_num_book_avlibale_new = new_num_book_avilable_n - 1;
                                                int new_num_book_poro_new = new_num_book_poro_n + 1;
                                                class_boro.update_edite_poro(txt_isbn_book.Text, new_num_book_avlibale_new, txt_number_card_customer.Text, new_num_book_poro_new);
                                                class_boro.update(id, txt_name_customer.Text, txt_number_card_customer.Text, txt_name_book.Text, txt_isbn_book.Text, Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), id_books, Id_custom);
                                                lb_message.Text = "تم تعديل عملية الاستعارة بنجاح";
                                                pic_update.Visible = true;
                                                pn_message.Visible = true;
                                            }
                                        }
                                    }
                                    else if (old_num_book_poro == 3)
                                    {
                                        MessageBox.Show("لا يمكن اليام بعملية استعارة لان العميل لديه ثلاث كتب مستعارة", "استعارة متكررة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    else
                                    {
                                        if (txt_isbn_book.Text == isbn)
                                        {
                                            DataTable old_num_book_avlibale_dt = new DataTable();
                                            old_num_book_avlibale_dt = class_boro.select_num(isbn);
                                            object obj_old_num_book_avlibale = old_num_book_avlibale_dt.Rows[0]["num_book_avilable"];
                                            int old_num_book_avlibale = Convert.ToInt32(obj_old_num_book_avlibale);
                                            //int new_num_book_avlibale_old = old_num_book_avlibale + 1;
                                            int new_num_book_poro_old = old_num_book_poro - 1;
                                            class_boro.update_edite_poro(isbn, old_num_book_avlibale, number_card, new_num_book_poro_old);
                                            DataTable new_num_book_poro = new DataTable();
                                            new_num_book_poro = class_boro.select_card(txt_number_card_customer.Text);
                                            object new_num_book_poro_dt = new_num_book_poro.Rows[0]["num_book_pro"];
                                            object id_cu = new_num_book_poro.Rows[0]["Id"];
                                            int Id_customersss = Convert.ToInt32(id_cu);
                                            int new_num_book_poro_n = Convert.ToInt32(new_num_book_poro_dt);
                                            //int new_num_book_avlibale_new = new_num_book_avilable_n - 1;
                                            int new_num_book_poro_new = new_num_book_poro_n + 1;
                                            class_boro.update_edite_poro(txt_isbn_book.Text, old_num_book_avlibale, txt_number_card_customer.Text, new_num_book_poro_new);
                                            class_boro.update(id, txt_name_customer.Text, txt_number_card_customer.Text, txt_name_book.Text, txt_isbn_book.Text, Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), id_books, Id_customersss);
                                            lb_message.Text = "تم تعديل عملية الاستعارة بنجاح";
                                            pic_update.Visible = true;
                                            pn_message.Visible = true;
                                        }
                                        else
                                        {
                                            DataTable old_num_book_avlibale_dt = new DataTable();
                                            old_num_book_avlibale_dt = class_boro.select_num(isbn);
                                            object obj_old_num_book_avlibale = old_num_book_avlibale_dt.Rows[0]["num_book_avilable"];
                                            int old_num_book_avlibale = Convert.ToInt32(obj_old_num_book_avlibale);
                                            int new_num_book_avlibale_old = old_num_book_avlibale + 1;
                                            int new_num_book_poro_old = old_num_book_poro - 1;
                                            class_boro.update_edite_poro(isbn, new_num_book_avlibale_old, number_card, new_num_book_poro_old);
                                            DataTable new_num_book_poro = new DataTable();
                                            new_num_book_poro = class_boro.select_card(txt_number_card_customer.Text);
                                            object new_num_book_poro_dt = new_num_book_poro.Rows[0]["num_book_pro"];
                                            object id_cu = new_num_book_poro.Rows[0]["Id"];
                                            int Id_customerss = Convert.ToInt32(id_cu);
                                            int new_num_book_poro_n = Convert.ToInt32(new_num_book_poro_dt);
                                            int new_num_book_avlibale_new = new_num_book_avilable_n - 1;
                                            int new_num_book_poro_new = new_num_book_poro_n + 1;
                                            class_boro.update_edite_poro(txt_isbn_book.Text, new_num_book_avlibale_new, txt_number_card_customer.Text, new_num_book_poro_new);
                                            class_boro.update(id, txt_name_customer.Text, txt_number_card_customer.Text, txt_name_book.Text, txt_isbn_book.Text, Convert.ToString(date_start.Value), Convert.ToString(date_finaly.Value), Convert.ToInt32(txt_prise_.Text), id_books, Id_customerss);
                                            lb_message.Text = "تم تعديل عملية الاستعارة بنجاح";
                                            pic_update.Visible = true;
                                            pn_message.Visible = true;
                                        }
                                    }
                                }
                            }
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
        private void txt_prise__KeyPress_1(object sender, KeyPressEventArgs e)
        {
            number_only(e);
        }
        private void date_finaly_onValueChanged(object sender, EventArgs e)
        {
            if (date_finaly.Value.Day < date_start.Value.Day)
            {
                btn_add_boro.Enabled = false;
                lb_message.Text = "يجب ان يكون تاريخ الاسترجاع اكبر من تاريخ الاستعارة";
                lb_message.Visible = true;
                pn_message.Visible = true;
            }
            else if (date_finaly.Value.Day - date_start.Value.Day > 14)
            {
                btn_add_boro.Enabled = false;
                lb_message.Text = "لا يمكن اعارة كتاب لمدة تتجاوز 14 يوم";
                lb_message.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                btn_add_boro.Enabled = true;
                pn_message.Visible = false;
            }
        }
        private void date_start_onValueChanged(object sender, EventArgs e)
        {
            if(date_finaly.Value.Day < date_start.Value.Day)
            {
                btn_add_boro.Enabled = false;
                lb_message.Text = "يجب ان يكون تاريخ الاسترجاع اكبر من تاريخ الاستعارة";
                lb_message.Visible = true;
                pn_message.Visible = true;
            }
            else if (date_finaly.Value.Day - date_start.Value.Day > 14)
            {
                btn_add_boro.Enabled = false;
                lb_message.Text = "لا يمكن اعارة كتاب لمدة تتجاوز 14 يوم";
                lb_message.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                pn_message.Visible = false;
                btn_add_boro.Enabled = true;
            }
        }
    }
}
    