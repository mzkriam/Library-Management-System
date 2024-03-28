using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class FRM_WELCOM : Form
    {
        Business_layer_class.cls_customers class_customers = new Business_layer_class.cls_customers();
        presentation_layer_format.FRM_backup fb = new FRM_backup();
        presentation_layer_format.FRM_MAIN FM = new FRM_MAIN();
        public FRM_WELCOM()
        {
            InitializeComponent();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            lb_mainsystem.Text = "تسجيل الدخول";
            panel6.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(panel6);
            panel5.Visible = true;
            panel8.Visible = false;
            panel14.Visible = true;
            panel5.Controls.Clear();
            panel5.Controls.Add(panel14);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;            
            lb_mainsystem.Text = "تسجيل الدخول";
            panel6.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(panel6);
            panel5.Visible = true;
            panel14.Visible = false;
            panel8.Visible = true;
            panel5.Controls.Clear();
            panel5.Controls.Add(panel8);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_cus_name.BackColor = Color.FromArgb(192, 255, 192);
            txt_number_card.BackColor = Color.FromArgb(192, 255, 192);           
            txt_uname.BackColor = Color.FromArgb(192, 255, 192);
            txt_uname.BackColor = Color.FromArgb(192, 255, 192);
            pn_message.Visible = false;
            panel16.Visible = false;
        }       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            lb_mainsystem.Text = "تسجيل الدخول";
            panel5.Visible = true;
            panel5.Controls.Clear();
            panel8.Visible = true;
            panel5.Controls.Add(panel8);
        }
        private void btn_log_in_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = class_customers.log_in(txt_cus_name.Text, txt_number_card.Text);
            if (dt.Rows.Count > 0)
            {                
                class_customers.update_state_for_login(txt_cus_name.Text, txt_number_card.Text);
                object obj1 = dt.Rows[0]["cover"];
                byte[] b = (byte[])obj1;
                MemoryStream ms = new MemoryStream(b);
                FM.pic_user.Image = Image.FromStream(ms);
                object obj2 = dt.Rows[0]["name"];
                FM.lb_name_main.Text = obj2.ToString();               
                FM.lb_prim_main.Text = "زائر";
                FM.btn_add_pdf.Visible = true;
                FM.btn_add_pdf.Enabled = true;
                FM.bunifuImageButton1.Visible = false;
                FM.btn_m_add.Visible = false;
                FM.btn_students.Enabled = false;
                FM.btn_students.Visible = false;
                FM.btn_selles.Enabled = false;
                FM.btn_selles.Visible = false;
                FM.btn_metaphor.Enabled = false;
                FM.btn_metaphor.Visible = false;
                FM.btn_users.Enabled = false;
                FM.lb_up_def.Visible = false;
                FM.btn_m_cat.Visible = false;
                FM.btn_m_delete.Visible = false;
                FM.btn_m_detel.Visible = true;
                FM.btn_m_update.Visible = false;
                FM.btn_h_add.Visible = false;
                FM.btn_users.Visible = false;    
                FM.btn_h_detel.Visible = true;
                FM.btn_h_update.Visible = false;
                FM.btn_backup.Visible = false;
                FM.btn_h_delete.Visible = false;
                FM.btn_information.Visible = false;
                FM.bunifuGradientPanel7.Visible = true;             
                FM.label17.Visible = false;
                FM.label14.Visible = false;
                FM.label3.Visible = false;
                FM.bunifuImageButton3.Visible = false;
                FM.bunifuImageButton2.Visible = false;
                FM.bunifuImageButton1.Visible = false;
                FM.label16.Visible = false;
                FM.label15.Visible = false;
                FM.label4.Visible = false;

                FM.btn_m_detel.Visible = false;
                FM.btn_add_emp.Visible = false;
                FM.btn_add_pdf.Visible = false;
                FM.number_card_log_in = txt_number_card.Text;
                FM.name_customers = txt_cus_name.Text;
                FM.type_cust = (dt.Rows[0]["type_cust"]).ToString();
                FM.state = "زائر";
                FM.Show();
                this.Close();
            }
            else
            {
                pn_message.Visible = true;
                txt_cus_name.BackColor = Color.Red;
                txt_number_card.BackColor = Color.Red;
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_ADDCUSTOMERS add_cus = new presentation_layer_format.FRM_ADDCUSTOMERS();
            add_cus.id = 0;
            add_cus.state = "زائر";
            add_cus.btn_add_cust.ButtonText = "تصفح ";
            lb_mainsystem.Text = "انشاء حساب";
            panel5.Controls.Clear();
            panel5.Controls.Add(add_cus.panel13);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel6.Visible = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(panel3);
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
        private void txt_number_card_KeyPress(object sender, KeyPressEventArgs e)
        {
            number_only(e);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Business_layer_class.cls_user class_user = new Business_layer_class.cls_user();
            DataTable dt = new DataTable();
            dt = class_user.login_select(txt_uname.Text, txt_passward_login.Text);
            if (dt.Rows.Count > 0)
            {
                class_user.update_state_for_login(txt_uname.Text, txt_passward_login.Text);
                object lb_name = dt.Rows[0]["cuser"];
                object lb_prim = dt.Rows[0]["cprim"];
                object pic_user = dt.Rows[0]["ccover"];
                byte[] b = (byte[])pic_user;
                MemoryStream ms = new MemoryStream(b);
                FM.pic_user.Image = Image.FromStream(ms);
                FM.lb_name_main.Text = lb_name.ToString();
                FM.lb_prim_main.Text = lb_prim.ToString();
                string prim = lb_prim.ToString();
                if (prim == "مدير")
                {
                    FM.btn_add_pdf.Visible = true;
                    FM.btn_add_pdf.Enabled = true;
                    FM.btn_main.Visible = true;
                    FM.btn_main.Enabled = true;
                    FM.btn_cat.Visible = true;
                    FM.btn_cat.Enabled = true;
                    FM.btn_book.Visible = true;
                    FM.btn_book.Enabled = true;
                    FM.btn_students.Visible = true;
                    FM.btn_students.Enabled = true;
                    FM.btn_selles.Visible = true;
                    FM.btn_selles.Enabled = true;
                    FM.btn_metaphor.Visible = true;
                    FM.btn_metaphor.Enabled = true;
                    FM.label17.Visible = true;
                    FM.label14.Visible = true;
                    FM.label3.Visible = true;                    
                    FM.label16.Visible = true;
                    FM.label15.Visible = true;
                    FM.label4.Visible = true;
                    FM.btn_users.Visible = true;
                    FM.btn_users.Enabled = true;
                    FM.btn_detel_lib.Visible = true;
                    FM.btn_detel_lib.Enabled = true;
                    FM.lb_up_def.Visible = true;
                    FM.lb_up_def.Enabled = true;
                    FM.lb_def.Visible = true;
                    FM.lb_def.Enabled = true;
                    FM.btn_m_cat.Visible = true;
                    FM.btn_m_cat.Enabled = true;
                    FM.btn_m_add.Visible = true;
                    FM.btn_m_add.Enabled = true;
                    FM.btn_m_update.Visible = true;
                    FM.btn_m_update.Enabled = true;
                    FM.btn_m_delete.Visible = true;
                    FM.btn_m_delete.Enabled = true;
                    FM.btn_m_detel.Visible = true;
                    FM.btn_m_detel.Enabled = true;
                    FM.btn_add_emp.Visible = true;
                    FM.btn_add_emp.Enabled = true;
                    FM.btn_backup.Visible = true;
                    FM.btn_backup.Enabled = true;
                    FM.bunifuImageButton1.Visible = true;
                    FM.bunifuImageButton1.Enabled = true;
                    FM.bunifuImageButton2.Visible = true;
                    FM.bunifuImageButton2.Enabled = true;
                    FM.bunifuImageButton3.Visible = true;
                    FM.bunifuImageButton3.Enabled = true;
                    FM.btn_information.Visible = true;
                    FM.btn_information.Enabled = true;
                }
                else if (prim == "مسؤول مبيعات")
                {
                    FM.label17.Visible = true;
                    FM.label14.Visible = true;
                    FM.label3.Visible = true;                    
                    FM.label16.Visible = true;
                    FM.label15.Visible = true;
                    FM.label4.Visible = true;
                    FM.btn_add_pdf.Visible = false;
                    FM.btn_add_pdf.Enabled = false;
                    FM.btn_main.Visible = true;
                    FM.btn_main.Enabled = true;
                    FM.btn_cat.Visible = true;
                    FM.btn_cat.Enabled = true;
                    FM.btn_book.Visible = true;
                    FM.btn_book.Enabled = true;
                    FM.btn_students.Visible = false;
                    FM.btn_students.Enabled = false;
                    FM.btn_selles.Visible = true;
                    FM.btn_selles.Enabled = true;
                    FM.btn_metaphor.Visible = false;
                    FM.btn_metaphor.Enabled = false;
                    FM.btn_users.Visible = false;
                    FM.btn_users.Enabled = false;
                    FM.btn_detel_lib.Visible = false;
                    FM.btn_detel_lib.Enabled = false;
                    FM.lb_up_def.Visible = false;
                    FM.lb_up_def.Enabled = false;
                    FM.lb_def.Visible = false;
                    FM.lb_def.Enabled = false;
                    FM.btn_m_cat.Visible = false;
                    FM.btn_m_cat.Enabled = false;
                    FM.btn_m_add.Visible = false;
                    FM.btn_m_add.Enabled = false;
                    FM.btn_m_update.Visible = false;
                    FM.btn_m_update.Enabled = false;
                    FM.btn_m_delete.Visible = true;
                    FM.btn_m_delete.Enabled = true;
                    FM.btn_m_detel.Visible = false;
                    FM.btn_m_detel.Enabled = false;
                    FM.btn_add_emp.Visible = false;
                    FM.btn_add_emp.Enabled = false;
                    FM.btn_backup.Visible = false;
                    FM.btn_backup.Enabled = false;
                    FM.bunifuImageButton1.Visible = false;
                    FM.bunifuImageButton1.Enabled = false;
                    FM.bunifuImageButton2.Visible = false;
                    FM.bunifuImageButton2.Enabled = false;
                    FM.bunifuImageButton3.Visible = false;
                    FM.bunifuImageButton3.Enabled = false;
                    FM.btn_information.Visible = false;
                    FM.btn_information.Enabled = false;
                }
                else if (prim == "مدخل بيانات")
                {

                    FM.label17.Visible = true;
                    FM.label14.Visible = true;
                    FM.label3.Visible = true;                    
                    FM.label16.Visible = true;
                    FM.label15.Visible = true;
                    FM.label4.Visible = true;

                    FM.btn_add_pdf.Visible = true;
                    FM.btn_add_pdf.Enabled = true;
                    FM.btn_main.Visible = true;
                    FM.btn_main.Enabled = true;
                    FM.btn_cat.Visible = true;
                    FM.btn_cat.Enabled = true;
                    FM.btn_book.Visible = true;
                    FM.btn_book.Enabled = true;
                    FM.btn_students.Visible = false;
                    FM.btn_students.Enabled = false;
                    FM.btn_selles.Visible = false;
                    FM.btn_selles.Enabled = false;
                    FM.btn_metaphor.Visible = false;
                    FM.btn_metaphor.Enabled = false;
                    FM.btn_users.Visible = false;
                    FM.btn_users.Enabled = false;
                    FM.btn_detel_lib.Visible = false;
                    FM.btn_detel_lib.Enabled = false;
                    FM.lb_up_def.Visible = false;
                    FM.lb_up_def.Enabled = false;
                    FM.lb_def.Visible = false;
                    FM.lb_def.Enabled = false;
                    FM.btn_m_cat.Visible = false;
                    FM.btn_m_cat.Enabled = false;
                    FM.btn_m_add.Visible = true;
                    FM.btn_m_add.Enabled = true;
                    FM.btn_m_update.Visible = false;
                    FM.btn_m_update.Enabled = false;
                    FM.btn_m_delete.Visible = false;
                    FM.btn_m_delete.Enabled = false;
                    FM.btn_m_detel.Visible = false;
                    FM.btn_m_detel.Enabled = false;
                    FM.btn_add_emp.Visible = false;
                    FM.btn_add_emp.Enabled = false;
                    FM.btn_backup.Visible = false;
                    FM.btn_backup.Enabled = false;
                    FM.bunifuImageButton1.Visible = false;
                    FM.bunifuImageButton1.Enabled = false;
                    FM.bunifuImageButton2.Visible = false;
                    FM.bunifuImageButton2.Enabled = false;
                    FM.bunifuImageButton3.Visible = false;
                    FM.bunifuImageButton3.Enabled = false;
                    FM.btn_information.Visible = false;
                    FM.btn_information.Enabled = false;
                }
                else if (prim == "مسؤول اعارة")
                {
                    FM.label17.Visible = true;
                    FM.label14.Visible = true;
                    FM.label3.Visible = true;                   
                    FM.label16.Visible = true;
                    FM.label15.Visible = true;
                    FM.label4.Visible = true;
                    FM.btn_add_pdf.Visible = false;
                    FM.btn_add_pdf.Enabled = false;
                    FM.btn_main.Visible = true;
                    FM.btn_main.Enabled = true;
                    FM.btn_cat.Visible = true;
                    FM.btn_cat.Enabled = true;
                    FM.btn_book.Visible = true;
                    FM.btn_book.Enabled = true;
                    FM.btn_students.Visible = false;
                    FM.btn_students.Enabled = false;
                    FM.btn_selles.Visible = false;
                    FM.btn_selles.Enabled = false;
                    FM.btn_metaphor.Visible = true;
                    FM.btn_metaphor.Enabled = true;
                    FM.btn_users.Visible = false;
                    FM.btn_users.Enabled = false;
                    FM.btn_detel_lib.Visible = false;
                    FM.btn_detel_lib.Enabled = false;
                    FM.lb_up_def.Visible = false;
                    FM.lb_up_def.Enabled = false;
                    FM.lb_def.Visible = false;
                    FM.lb_def.Enabled = false;
                    FM.btn_m_cat.Visible = false;
                    FM.btn_m_cat.Enabled = false;
                    FM.btn_m_add.Visible = false;
                    FM.btn_m_add.Enabled = false;
                    FM.btn_m_update.Visible = false;
                    FM.btn_m_update.Enabled = false;
                    FM.btn_m_delete.Visible = false;
                    FM.btn_m_delete.Enabled = false;
                    FM.btn_m_detel.Visible = true;
                    FM.btn_m_detel.Enabled = true;
                    FM.btn_add_emp.Visible = false;
                    FM.btn_add_emp.Enabled = false;
                    FM.btn_backup.Visible = false;
                    FM.btn_backup.Enabled = false;
                    FM.bunifuImageButton1.Visible = true;
                    FM.bunifuImageButton1.Enabled = true;
                    FM.bunifuImageButton2.Visible = true;
                    FM.bunifuImageButton2.Enabled = true;
                    FM.bunifuImageButton3.Visible = true;
                    FM.bunifuImageButton3.Enabled = true;
                    FM.btn_information.Visible = false;
                    FM.btn_information.Enabled = false;
                }
                this.Close();
                FM.Show();
            }
            else
            {
                pn_message.Visible = true;
                txt_uname.BackColor = Color.Red;
                txt_passward_login.BackColor = Color.Red;
            }
        }
    }
}
