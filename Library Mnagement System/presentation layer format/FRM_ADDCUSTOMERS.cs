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
    public partial class FRM_ADDCUSTOMERS: Form
    {
        Business_layer_class.cls_customers class_customers = new Business_layer_class.cls_customers();
        public int id;
        string cus;
        string department;
        string info_cust;
        public string state;
        public FRM_ADDCUSTOMERS()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG & JPG & IMG Files|*.png;*.jpg;*.img";
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
        //add _customers       
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
        private void txt_cus_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            number_only(e);
        }
        private void cus_info_dep()
        {
            if (ra_emp.Checked)
            {
                cus = "موظف";
                department = txt_dep_emp.Text;
                info_cust = txt_info_emp.Text;
            }
            else if (ra_prof.Checked)
            {
                cus = "استاذ";
                department = txt_dep_prof.Text;
                info_cust = txt_info_prof.Text;
            }
            else if (ra_stud.Checked)
            {
                cus = "طالب";
                department = txt_dep_stu.Text;
                info_cust = txt_info_stu.Text;
            }
            else if (ra_visiter.Checked)
            {
                cus = "زائر";
                department = "";
                info_cust = "";
            }
        }

        private void btn_add_cust_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cus_name.Text == "" || txt_cus_location.Text == "" || txt_number_card.Text == "" || lb_cus_character.Visible == false)
                {
                    lb_message.Text = "الرجاء ادخال معلومات كافية عن العميل";
                    pic_errore.Visible = true;
                    pn_message.Visible = true;
                }
                else if (id == 0)
                {
                    DataTable dt = new DataTable();
                    dt = class_customers.check_number_card_customers(txt_number_card.Text);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("عذراً!.....ان رقم البطاقة موجود بالفعل", " رقم البطاقة مكرر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_number_card.BackColor = Color.Red;
                        txt_number_card.Focus();
                    }
                    else
                    {                      
                        if (state == "زائر")
                        {
                            cus_info_dep();
                            MemoryStream ms = new MemoryStream();
                            cover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            class_customers.insert_customers(txt_cus_name.Text, txt_cus_location.Text, txt_number_card.Text, txt_cus_location.Text, txt_cus_email.Text, info_cust, department, ms, cus, 0, "نشط");
                            presentation_layer_format.FRM_MAIN fm = new FRM_MAIN();
                            fm.bunifuImageButton1.Visible = false;
                            fm.btn_m_add.Visible = false;
                            fm.btn_students.Enabled = false;
                            fm.btn_selles.Enabled = false;
                            fm.btn_metaphor.Enabled = false;
                            fm.btn_users.Enabled = false;
                            fm.lb_up_def.Visible = false;
                            fm.btn_m_cat.Visible = false;
                            fm.btn_m_delete.Visible = false;
                            fm.btn_m_detel.Visible = true;
                            fm.btn_m_update.Visible = false;
                            fm.btn_h_add.Visible = false;
                            fm.btn_users.Visible = false;
                            fm.btn_h_detel.Visible = true;
                            fm.btn_h_update.Visible = false;
                            fm.btn_backup.Visible = false;
                            fm.btn_h_delete.Visible = false;
                            fm.btn_information.Visible = false;
                            fm.bunifuGradientPanel7.Visible = false;
                            fm.btn_m_detel.Visible = false;
                            fm.btn_add_emp.Visible = false;
                            fm.pic_user.Image = Image.FromStream(ms);
                            fm.lb_name_main.Text = txt_cus_name.Text;
                            fm.lb_prim_main.Text = "زائر";
                            fm. Show();
                            this.Hide();
                        }
                        else
                        {
                            cus_info_dep();
                            MemoryStream ms = new MemoryStream();
                            cover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            class_customers.insert_customers(txt_cus_name.Text, txt_cus_location.Text, txt_number_card.Text, txt_cus_location.Text, txt_cus_email.Text, info_cust, department, ms, cus, 0,"غير نشط");
                            txt_dep_stu.Text = "";
                            txt_info_stu.Text = "";
                            txt_dep_prof.Text = "";
                            txt_info_prof.Text = "";
                            txt_dep_emp.Text = "";
                            txt_info_emp.Text = "";
                            txt_cus_email.Text = "";
                            txt_cus_phone.Text = "";
                            txt_number_card.Text = "";
                            txt_cus_location.Text = "";
                            txt_cus_name.Text = "";
                            lb_message.Text = " تم اضافةالعميل " + txt_cus_name.Text + " ذو الصفة " + cus + " بنجاح ";
                            pic_dell.Visible = true;
                            pn_message.Visible = true;
                        }
                    }
                }
                else
                {
                    cus_info_dep();
                    MemoryStream ms = new MemoryStream();
                    cover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    class_customers.update_customers(txt_cus_name.Text, txt_cus_location.Text, txt_number_card.Text, txt_cus_location.Text, txt_cus_email.Text, info_cust, department, ms, id, cus);
                    lb_message.Text = " تم تعديل بيانات العميل " + txt_cus_name.Text + " بنجاح ";
                    pic_update.Visible = true;
                    pn_message.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ra_emp_CheckedChanged(object sender, EventArgs e)
        {
            if (ra_emp.Checked)
            {
                panel2.Visible = false;
                grop_info_prof.Visible = false;
                panel5.Visible = false;
                grop_info_stud.Visible = false;
                group_info_emp.Visible = true;
                lb_cus_character.Text = ra_emp.Text;
                lb_cus_character.Visible = true;
                panel1.Visible = true;
            }
        }

        private void ra_stud_CheckedChanged(object sender, EventArgs e)
        {
            if (ra_stud.Checked)
            {
                panel2.Visible = false;
                grop_info_prof.Visible = false;
                panel1.Visible = false;
                group_info_emp.Visible = false;                
                grop_info_stud.Visible = true;
                lb_cus_character.Text = ra_stud.Text;
                lb_cus_character.Visible = true;
                panel5.Visible = true;
            }
        }
        private void ra_prof_CheckedChanged(object sender, EventArgs e)
        {
            if (ra_prof.Checked)
            {
                panel1.Visible = false;
                group_info_emp.Visible = false;
                grop_info_stud.Visible = false;
                panel5.Visible = false;
                grop_info_prof.Visible = true;
                lb_cus_character.Text = ra_prof.Text;                
                lb_cus_character.Visible = true;
                panel2.Visible = true;
            }
        }
        private void ra_visiter_CheckedChanged(object sender, EventArgs e)
        {
            if (ra_visiter.Checked)
            {
                panel2.Visible = false;
                grop_info_prof.Visible = false;
                panel5.Visible = false;
                grop_info_stud.Visible = false;
                lb_cus_character.Text = ra_visiter.Text;
                lb_cus_character.Visible = true;
            }
        }
        private void txt_number_card_OnValueChanged(object sender, EventArgs e)
        {
            txt_number_card.BackColor = Color.FromArgb(192, 255, 192);
        }
    }
}
    