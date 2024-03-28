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
    public partial class FRM_ADDBOOK : Form
    {
        Business_layer_class.cls_BOOKS class_book = new Business_layer_class.cls_BOOKS();

        public int id = 0;
        public FRM_ADDBOOK()
        {
            InitializeComponent();
        }     
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG & JPG & IMG & GIF Files|*.png;*.jpg;*.img*.gif";
                var res = ofd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    cover.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //add _cat

        private void btn_book_Click(object sender, EventArgs e)
        {
            if (txt_number_isbn.Text == "" || txt_name_book.Text == "" || txt_lang_book.Text == "" || txt_book_for.Text == "" || txt_def_book.Text == "" || txt_about_book.Text == "" || txt_price_book.Text == ""||comboBox1.Items == null)
            {
                lb_message.Text = "الرجاء ادخال معلومات الكتاب الاساسية";
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                if (id == 0)
                {
                    try
                    {
                        //insert
                        DataTable dt = new DataTable();
                        dt = class_book.check_isbn_book(txt_number_isbn.Text);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("عذراً!.....ان رقم موجود بالفعل", "ISBN مكرر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DataTable dt1 = new DataTable();
                            dt1 = class_book.select_id_cat(comboBox1.Text);
                            object o = dt1.Rows[0]["Id"];
                            int id_cat = Convert.ToInt32(o);
                            MemoryStream ms = new MemoryStream();
                            cover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            class_book.insert(txt_number_isbn.Text, txt_name_book.Text,
                                    txt_auther.Text, txt_price_book.Text, Convert.ToString(datee.Value), ratee.Value,
                                    ms, comboBox1.Text, txt_def_book.Text, txt_state_book.Text, txt_lang_book.Text,
                                    txt_Publisher.Text, txt_investigator.Text, Convert.ToInt32(num_book.Value),
                                    Convert.ToInt32(num_folders_in_book.Value), Convert.ToInt32(num_book_avilable.Value)
                                    , txt_position_book.Text, txt_about_book.Text, txt_book_for.Text, id_cat
                                    );
                            lb_message.Text = "تمت اضافة الكتاب بنجاح";
                            pic_dell.Visible = true;
                            pn_message.Visible = true;
                            txt_number_isbn.Text = "";
                            num_folders_in_book.Text = "1";
                            num_book_avilable.Text = "1";
                            num_book.Text = "1";
                            comboBox1.Text = "";
                            txt_position_book.Text = "";
                            datee.Text = "";
                            txt_investigator.Text = "";
                            txt_Publisher.Text = "";
                            txt_auther.Text = "";
                            ratee.Text = "";
                            txt_state_book.Text = "";
                            txt_about_book.Text = "";
                            txt_def_book.Text = "";
                            txt_book_for.Text = "";
                            txt_lang_book.Text = "";
                            txt_price_book.Text = "";
                            txt_name_book.Text = "";
                            cover.Image = null;
                        }
                    }
                    catch
                    {
                        lb_message.Text = "الرجاء اخيار صنف الكتاب";
                        pic_errore.Visible = true;
                        pn_message.Visible = true;
                    }
                }
                else
                {
                    //edite                   
                    DataTable dt1 = new DataTable();
                    dt1 = class_book.select_id_cat(comboBox1.Text);
                    object o = dt1.Rows[0]["Id"];
                    int id_cat = Convert.ToInt32(o);
                    MemoryStream ms = new MemoryStream();
                    cover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    class_book.updatebooks(id, txt_number_isbn.Text, txt_name_book.Text,
                            txt_auther.Text, txt_price_book.Text, Convert.ToString(datee.Value), ratee.Value,
                            ms, comboBox1.Text, txt_def_book.Text, txt_state_book.Text, txt_lang_book.Text,
                            txt_Publisher.Text, txt_investigator.Text, Convert.ToInt32(num_book.Value),
                            Convert.ToInt32(num_folders_in_book.Value), Convert.ToInt32(num_book_avilable.Value)
                            , txt_position_book.Text, txt_about_book.Text, txt_book_for.Text,id_cat
                         );
                    lb_message.Text = "تم تعديل الكتاب بنجاح";
                    pic_update.Visible = true;
                    pn_message.Visible = true;
                }
            }
        }        
        private void FRM_ADDBOOK_Activated(object sender, EventArgs e)
        {
           
        }

        private void num_book_avilable_ValueChanged(object sender, EventArgs e)
        {
            if (num_book.Value < num_book_avilable.Value)
            {
                btn_add_edite_book.Enabled = false;
                pn_top.Visible = true;
            }
            else
            {
                btn_add_edite_book.Enabled = true;
                pn_top.Visible = false;
            }
        }        
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }  
        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            if (panel11.Visible == true)
            {
                panel11.Visible = false;
            }
            else
            {
                panel11.Visible = true;
            }
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            if (panel6.Visible == true || panel7.Visible == true)
            {
                panel6.Visible = false;
                panel7.Visible = false;
            }
            else
            {
                panel6.Visible = true;
                panel7.Visible = true;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (panel12.Visible == true)
            {
                panel12.Visible = false;
            }
            else
            {
                panel12.Visible = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            FRM_CAT add_cat = new FRM_CAT();
            add_cat.id = 0;
            add_cat.Show();
        }

        private void num_book_avilable_ValueChanged_1(object sender, EventArgs e)
        {
            num_book_avilable_ValueChanged(sender, e);
        }

        private void num_book_ValueChanged_1(object sender, EventArgs e)
        {
            num_book_avilable_ValueChanged(sender, e);
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
        private void txt_price_book_KeyPress(object sender, KeyPressEventArgs e)
        {
            number_only(e);
        }

        private void txt_number_isbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            number_only(e);
        }
    }
}
    