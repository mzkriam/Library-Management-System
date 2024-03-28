using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class FRM_ADD_USER : Form
    {
        Business_layer_class.cls_user class_user = new Business_layer_class.cls_user();
        data_access_layer.CALL_DAL cal_dal = new data_access_layer.CALL_DAL();
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToString();
        }
        private void lb_add_image_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG & JPG & IMG Files|*.png;*.jpg;*.img";
                var res = ofd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    ccover.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_add_Click_1(object sender, EventArgs e)
        {
            if (txt_fname.Text == "" || txt_uname.Text == "" || txt_passward.Text == "" || comboBox1.Text == "" || txt_phone_emp.Text == "" || txt_email_emp.Text == "" || txt_address_emp.Text == "") 
            {
                lb_message.Text = "الرجاء ادخال معلومات الاداري الكاملة";
                pic_update.Visible = false;
                pic_dell.Visible = false;
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                if (id == 0)
                    try
                    {
                        DataTable chech_dt = new DataTable();
                        chech_dt = class_user.check_have_user(txt_uname.Text);
                        if (chech_dt.Rows.Count > 0)
                        {
                            lb_message.Text = "اسم المستخدم موجود من قبل";
                            pic_update.Visible = false;
                            pic_dell.Visible = false;
                            txt_uname.BackColor = Color.Red;
                            pictureBox1.Visible = true;
                            pic_errore.Visible = true;
                            pn_message.Visible = true;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream();
                            ccover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            class_user.insert_user(txt_fname.Text, txt_uname.Text, txt_passward.Text, comboBox1.Text, "false", ms, txt_phone_emp.Text, txt_email_emp.Text, txt_address_emp.Text);
                            lb_message.Text = "تم ادخال معلومات الاداري بنجاح";
                            pic_errore.Visible = false;
                            pic_update.Visible = false;
                            pic_dell.Visible = true;
                            pn_message.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        ccover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        class_user.update_user(txt_fname.Text, txt_uname.Text, txt_passward.Text, comboBox1.Text, ms, id, txt_phone_emp.Text, txt_email_emp.Text, txt_address_emp.Text);
                        lb_message.Text = "تم تعديل معلومات الاداري بنجاح";
                        pic_errore.Visible = false;
                        pic_dell.Visible = false;
                        pic_update.Visible = true;
                        pn_message.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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
        private void timer2_Tick(object sender, EventArgs e)
        {
            pn_message.Visible = false;
        }

        private void txt_phone_emp_KeyPress(object sender, KeyPressEventArgs e)
        {
            number_only(e);
        }

        private void txt_uname_OnValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            txt_uname.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void lb_time_Click(object sender, EventArgs e)
        {

        }
    }
}

