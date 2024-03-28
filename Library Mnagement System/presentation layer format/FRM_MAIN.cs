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
    public partial class FRM_MAIN : Form
    {
        //var for cat
        data_access_layer.CALL_DAL call_dal = new data_access_layer.CALL_DAL();
        presentation_layer_class.cls_cat class_cat = new presentation_layer_class.cls_cat();
        Business_layer_class.cls_BOOKS class_books = new Business_layer_class.cls_BOOKS();
        Business_layer_class.cls_customers class_customers = new Business_layer_class.cls_customers();
        Business_layer_class.cls_seels class_seels = new Business_layer_class.cls_seels();
        Business_layer_class.cls_boro class_boro = new Business_layer_class.cls_boro();
        Business_layer_class.cls_user class_user = new Business_layer_class.cls_user();
        Business_layer_class.cls_connect class_connect = new Business_layer_class.cls_connect();
        //
        public string info_cust;
        public string cus;
        public string department;
        public string number_card_log_in;
        public string name_customers;
        public string type_cust;
        public string cuser;   
        public FRM_MAIN()
        {
            InitializeComponent();
        }
        public string state;//الفصل بين النوافذ 
        //btn close
        private void btn_close_Click(object sender, EventArgs e)
        {
            if (lb_prim_main.Text == "زائر")
            {
                class_customers.update_state_for_logout(name_customers, number_card_log_in);
            }
            else
            {
                class_user.logout(lb_name_main.Text);
            }            
            Environment.Exit(0);
        }
        //btn maxmize
        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        //btn minmize
        private void btn_minmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //btn clooapse
        private void btn_collapse_Click(object sender, EventArgs e)
        {
            if (pn_T.Size.Width == 200)
            {
                simpleButton3.Visible = false;
                pn_T.Width = 50;
                btn_cat.RightToLeft = RightToLeft.Yes;
                btn_book.RightToLeft = RightToLeft.Yes;
                btn_main.RightToLeft = RightToLeft.Yes;
                btn_selles.RightToLeft = RightToLeft.Yes;
                btn_students.RightToLeft = RightToLeft.Yes;
                btn_users.RightToLeft = RightToLeft.Yes;
                btn_metaphor.RightToLeft = RightToLeft.Yes;
                lb_name_main.Visible = false;
                lb_prim_main.Visible = false;
                btn_detel_lib.Visible = false;
                pn_se.Visible = false;
            }
            else
            {
                simpleButton3.Visible = true;
                pn_T.Width = 200;
                btn_cat.RightToLeft = RightToLeft.No;
                btn_book.RightToLeft = RightToLeft.No;
                btn_main.RightToLeft = RightToLeft.No;
                btn_selles.RightToLeft = RightToLeft.No;
                btn_students.RightToLeft = RightToLeft.No;
                btn_users.RightToLeft = RightToLeft.No;
                btn_metaphor.RightToLeft = RightToLeft.No;
                lb_name_main.Visible = true;
                lb_prim_main.Visible = true;
                btn_detel_lib.Visible = true;
                pn_se.Visible = false;
            }
        }
        //btn cat
        private void btn_cat_Click(object sender, EventArgs e)
        {
            state = "CAT";
            FRM_MAIN_Activated(sender, e);
        }
        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            DataTable DD = new DataTable();
            DD = class_boro.select_book_limit(DateTime.Now, "غير مستعاد");
            label16.Text = DD.Rows.Count.ToString();
            DataTable d = new DataTable();
            d = class_boro.select_book_limit_date(DateTime.Now, "غير مستعاد");
            label15.Text = d.Rows.Count.ToString();
            //number_book_porp_limited
            DataTable num_poro = new DataTable();
            num_poro = class_boro.load_t("غير مستعاد");
            label4.Text = num_poro.Rows.Count.ToString();
            ////number of books in form main
            DataTable dt1 = new DataTable();
            dt1 = class_books.load_book();
            lb_books.Text = dt1.Rows.Count.ToString();
            ////number of boro in form main
            DataTable dt2 = new DataTable();
            dt2 = class_boro.load();
            lb_boro.Text = dt2.Rows.Count.ToString();
            ////number of cat in form main
            DataTable dt3 = new DataTable();
            dt3 = class_cat.load();
            lb_cat.Text = dt3.Rows.Count.ToString();
            ////number of seels in form main
            DataTable dt4 = new DataTable();
            dt4 = class_seels.load_seels();
            lb_seels.Text = dt4.Rows.Count.ToString();
            ////number of customers in form main
            DataTable dt5 = new DataTable();
            dt5 = class_customers.load_customers();
            lb_students.Text = dt5.Rows.Count.ToString();
            ////number of user in form main
            DataTable dt6 = new DataTable();
            dt6 = class_user.load_user();
            lb_user.Text = dt6.Rows.Count.ToString();
            //DataTable dt7 = new DataTable();
            //dt7 = class_boro.load_t("عير مستعاد");
            //label4.Text= dt7.Rows.Count.ToString();
            pn_T.BackColor = Library_Mnagement_System.Properties.Settings.Default.mycolorTITEL;
            pn_main.BackColor = Library_Mnagement_System.Properties.Settings.Default.mycolorMAIN;
            pn_top.BackColor = Library_Mnagement_System.Properties.Settings.Default.mycolorTOP;
            pn_home.Visible = false;
            pn_order.Visible = false;
            pn_main.Visible = true;
            lb_mainsystem.Text = "الرئيسية";
            txt_search.Text = "";
        }
        private void btn_main_Click(object sender, EventArgs e)
        {
            FRM_MAIN_Load(sender, e);
        }
        private void btn_h_add_Click(object sender, EventArgs e)
        {
            if (state == "books")
            {
                btn_m_add_Click(sender, e);
            }
            else if (state == "bookpdf")
            {
                btn_add_pdf_Click(sender, e);
            }
            else if (state == "book_poro_limit" ||state == "book_poro_today" || state == "message_unread_customers_type"||state == "message"|| state == "message_type" || state == "message_unread_seels_manager_type" || state == "message_unread_borrow_manager_type" || state == "message_unread_data_entray_type" || state == "message_unread_type" || state == "message_unread" || state == "message_unread_customers" || state == "message_unread_seels_manager" || state == "message_unread_borrow_manager" || state == "message_unread_data_entray")
            {
                btn_send_message_Click(sender, e);
            }
            else if (state == "CAT")
            {
                presentation_layer_format.FRM_CAT FC = new presentation_layer_format.FRM_CAT();
                FC.btn_add.ButtonText = "اضافة";
                FC.id = 0;
                FC.Show();
            }
            else if (state == "customers")
            {
                btn_m_update_Click(sender, e);
            }
            else if (state == "seels")
            {
                btn_m_delete_Click(sender, e);
            }
            else if (state == "boro")
            {
                btn_m_detel_Click(sender, e);
            }
            else if (state == "user")
            {
                btn_add_emp_Click(sender, e);
            }
        }
        private void state_sec()
        {
            btn_h_add.ButtonText = "اضافة";
            if (state == "message_unread_customers_type" || state == "message" || state == "message_type" || state == "message_unread_seels_manager_type" || state == "message_unread_borrow_manager_type" || state == "message_unread_data_entray_type" || state == "message_unread_type" || state == "message_unread" || state == "message_unread_customers" || state == "message_unread_seels_manager" || state == "message_unread_borrow_manager" || state == "message_unread_data_entray")
            {
                btn_h_add.ButtonText = "رسالة";
                btn_h_add.Visible = true;
                pictureBox2.Visible = false;
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                btn_h_update.Visible = false;
                if (local == 1)
                {
                    btn_h_delete.ButtonText = "حذف";
                    btn_h_delete.Visible = true;
                    btn_h_detel.ButtonText = "عرض";
                    btn_h_detel.Visible = true;
                }
                else
                {
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    btn_h_detel.Visible = false;
                }
            }
            if (lb_prim_main.Text == "مدير")
            {
                if (state == "boro")
                {
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "حذف";
                        btn_h_delete.ButtonText = " استرجاع";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_h_add.Visible = true;
                }
                else if (state == "CAT1")
                {
                    if (local == 1)
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                    }
                }
                if (state == "customers")
                {
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "التفاصيل";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                        btn_name_book_poro.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                        btn_name_book_poro.Visible = false;
                    }
                    btn_h_add.Visible = true;
                }
                else if (state == "CAT")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "الكتب التابعة للصنف";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "books")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "التفاصيل";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "bookpdf")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "فتح";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_h_update.Visible = false;
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "seels")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_delete.ButtonText = " استرجاع";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                    btn_h_detel.Visible = false;
                }
                else if (state == "user")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_delete.ButtonText = " حذف";
                        btn_h_detel.ButtonText = "التفاصيل";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
            }
            else if (lb_prim_main.Text == "مسؤول اعارة")
            {
                btn_h_add.Visible = true;
                if (state == "CAT")
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    btn_name_book_poro.Visible = false;
                    btn_h_add.Visible = false;
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.Visible = true;
                        btn_h_detel.ButtonText = " الكتب التابعة للصنف";
                    }
                    else
                    {
                        btn_h_detel.Visible = false;
                    }
                }
                else if (state == "books")
                {
                    btn_h_add.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    btn_name_book_poro.Visible = false;
                    btn_h_add.Visible = false;
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "التفاصيل";
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        btn_h_detel.Visible = false;
                    }
                }
                else if (state == "boro")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "حذف";
                        btn_h_delete.ButtonText = " استرجاع";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                }
                else if (state == "bookpdf")
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    btn_h_add.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "فتح";
                        btn_h_detel.Visible = true;
                    }
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "CAT1")
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                }
            }
            else if (lb_prim_main.Text == "مسؤول مبيعات")
            {
                if (state == "CAT")
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    btn_name_book_poro.Visible = false;
                    btn_h_add.Visible = false;
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.Visible = true;
                        btn_h_detel.ButtonText = " الكتب التابعة للصنف";
                    }
                    else
                    {
                        btn_h_detel.Visible = false;
                    }
                }
                else if (state == "CAT1")
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                }
                else if (state == "books")
                {
                    btn_h_add.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    btn_name_book_poro.Visible = false;
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "التفاصيل";
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        btn_h_detel.Visible = false;
                    }
                }
                else if (state == "seels")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_delete.ButtonText = " استرجاع";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                    btn_h_detel.Visible = false;
                }
                else if (state == "bookpdf")
                {
                    pictureBox2.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    btn_h_add.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "فتح";
                        btn_h_detel.Visible = true;
                    }
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    btn_name_book_poro.Visible = false;
                }
            }
            else if (lb_prim_main.Text == "مدخل بيانات")
            {
                if (state == "CAT")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "الكتب التابعة للصنف";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "books")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "التفاصيل";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_update.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "bookpdf")
                {
                    btn_h_add.Visible = true;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "فتح";
                        btn_h_delete.ButtonText = " حذف";
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                        btn_h_delete.Visible = true;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                    btn_h_update.Visible = false;
                }
                else if (state == "CAT1")
                {
                    if (local == 1)
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                    }
                }
            }
            else if (lb_prim_main.Text == "زائر")
            {
                if (state == "CAT")
                {
                    btn_h_add.Visible = false;
                    if (local == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                        btn_h_detel.ButtonText = "الكتب التابعة للصنف";                        
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "books")
                {
                    btn_h_add.Visible = false;
                    if (local == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                        btn_h_detel.ButtonText = "التفاصيل";                       
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_update.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                }
                else if (state == "bookpdf")
                {
                    btn_h_add.Visible = false;
                    if (local == 1)
                    {
                        btn_h_detel.ButtonText = "فتح";
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_detel.Visible = false;
                        btn_h_detel.Visible = true;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                        btn_h_delete.Visible = false;
                        btn_h_detel.Visible = false;
                    }
                    btn_name_book_poro.Visible = false;
                    btn_h_update.Visible = false;
                }
                else if (state == "CAT1")
                {
                    if (local == 1)
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox3.Visible = false;
                    }
                }
            }
        }
        int local;
        string number_card;
        string name;
        int id_Cat;
        private void FRM_MAIN_Activated(object sender, EventArgs e)
        {
            //*******************************************//            
            DataTable DD = new DataTable();
            DD = class_boro.select_book_limit(DateTime.Now, "غير مستعاد");
            label16.Text = DD.Rows.Count.ToString();
            DataTable d = new DataTable();
            d = class_boro.select_book_limit_date(DateTime.Now, "غير مستعاد");
            label15.Text = d.Rows.Count.ToString();
            //number_book_porp_limited
            DataTable num_poro = new DataTable();
            num_poro = class_boro.load_t("غير مستعاد");
            label4.Text = num_poro.Rows.Count.ToString();
            ////number of books in form main
            DataTable dt1 = new DataTable();
            dt1 = class_books.load_book();
            lb_books.Text = dt1.Rows.Count.ToString();
            ////number of boro in form main
            DataTable dt2 = new DataTable();
            dt2 = class_boro.load();
            lb_boro.Text = dt2.Rows.Count.ToString();
            ////number of cat in form main
            DataTable dt3 = new DataTable();
            dt3 = class_cat.load();
            lb_cat.Text = dt3.Rows.Count.ToString();
            ////number of seels in form main
            DataTable dt4 = new DataTable();
            dt4 = class_seels.load_seels();
            lb_seels.Text = dt4.Rows.Count.ToString();
            ////number of customers in form main
            DataTable dt5 = new DataTable();
            dt5 = class_customers.load_customers();
            lb_students.Text = dt5.Rows.Count.ToString();
            ////number of user in form main
            DataTable dt6 = new DataTable();
            dt6 = class_user.load_user();
            lb_user.Text = dt6.Rows.Count.ToString();
            if (lb_prim_main.Text == "مدير")
            {
                DataTable num = new DataTable();
                num = class_connect.load_message_unread();
                label1.Text = num.Rows.Count.ToString();
                DataTable num1 = new DataTable();
                num1 = class_connect.load_message_unread_type();
                label21.Text = num1.Rows.Count.ToString();
            }
            else if (lb_prim_main.Text == "مدخل بيانات")
            {
                DataTable num = new DataTable();
                num = class_connect.load_message_unread_data_entray(lb_name_main.Text);
                label1.Text = num.Rows.Count.ToString();
                DataTable num1 = new DataTable();
                num1 = class_connect.load_message_data_entray_unread_type(lb_name_main.Text);
                label21.Text = num1.Rows.Count.ToString();
            }
            else if (lb_prim_main.Text == "مسؤول اعارة")
            {
                DataTable num = new DataTable();
                num = class_connect.load_message_unread_borow_manager(lb_name_main.Text);
                label1.Text = num.Rows.Count.ToString();
                DataTable num1 = new DataTable();
                num1 = class_connect.load_message_borrow_manager_unread_type(lb_name_main.Text);
                label21.Text = num1.Rows.Count.ToString();
            }
            else if (lb_prim_main.Text == "مسؤول مبيعات")
            {
                DataTable num = new DataTable();
                num = class_connect.load_message_unread_seels_manager(lb_name_main.Text);
                label1.Text = num.Rows.Count.ToString();
                DataTable num1 = new DataTable();
                num1 = class_connect.load_message_seels_manager_unread_type(lb_name_main.Text);
                label21.Text = num1.Rows.Count.ToString();
            }
            else if (lb_prim_main.Text == "زائر")
            {
                DataTable num = new DataTable();
                num = class_connect.load_message_unread_for_customer(number_card_log_in);
                label1.Text = num.Rows.Count.ToString();
                DataTable num1 = new DataTable();
                num = class_connect.load_message_unread_for_customer_type(number_card_log_in);
                label21.Text = num.Rows.Count.ToString();
            }
            ////************************************************//
            if (state == "CAT1")
            {
                txt_search.Text = "";
                try
                {
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    btn_name_book_poro.Visible = false;
                    btn_h_add.Visible = false;
                    btn_h_delete.Visible = false;
                    btn_h_update.Visible = false;
                    btn_h_detel.ButtonText = "التفاصيل";
                    lb_mainsystem.Text = "  كتب الصنف  " + name + "";
                    DataTable dt = new DataTable();
                    dt = class_cat.load_books_inside_cat(id_Cat);
                    dataGridView1.DataSource = dt;
                    lb_number.Text = dt.Rows.Count.ToString();
                    if (dt.Rows.Count > 0)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    dataGridView1.Columns[0].HeaderText = "رقم الكتاب";
                    dataGridView1.Columns[1].HeaderText = "الرقم العالمي isbn";
                    dataGridView1.Columns[2].HeaderText = "عنوان الكتاب";
                    dataGridView1.Columns[3].HeaderText = "المؤلف";
                    dataGridView1.Columns[4].HeaderText = "الصنف ";
                    dataGridView1.Columns[5].HeaderText = "اللغة";
                    dataGridView1.Columns[6].HeaderText = "الناشر";
                    dataGridView1.Columns[7].HeaderText = "المترجم / المحقق";
                    dataGridView1.Columns[8].HeaderText = " عدد الكتب ";
                    dataGridView1.Columns[9].HeaderText = "عدد المجلدات";
                    dataGridView1.Columns[10].HeaderText = "المتوفرة";
                    dataGridView1.Columns[11].HeaderText = "الموقع";
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "book_poro_today")
            {
                if (d.Rows.Count > 0)
                {
                    btn_h_add.ButtonText = "رسالة";
                    btn_h_add.Visible = true;
                    btn_h_delete.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                }
                else
                {
                    btn_h_add.Visible = false;
                    btn_h_delete.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                }
                lb_number.Text = d.Rows.Count.ToString();
                pn_order.Visible = false;
                pn_main.Visible = false;
                btn_name_book_poro.Visible = false;
                btn_h_detel.Visible = false;
                btn_h_update.Visible = false;                
                pn_home.Visible = true;
                btn_h_delete.ButtonText = "استرجاع";
                lb_mainsystem.Text = "الكتب الواجب استعادتها اليوم";
                dataGridView1.DataSource = d;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم المستعير";
                dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                dataGridView1.Columns[3].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[4].HeaderText = "ISBN";
                dataGridView1.Columns[5].HeaderText = "بداية الاستعارة";
                dataGridView1.Columns[6].HeaderText = "نهاية الاستعارة";
                dataGridView1.Columns[7].HeaderText = "السعر";
                dataGridView1.Columns[8].HeaderText = " حالة الكتاب ";
            }
            //load message unread 
            else if (state == "message_unread_customers_type")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_unread_for_customer_type(number_card_log_in);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الرسائل غير المقروءة";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[3].HeaderText = "الصفة";
                    dataGridView1.Columns[4].HeaderText = "الى";
                    dataGridView1.Columns[5].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[6].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            else if (state == "message_unread_customers")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_unread_for_customer(number_card_log_in);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الرسائل غير المقروءة";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "اسم المستلم";
                    dataGridView1.Columns[5].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[6].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[7].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_seels_manager_type")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_seels_manager_unread_type(lb_name_main.Text);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الرسائل الصادرة غير المقروءة";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_borrow_manager_type")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_borrow_manager_unread_type(lb_name_main.Text);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الرسائل الصادرة غير المقروءة";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_data_entray_type")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_data_entray_unread_type(lb_name_main.Text);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الرسائل الصادرة غير المقروءة";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load meesage manager
            else if (state == "message_unread_type")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_unread_type();
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الرسائل الصادرة غير المقروءة";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[5].HeaderText = "اسم المستلم";
                    dataGridView1.Columns[6].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[7].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_unread();
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[5].HeaderText = "اسم المستلم";
                    dataGridView1.Columns[6].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[7].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load messaage 
            else if (state == "message_unread_data_entray")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    string txt = lb_name_main.Text;
                    num = class_connect.load_message_unread_data_entray(lb_name_main.Text);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "صندوق البريد";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_borrow_manager")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_unread_borow_manager(lb_name_main.Text);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "صندوق البريد";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_seels_manager")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num = new DataTable();
                    num = class_connect.load_message_unread_seels_manager(lb_name_main.Text);
                    lb_number.Text = num.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "صندوق البريد";
                    dataGridView1.DataSource = num;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                    dataGridView1.Columns[2].HeaderText = "الصفة";
                    dataGridView1.Columns[3].HeaderText = "الى";
                    dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                    dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                    if (num.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load data book_poro_limit
            else if (state == "book_poro_limit")
            {
                lb_number.Text = DD.Rows.Count.ToString();
                if (DD.Rows.Count > 0)
                {
                    btn_h_delete.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                }
                else
                {
                    btn_h_delete.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                }
                pn_order.Visible = false;
                pn_main.Visible = false;
                btn_name_book_poro.Visible = false;
                btn_h_detel.Visible = false;
                btn_h_update.Visible = false;
                btn_h_add.Visible = false;
                pn_home.Visible = true;
                btn_h_delete.ButtonText = "استرجاع";
                lb_mainsystem.Text = "الكتب التي تجاوزت تاريخ الاستعادة";
                dataGridView1.DataSource = DD;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم المستعير";
                dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                dataGridView1.Columns[3].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[4].HeaderText = "ISBN";
                dataGridView1.Columns[5].HeaderText = "بداية الاستعارة";
                dataGridView1.Columns[6].HeaderText = "نهاية الاستعارة";
                dataGridView1.Columns[7].HeaderText = "السعر";
                dataGridView1.Columns[8].HeaderText = " حالة الكتاب ";
            }
            else if (state == "book_poro_tajawz")
            {
                lb_number.Text = num_poro.Rows.Count.ToString();
                if (num_poro.Rows.Count > 0)
                {
                    btn_h_delete.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                }
                else
                {
                    btn_h_delete.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                }
                pn_order.Visible = false;
                pn_main.Visible = false;
                btn_name_book_poro.Visible = false;
                btn_h_detel.Visible = false;
                btn_h_update.Visible = false;
                btn_h_add.Visible = false;
                pn_home.Visible = true;
                btn_h_delete.ButtonText = "استرجاع";
                lb_mainsystem.Text = "الكتب المستعارة";
                dataGridView1.DataSource = num_poro;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم المستعير";
                dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                dataGridView1.Columns[3].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[4].HeaderText = "ISBN";
                dataGridView1.Columns[5].HeaderText = "بداية الاستعارة";
                dataGridView1.Columns[6].HeaderText = "نهاية الاستعارة";
                dataGridView1.Columns[7].HeaderText = "السعر";
                dataGridView1.Columns[8].HeaderText = " حالة الكتاب ";
            }
            //load data book_poro_customers
            else if (state == "book_poro_students")
            {
                DataTable dt = new DataTable();
                number_card = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                dt = class_boro.book_poro_students(Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value), "غير مستعاد");
                lb_number.Text = dt.Rows.Count.ToString();
                if (dt.Rows.Count > 0)
                {
                    btn_h_delete.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                }
                else
                {
                    btn_h_delete.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                }
                pn_order.Visible = false;
                pn_main.Visible = false;
                btn_name_book_poro.Visible = false;
                btn_h_detel.Visible = false;
                btn_h_update.Visible = false;
                btn_h_add.Visible = false;
                pn_home.Visible = true;
                btn_h_delete.ButtonText = "استرجاع";
                lb_mainsystem.Text = "الكتب المستعارة من الطالب " + (dataGridView1.CurrentRow.Cells[1].Value).ToString() + "";
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم المستعير";
                dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                dataGridView1.Columns[3].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[4].HeaderText = "ISBN";
                dataGridView1.Columns[5].HeaderText = "بداية الاستعارة";
                dataGridView1.Columns[6].HeaderText = "نهاية الاستعارة";
                dataGridView1.Columns[7].HeaderText = "السعر";
                dataGridView1.Columns[8].HeaderText = " حالة الكتاب ";
            }
            //load data book
            else if (state == "bookpdf")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num1 = new DataTable();
                    num1 = class_books.load_pdf();
                    lb_number.Text = num1.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "PDF";
                    dataGridView1.DataSource = num1;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "الاسم";
                    dataGridView1.Columns[2].HeaderText = "النوع";
                    if (num1.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "books")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num2 = new DataTable();
                    num2 = class_books.load_book();
                    lb_number.Text = num2.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الكتب";
                    dataGridView1.DataSource = num2;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "الرقم العالمي isbn";
                    dataGridView1.Columns[2].HeaderText = "عنوان الكتاب";
                    dataGridView1.Columns[3].HeaderText = "المؤلف";
                    dataGridView1.Columns[4].HeaderText = "الصنف ";
                    dataGridView1.Columns[5].HeaderText = "اللغة";
                    dataGridView1.Columns[6].HeaderText = "الناشر";
                    dataGridView1.Columns[7].HeaderText = "المترجم / المحقق";
                    dataGridView1.Columns[8].HeaderText = " عدد الكتب ";
                    dataGridView1.Columns[9].HeaderText = "عدد المجلدات";
                    dataGridView1.Columns[10].HeaderText = "المتوفرة";
                    dataGridView1.Columns[11].HeaderText = "الموقع";
                    if (num2.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load data cat
            else if (state == "CAT")
            {
                txt_search.Text = "";
                //load data cat
                try
                {
                    DataTable num1 = new DataTable();
                    num1 = class_cat.load();
                    lb_number.Text = num1.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الاصناف";
                    dataGridView1.DataSource = num1;
                    dataGridView1.Columns[0].HeaderText = "رقم الصنف";
                    dataGridView1.Columns[1].HeaderText = "اسم الصنف";
                    if (num1.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load data customers
            else if (state == "customers")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num1 = new DataTable();
                    num1 = class_customers.load_customers();
                    lb_number.Text = num1.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    btn_name_book_poro.Visible = true;
                    pn_home.Visible = true;
                    lb_mainsystem.Text = "العملاء";
                    dataGridView1.DataSource = num1;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم العميل";
                    dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[3].HeaderText = "العنوان ";
                    dataGridView1.Columns[4].HeaderText = "الصفة ";
                    dataGridView1.Columns[5].HeaderText = "المكان";
                    dataGridView1.Columns[6].HeaderText = " القسم";
                    dataGridView1.Columns[7].HeaderText = "عدد الكتب المستعارة";
                    dataGridView1.Columns[8].HeaderText = "الحالة";
                    if (num1.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Load data seels
            else if (state == "seels")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num1 = new DataTable();
                    num1 = class_seels.load_seels();
                    lb_number.Text = num1.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "المبيعات";
                    dataGridView1.DataSource = num1;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المستعير";
                    dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[3].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[4].HeaderText = "ISBN";
                    dataGridView1.Columns[5].HeaderText = "التاريخ";
                    dataGridView1.Columns[6].HeaderText = "السعر";
                    if (num1.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load data boro
            else if (state == "boro")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num1 = new DataTable();
                    num1 = class_boro.load();
                    lb_number.Text = num1.Rows.Count.ToString();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الاستعارة";
                    dataGridView1.DataSource = num1;
                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المستعير";
                    dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                    dataGridView1.Columns[3].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[4].HeaderText = "ISBN";
                    dataGridView1.Columns[5].HeaderText = "بداية الاستعارة";
                    dataGridView1.Columns[6].HeaderText = "نهاية الاستعارة";
                    dataGridView1.Columns[7].HeaderText = "السعر";
                    dataGridView1.Columns[8].HeaderText = " حالة الكتاب ";
                    btn_name_book_poro.Visible = false;
                    if (num1.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //load data user
            else if (state == "user")
            {
                txt_search.Text = "";
                try
                {
                    DataTable num1 = new DataTable();
                    num1 = class_user.load_user();
                    lb_number.Text = num1.Rows.Count.ToString();
                    btn_name_book_poro.Visible = false;
                    pn_order.Visible = false;
                    pn_home.Visible = true;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "الكادر الاداري";
                    dataGridView1.DataSource = num1;
                    dataGridView1.Columns[0].HeaderText = "الرقم التسلسلي";
                    dataGridView1.Columns[1].HeaderText = "الاسم الكامل";
                    dataGridView1.Columns[2].HeaderText = "اسم المستخدم";
                    dataGridView1.Columns[3].HeaderText = "العنوان";
                    dataGridView1.Columns[4].HeaderText = "الصلاحية";
                    dataGridView1.Columns[5].HeaderText = "الهاتف";
                    dataGridView1.Columns[6].HeaderText = "البريد الالكتروني";
                    dataGridView1.Columns[7].HeaderText = "الحالة";
                    if (num1.Rows.Count >= 1)
                    {
                        local = 1;
                    }
                    else
                    {
                        local = 0;
                    }
                    state_sec();
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_type")
            {
                try
                {
                    txt_search.Text = "";
                    if (lb_prim_main.Text == "مدير")
                    {
                        DataTable num1 = new DataTable();
                        num1 = class_connect.load_type();
                        lb_number.Text = num1.Rows.Count.ToString();
                        dataGridView1.DataSource = num1;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                        dataGridView1.Columns[3].HeaderText = "الصفة";
                        dataGridView1.Columns[4].HeaderText = "الى";                      
                        dataGridView1.Columns[5].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[6].HeaderText = "حالة الرسالة";
                        if (num1.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    else if (lb_prim_main.Text == "مسؤول مبيعات")
                    {
                        DataTable ms = new DataTable();
                        ms = class_connect.load_message_for_seels_manager_type(lb_name_main.Text);
                        lb_number.Text = ms.Rows.Count.ToString();
                        dataGridView1.DataSource = ms;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                        if (ms.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    else if (lb_prim_main.Text == "مسؤول اعارة")
                    {
                        DataTable mb = new DataTable();
                        mb = class_connect.load_message_for_borrow_manager_type(lb_name_main.Text);
                        lb_number.Text = mb.Rows.Count.ToString();
                        dataGridView1.DataSource = mb;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                        if (mb.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }

                    }
                    else if (lb_prim_main.Text == "مدخل بيانات")
                    {
                        DataTable num1 = new DataTable();
                        num1 = class_connect.load_message_for_data_entry_type(lb_name_main.Text);
                        lb_number.Text = num1.Rows.Count.ToString();
                        dataGridView1.DataSource = num1;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                        if (num1.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    else if (lb_prim_main.Text == "زائر")
                    {
                        DataTable num1 = new DataTable();
                        num1 = class_connect.load_message_for_customer_type(number_card_log_in);
                        lb_number.Text = num1.Rows.Count.ToString();
                        dataGridView1.DataSource = num1;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                        dataGridView1.Columns[3].HeaderText = "الصفة";
                        dataGridView1.Columns[4].HeaderText = "الى";                                                               
                        dataGridView1.Columns[5].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[6].HeaderText = "حالة الرسالة";
                        if (num1.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    state_sec();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "صندوق الوارد";
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message")
            {
                try
                {
                    txt_search.Text = "";
                    if (lb_prim_main.Text == "مدير")
                    {
                        DataTable num1 = new DataTable();
                        num1 = class_connect.load();
                        lb_number.Text = num1.Rows.Count.ToString();
                        dataGridView1.DataSource = num1;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "رقم البطاقة";
                        dataGridView1.Columns[5].HeaderText = "اسم المستلم";
                        dataGridView1.Columns[6].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[7].HeaderText = "حالة الرسالة";
                        if (num1.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    else if (lb_prim_main.Text == "مسؤول مبيعات")
                    {
                        DataTable ms = new DataTable();
                        ms = class_connect.load_message_for_seels_manager(lb_name_main.Text);
                        lb_number.Text = ms.Rows.Count.ToString();
                        dataGridView1.DataSource = ms;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                        if (ms.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    else if (lb_prim_main.Text == "مسؤول اعارة")
                    {
                        DataTable mb = new DataTable();
                        mb = class_connect.load_message_for_borrow_manager(lb_name_main.Text);
                        lb_number.Text = mb.Rows.Count.ToString();
                        dataGridView1.DataSource = mb;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                        if (mb.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }

                    }
                    else if (lb_prim_main.Text == "مدخل بيانات")
                    {
                        DataTable num1 = new DataTable();
                        num1 = class_connect.load_message_for_data_entry(lb_name_main.Text);
                        lb_number.Text = num1.Rows.Count.ToString();
                        dataGridView1.DataSource = num1;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "الصفة";
                        dataGridView1.Columns[3].HeaderText = "الى";
                        dataGridView1.Columns[4].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[5].HeaderText = "حالة الرسالة";
                        if (num1.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    else if (lb_prim_main.Text == "زائر")
                    {
                        DataTable num11 = new DataTable();
                        num11 = class_connect.load_message_for_customer(number_card_log_in);
                        lb_number.Text = num11.Rows.Count.ToString();
                        dataGridView1.DataSource = num11;
                        dataGridView1.Columns[0].HeaderText = "التسلسل";
                        dataGridView1.Columns[1].HeaderText = "اسم المرسل";
                        dataGridView1.Columns[2].HeaderText = "رقم البطاقة";
                        dataGridView1.Columns[3].HeaderText = "الصفة";
                        dataGridView1.Columns[4].HeaderText = "الى";
                        dataGridView1.Columns[5].HeaderText = "نوع الرسالة";
                        dataGridView1.Columns[6].HeaderText = "حالة الرسالة";
                        if (num11.Rows.Count >= 1)
                        {
                            local = 1;
                        }
                        else
                        {
                            local = 0;
                        }
                    }
                    state_sec();
                    pn_order.Visible = false;
                    pn_main.Visible = false;
                    lb_mainsystem.Text = "صندوق البريد";
                    pn_home.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //update data 
        private void btn_h_update_Click(object sender, EventArgs e)
        {
            //btn_update_cat
            if (state == "CAT")
            {
                //edite cat
                presentation_layer_format.FRM_CAT FU = new presentation_layer_format.FRM_CAT();
                FU.btn_add.ButtonText = "تعديل";
                try
                {
                    FU.txt_cat.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    FU.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    FU.Show();
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات اصناف لاجراء تعديل عليها");
                }
            }
            //btn_update_book
            else if (state == "books")
            {
                //edite books
                try
                {
                    presentation_layer_format.FRM_ADDBOOK edite = new FRM_ADDBOOK();
                    edite.btn_add_edite_book.ButtonText = "تعديل";
                    Business_layer_class.cls_BOOKS class_book = new Business_layer_class.cls_BOOKS();
                    DataTable dt1 = new DataTable();
                    dt1 = class_book.loadcat();
                    object[] obj = new object[dt1.Rows.Count];
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        obj[i] = dt1.Rows[i]["CAT_NAME"];
                    }
                    edite.comboBox1.Items.AddRange(obj);
                    DataTable dt = new DataTable();
                    int id_book = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    edite.id = id_book;
                    dt = class_books.update_books(id_book);
                    object obj1 = dt.Rows[0]["number_isbn"];
                    object obj2 = dt.Rows[0]["TITLE"];
                    object obj3 = dt.Rows[0]["ATHER"];
                    object obj4 = dt.Rows[0]["PRISE"];
                    object obj5 = dt.Rows[0]["DATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["CAT"];
                    object obj8 = dt.Rows[0]["def_book"];
                    object obj9 = dt.Rows[0]["state_book"];
                    object obj10 = dt.Rows[0]["lang_book"];
                    object obj11 = dt.Rows[0]["name_na"];
                    object obj12 = dt.Rows[0]["name_mo"];
                    object obj13 = dt.Rows[0]["num_book"];
                    object obj14 = dt.Rows[0]["num_folders_in_book"];
                    object obj15 = dt.Rows[0]["num_book_avilable"];
                    object obj17 = dt.Rows[0]["position_book"];
                    object obj18 = dt.Rows[0]["book_for"];
                    object obj19 = dt.Rows[0]["about_book"];

                    edite.txt_number_isbn.Text = obj1.ToString();
                    edite.txt_name_book.Text = obj2.ToString();
                    edite.txt_auther.Text = obj3.ToString();
                    edite.txt_price_book.Text = obj4.ToString();
                    edite.datee.Text = obj5.ToString();
                    edite.ratee.Text = obj6.ToString();
                    edite.comboBox1.Text = obj7.ToString();
                    edite.txt_def_book.Text = obj8.ToString();
                    edite.txt_state_book.Text = obj9.ToString();
                    edite.txt_lang_book.Text = obj10.ToString();
                    edite.txt_Publisher.Text = obj11.ToString();
                    edite.txt_investigator.Text = obj12.ToString();
                    edite.num_book.Value = Convert.ToInt32(obj13);
                    edite.num_folders_in_book.Value = Convert.ToInt32(obj14);
                    edite.num_book_avilable.Value = Convert.ToInt32(obj15);
                    //import image to my form
                    object obj16 = dt.Rows[0]["cover"];
                    byte[] b = (byte[])obj16;
                    MemoryStream ms = new MemoryStream(b);
                    edite.cover.Image = Image.FromStream(ms);
                    edite.txt_position_book.Text = obj17.ToString();
                    edite.txt_book_for.Text = obj18.ToString();
                    edite.txt_about_book.Text = obj19.ToString();

                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(edite.panel13);
                    edite.btn_add_cat.ButtonText = "تعديل ";
                    pn_order.Visible = true;
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات كتب لاجراء تعديل عليها");
                }
            }
            //btn_update_customers
            else if (state == "customers")
            {
                try
                {
                    presentation_layer_format.FRM_ADDCUSTOMERS FU = new presentation_layer_format.FRM_ADDCUSTOMERS();
                    FU.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = class_customers.select_update_customers(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["name"];
                    object obj2 = dt.Rows[0]["location"];
                    object obj3 = dt.Rows[0]["phone"];
                    object obj4 = dt.Rows[0]["email"];
                    object obj5 = dt.Rows[0]["info_cust"];
                    object obj6 = dt.Rows[0]["department"];
                    object obj7 = dt.Rows[0]["cover"];
                    byte[] b = (byte[])obj7;
                    MemoryStream ms = new MemoryStream(b);
                    object obj8 = dt.Rows[0]["number_card"];
                    object obj9 = dt.Rows[0]["type_cust"];
                    cus = obj9.ToString();
                    FU.lb_cus_character.Text = cus;
                    FU.lb_cus_character.Visible = true;
                    if (cus == "موظف")
                    {
                        FU.panel1.Visible = true;
                        FU.group_info_emp.Visible = true;
                        FU.txt_dep_emp.Text = obj6.ToString();
                        FU.txt_info_emp.Text = obj5.ToString();
                    }
                    else if (cus == "استاذ")
                    {
                        FU.panel2.Visible = true;
                        FU.grop_info_prof.Visible = true;
                        FU.txt_dep_prof.Text = obj6.ToString();
                        FU.txt_info_prof.Text = obj5.ToString();
                    }
                    else if (cus == "طالب")
                    {
                        FU.panel5.Visible = true;
                        FU.grop_info_stud.Visible = true;
                        FU.txt_dep_stu.Text = obj6.ToString();
                        FU.txt_info_stu.Text = obj5.ToString();
                    }
                    FU.txt_cus_name.Text = Convert.ToString(obj1);
                    FU.txt_cus_location.Text = Convert.ToString(obj2);
                    FU.txt_cus_phone.Text = Convert.ToString(obj3);
                    FU.txt_cus_email.Text = Convert.ToString(obj4);
                    FU.txt_number_card.Text = Convert.ToString(obj8);
                    FU.cover.Image = Image.FromStream(ms);
                    FU.btn_add_cust.ButtonText = "تعديل";
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(FU.panel13);
                    pn_order.Visible = true;
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات طلاب لعرض تفاصيل عنهم");
                }
            }
            //btn_update_seels
            else if (state == "seels")
            {
                try
                {
                    presentation_layer_format.FRM_ADDSELL FUS = new presentation_layer_format.FRM_ADDSELL();
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    FUS.id = id;
                    FUS.btn_add_boro.ButtonText = "تعديل";
                    DataTable dt = new DataTable();
                    dt = class_seels.update_seel(id);
                    object obj1 = dt.Rows[0]["Sname_customer"];
                    object obj2 = dt.Rows[0]["Snumber_card_customer"];
                    object obj3 = dt.Rows[0]["Stitel_book"];
                    object obj4 = dt.Rows[0]["Sisbn"];
                    object obj5 = dt.Rows[0]["Sdate"];
                    object obj7 = dt.Rows[0]["Sprise"];

                    FUS.isbn = obj4.ToString();
                    FUS.number_card = obj2.ToString();

                    FUS.txt_name_customer.Text = obj1.ToString();
                    FUS.txt_number_card_customer.Text = obj2.ToString();
                    FUS.txt_name_book.Text = obj3.ToString();
                    FUS.txt_isbn_book.Text = obj4.ToString();
                    FUS.date_sell.Value = (DateTime)obj5;
                    FUS.txt_prise_.Text = obj7.ToString();
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    DataTable dt1 = new DataTable();
                    dt1 = class_books.load_for_seels();
                    FUS.datagrid_books.DataSource = dt1;
                    FUS.datagrid_books.Columns[0].HeaderText = "اسم الكتاب";
                    FUS.datagrid_books.Columns[1].HeaderText = "ISBN";
                    DataTable dt2 = new DataTable();
                    dt2 = class_customers.load_for_seels();
                    FUS.datagrid_boro.DataSource = dt2;
                    FUS.datagrid_boro.Columns[0].HeaderText = "اسم المستعير";
                    FUS.datagrid_boro.Columns[1].HeaderText = "رقم البطاقة ";
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(FUS.panel13);
                    pn_order.Visible = true;
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات استعارة لاجراء تعديل عليها");
                }
            }
            //btn_update_boro
            else if (state == "boro")
            {
                try
                {
                    string state = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
                    if (state == "مستعاد")
                    {
                        MessageBox.Show("لا يمكن تعديل بيانات عملية استعارة تم فيها استعادة الكتاب", "لا يمكن تعديل مهمة مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        presentation_layer_format.FRM_ADDBORO FUB = new presentation_layer_format.FRM_ADDBORO();
                        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        FUB.id = id;
                        FUB.btn_add_boro.ButtonText = "تعديل";
                        DataTable dt = new DataTable();
                        dt = class_boro.update_boro(id);
                        object obj1 = dt.Rows[0]["bname_customer"];
                        object obj2 = dt.Rows[0]["pnumber_card_customer"];
                        object obj3 = dt.Rows[0]["btitel_book"];
                        object obj4 = dt.Rows[0]["bisbn"];
                        object obj5 = dt.Rows[0]["bdate1"];
                        object obj6 = dt.Rows[0]["bdate2"];
                        object obj7 = dt.Rows[0]["Bprise"];

                        FUB.isbn = obj4.ToString();
                        FUB.number_card = obj2.ToString();

                        FUB.txt_name_customer.Text = obj1.ToString();
                        FUB.txt_number_card_customer.Text = obj2.ToString();
                        FUB.txt_name_book.Text = obj3.ToString();
                        FUB.txt_isbn_book.Text = obj4.ToString();
                        FUB.date_start.Value = (DateTime)obj5;
                        FUB.date_finaly.Value = (DateTime)obj6;
                        FUB.txt_prise_.Text = obj7.ToString();
                        pn_home.Visible = false;
                        pn_main.Visible = false;
                        DataTable dt1 = new DataTable();
                        dt1 = class_books.load_for_seels();
                        FUB.datagrid_books.DataSource = dt1;
                        FUB.datagrid_books.Columns[0].HeaderText = "اسم الكتاب";
                        FUB.datagrid_books.Columns[1].HeaderText = "ISBN";
                        DataTable dt2 = new DataTable();
                        dt2 = class_customers.load_for_seels();
                        FUB.datagrid_boro.DataSource = dt2;
                        FUB.datagrid_boro.Columns[0].HeaderText = "اسم المستعير";
                        FUB.datagrid_boro.Columns[1].HeaderText = "رقم البطاقة ";
                        pn_order.Controls.Clear();
                        pn_order.Controls.Add(FUB.panel13);
                        pn_order.Visible = true;
                    }
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات استعارة لاجراء تعديل عليها");
                }
            }
            //btn_update_user
            else if (state == "user")
            {
                try
                {
                    presentation_layer_format.FRM_ADD_USER FU = new presentation_layer_format.FRM_ADD_USER();
                    DataTable dt = new DataTable();
                    dt = class_user.load_update(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    FU.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    object obj1 = dt.Rows[0]["cname"];
                    object obj2 = dt.Rows[0]["cuser"];
                    object obj3 = dt.Rows[0]["cpassword"];
                    object obj4 = dt.Rows[0]["cprim"];
                    object obj5 = dt.Rows[0]["ccover"];
                    object obj6 = dt.Rows[0]["cphone"];
                    object obj7 = dt.Rows[0]["cemail"];
                    object obj8 = dt.Rows[0]["caddress"];
                    byte[] bb = (byte[])obj5;
                    MemoryStream mms = new MemoryStream(bb);
                    FU.ccover.Image = Image.FromStream(mms);
                    FU.txt_fname.Text = obj1.ToString();
                    FU.txt_uname.Text = obj2.ToString();
                    FU.txt_passward.Text = obj3.ToString();
                    FU.comboBox1.Text = obj4.ToString();
                    FU.txt_phone_emp.Text = obj6.ToString();
                    FU.txt_email_emp.Text = obj7.ToString();
                    FU.txt_address_emp.Text = obj8.ToString();
                    FU.btn_add.Text = "تعديل";
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(FU.panel1);
                    pn_order.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //delete data
        private void btn_h_delete_Click(object sender, EventArgs e)
        {
            if (state == "book_poro_students" || state == "book_poro_tajawz" || state == "book_poro_limit" || state == "book_poro_today")
            {
                state = "boro";
                btn_h_delete_Click(sender, e);
            }
            else if (state == "message_unread_customers_type" || state == "message" || state == "message_type" || state == "message_unread_seels_manager_type" || state == "message_unread_borrow_manager_type" || state == "message_unread_data_entray_type" || state == "message_unread_type" || state == "message_unread" || state == "message_unread_customers" || state == "message_unread_seels_manager" || state == "message_unread_borrow_manager" || state == "message_unread_data_entray")
            {
                try
                {
                    class_connect.delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    presentation_layer_format.FRM_DI_DELETE delete = new presentation_layer_format.FRM_DI_DELETE();
                    delete.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //delete cat           
            else if (state == "CAT")
            {
                try
                {
                    DataTable book_in_cat = new DataTable();
                    book_in_cat = class_cat.load_for_delet(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    if (book_in_cat.Rows.Count > 0)
                    {
                        MessageBox.Show("لا يمكن حذف صنف يحوي كتب معارة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        class_cat.delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        presentation_layer_format.FRM_DI_DELETE delete = new presentation_layer_format.FRM_DI_DELETE();
                        delete.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //delete books
            else if (state == "books")
            {
                try
                {
                    class_books.delete_book(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    presentation_layer_format.FRM_DI_DELETE fd = new presentation_layer_format.FRM_DI_DELETE();
                    fd.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //delete students
            else if (state == "customers")
            {
                try
                {
                    class_customers.delete_customers(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    presentation_layer_format.FRM_DI_DELETE sd = new presentation_layer_format.FRM_DI_DELETE();
                    sd.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //btn_return_seel
            else if (state == "seels")
            {
                try
                {
                    FRM_Return_book Return = new FRM_Return_book();
                    Return.state = "seels";
                    Return.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Return.isbn = Return.txt_isbn_book.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    Return.txt_name_book.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    Return.txt_name_customer.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    Return.number_card = Return.txt_number_card_customer.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    DataTable dt = new DataTable();
                    dt = class_boro.select_num(Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value));
                    object po = dt.Rows[0]["position_book"];
                    Return.txt_position_book.Text = po.ToString();
                    lb_mainsystem.Text = "استرجاع كتاب";
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(Return.panel13);
                    pn_order.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //btn_return poro
            else if (state == "boro")
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if ((string)(dataGridView1.CurrentRow.Cells[8].Value) == "مستعاد")
                        {
                            MessageBox.Show("الكتاب تمت استعادته سابقاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            FRM_Return_book Return = new FRM_Return_book();
                            Return.state = "poro";
                            Return.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            Return.isbn = Return.txt_isbn_book.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                            Return.txt_name_book.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                            Return.txt_name_customer.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                            Return.number_card = Return.txt_number_card_customer.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                            DataTable dt = new DataTable();
                            dt = class_boro.select_num(Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value));
                            if (dt.Rows.Count > 0)
                            {
                                object po = dt.Rows[0]["position_book"];
                                Return.txt_position_book.Text = po.ToString();
                            }
                            lb_mainsystem.Text = "استرجاع كتاب";
                            pn_home.Visible = false;
                            pn_main.Visible = false;
                            pn_order.Controls.Clear();
                            pn_order.Controls.Add(Return.panel13);
                            pn_order.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //btn_delet_user
            else if (state == "user")
            {
                try
                {
                    {
                        class_user.delete_user(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        presentation_layer_format.FRM_DI_DELETE FD = new presentation_layer_format.FRM_DI_DELETE();
                        FD.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "bookpdf")
            {
                try
                {
                    {
                        class_books.delete_pdf(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        presentation_layer_format.FRM_DI_DELETE FD = new presentation_layer_format.FRM_DI_DELETE();
                        FD.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //search data
        private void txt_search_OnValueChanged(object sender, EventArgs e)
        {
            //search cat
            if (state == "CAT")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_cat.search(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "CAT1")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_cat.search_books_inside_cat(txt_search.Text, id_Cat);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //search books
            else if (state == "books")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_books.search(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "book_poro_students")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_boro.search_book_poro_customer(number_card, "غير مستعاد", txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "bookpdf")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_books.search_pdf(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //search students
            else if (state == "customers")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_customers.search_customers(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //search seels
            }
            //search seels
            else if (state == "seels")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_seels.search(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "book_poro_today")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_boro.search_book_limit_date(txt_search.Text, "غير مستعاد", DateTime.Now);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //search boro 
            else if (state == "book_poro_limit")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_boro.search_book_limit_date(txt_search.Text, "غير مستعاد", DateTime.Now);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "book_poro_tajawz")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_boro.search_book_boro_ta(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "boro")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_boro.search_boro(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //search user
            else if (state == "user")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_user.search_user(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_manger_unread(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_data_entray")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_data_entray_unread(txt_search.Text, lb_name_main.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_borrow_manager")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_borrow_manager_unread(txt_search.Text, lb_name_main.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_seels_manager")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_seels_manager_unread(txt_search.Text, lb_name_main.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_customers")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_customers_unread(txt_search.Text, number_card_log_in);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_type")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_unread_type(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_data_entray_type")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_data_entray_unread_type(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_borrow_manager_type")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_borrow_manager_unread_type(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_seels_manager_type")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_seels_manager_unread_type(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_unread_customers_type")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_unread_for_customer_type(number_card_log_in, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message" && lb_prim_main.Text == "مسؤول اعارة")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_for_borrow_manager(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message" && lb_prim_main.Text == "مدير")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_in_message_for_manager(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message" && lb_prim_main.Text == "مسؤول مبيعات")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_for_seels_manager(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message" && lb_prim_main.Text == "مدخل بيانات")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_for_data_entry(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message" && lb_prim_main.Text == "زائر")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_for_customer(number_card_log_in, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_type" && lb_prim_main.Text == "مدير")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_type(txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_type" && lb_prim_main.Text == "مسؤول مبيعات")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_for_seels_manager_type(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_type" && lb_prim_main.Text == "مسؤول اعارة")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.seaarh_message_for_borrow_manager_type(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_type" && lb_prim_main.Text == "مدخل بيانات")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_connect.search_message_for_data_entry_type(lb_name_main.Text, txt_search.Text);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "message_type" && lb_prim_main.Text == "مدخل بيانات")
            {
                try
                {
                    DataTable dt = new DataTable();
                dt = class_connect.search_message_for_customer_type(number_card_log_in, txt_search.Text);
                dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //btn books
        public void btn_book_Click(object sender, EventArgs e)
        {
            state = "books";
            FRM_MAIN_Activated(sender, e);
        }
        //btn detel
        private SqlConnection GetCon()
        {
            return new SqlConnection(@"Data Source=DESKTOP-6N1SK7T\ZKARIA2019;Initial Catalog=LMS;Integrated Security=True");
        }

        private void openpdf(int id)
        {
            using (SqlConnection cn = GetCon())
            {
                string Q = "select Id,FIlename,EX,Data from PDF where Id=@id";
                SqlCommand cmd = new SqlCommand(Q, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FIlename"].ToString();
                    var data = (byte[])reader["Data"];
                    var extn = reader["EX"].ToString();
                    var newfilename = name.Replace(extn, DateTime.Now.ToString("ddMMyyyy")) + extn;
                    File.WriteAllBytes(newfilename, data);
                    System.Diagnostics.Process.Start(newfilename);
                }
            }
        }
        private void btn_h_detel_Click(object sender, EventArgs e)
        {
            //delete boro
            if (state == "boro")
            {
                try
                {
                    if (Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value) == "مستعاد")
                    {
                        class_boro.delete_poro(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        MessageBox.Show("تمت عملية الحذف بنجاح", "عملية مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        string isbn = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                        dt = class_boro.select_num(isbn);
                        object o = dt.Rows[0]["num_book_avilable"];
                        int num_book = Convert.ToInt32(o);
                        int new_num_book = num_book + 1;
                        DataTable dt1 = new DataTable();
                        string number_card = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                        dt1 = class_boro.select_card(number_card);
                        object o1 = dt1.Rows[0]["num_book_pro"];
                        int num_poro = Convert.ToInt32(o1);
                        int new_num_book_poro = num_poro - 1;
                        dt = class_boro.update_edite_poro(isbn, new_num_book, number_card, new_num_book_poro);
                        class_boro.delete_poro(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        MessageBox.Show("تمت عملية الحذف بنجاح", "عملية مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "CAT1")
            {
                state = "books";
                btn_h_detel_Click(sender, e);
            }
            else if (state == "CAT")
            {
                id_Cat = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

                state = "CAT1";
                FRM_MAIN_Activated(sender, e);
            }
            else if (state == "books")
            {
                try
                {
                    presentation_layer_format.FRM_ADDBOOK FD = new presentation_layer_format.FRM_ADDBOOK();
                    DataTable dt = new DataTable();
                    string name_book = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    lb_mainsystem.Text = "تفاصيل الكتاب " + name_book + "";
                    dt = class_books.update_books(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj = dt.Rows[0]["number_isbn"];
                    FD.txt_number_isbn.Text = obj.ToString();
                    FD.txt_number_isbn.Enabled = false;
                    object obj1 = dt.Rows[0]["TITLE"];
                    FD.txt_name_book.Text = Convert.ToString(obj1);
                    FD.txt_name_book.Enabled = false;
                    object obj2 = dt.Rows[0]["ATHER"];
                    FD.txt_auther.Text = Convert.ToString(obj2);
                    FD.txt_auther.Enabled = false;
                    object obj3 = dt.Rows[0]["CAT"];
                    FD.comboBox1.Text = Convert.ToString(obj3);
                    FD.comboBox1.Enabled = false;
                    object obj4 = dt.Rows[0]["PRISE"];
                    FD.txt_price_book.Text = Convert.ToString(obj4);
                    FD.txt_price_book.Enabled = false;
                    object obj5 = dt.Rows[0]["DATE"];
                    FD.datee.Value = (DateTime)obj5;
                    FD.datee.Enabled = false;
                    object obj6 = dt.Rows[0]["RATE"];
                    FD.ratee.Value = (int)obj6;
                    FD.ratee.Enabled = false;
                    object obj7 = dt.Rows[0]["COVER"];
                    byte[] im = (byte[])obj7;
                    MemoryStream ms = new MemoryStream(im);
                    FD.cover.Image = Image.FromStream(ms);
                    FD.linkLabel1.Visible = false;
                    object obj9 = dt.Rows[0]["def_book"];
                    FD.txt_def_book.Text = obj9.ToString();
                    FD.txt_def_book.Enabled = false;
                    object obj10 = dt.Rows[0]["lang_book"];
                    FD.txt_lang_book.Text = obj10.ToString();
                    FD.txt_lang_book.Enabled = false;
                    object obj11 = dt.Rows[0]["state_book"];
                    FD.txt_state_book.Text = obj11.ToString();
                    FD.txt_state_book.Enabled = false;
                    object obj12 = dt.Rows[0]["name_na"];
                    FD.txt_Publisher.Text = obj12.ToString();
                    FD.txt_Publisher.Enabled = false;
                    object obj13 = dt.Rows[0]["name_mo"];
                    FD.txt_investigator.Text = obj13.ToString();
                    FD.txt_investigator.Enabled = false;
                    object obj14 = dt.Rows[0]["num_book"];
                    FD.num_book.Text = obj14.ToString();
                    FD.num_book.Enabled = false;
                    object obj15 = dt.Rows[0]["num_folders_in_book"];
                    FD.num_folders_in_book.Text = obj15.ToString();
                    FD.num_folders_in_book.Enabled = false;
                    object obj16 = dt.Rows[0]["num_book_avilable"];
                    FD.num_book_avilable.Text = obj16.ToString();
                    FD.num_book_avilable.Enabled = false;
                    object obj17 = dt.Rows[0]["position_book"];
                    FD.txt_position_book.Text = obj17.ToString();
                    FD.txt_position_book.Enabled = false;
                    object obj18 = dt.Rows[0]["book_for"];
                    FD.txt_book_for.Text = obj18.ToString();
                    FD.txt_book_for.Enabled = false;
                    object obj19 = dt.Rows[0]["about_book"];
                    FD.txt_about_book.Text = obj19.ToString();
                    FD.txt_about_book.Enabled = false;
                    FD.btn_add_cat.Enabled = false;
                    FD.btn_add_cat.Visible = false;
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(FD.panel13);
                    FD.btn_add_edite_book.Enabled = false;
                    FD.btn_add_edite_book.Visible = false;
                    pn_order.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (state == "bookpdf")
            {
                var SR = dataGridView1.SelectedRows;
                foreach (var row in SR)
                {
                    int id = (int)((DataGridViewRow)row).Cells[0].Value;
                    openpdf(id);
                }
            }
            else if (state == "customers")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = class_customers.select_update_customers(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    presentation_layer_format.FRM_ADDCUSTOMERS FU = new presentation_layer_format.FRM_ADDCUSTOMERS();
                    FU.panel11.Visible = false;
                    object obj1 = dt.Rows[0]["name"];
                    object obj2 = dt.Rows[0]["location"];
                    object obj3 = dt.Rows[0]["phone"];
                    object obj4 = dt.Rows[0]["email"];
                    object obj5 = dt.Rows[0]["info_cust"];
                    object obj6 = dt.Rows[0]["department"];
                    object obj7 = dt.Rows[0]["cover"];
                    byte[] b = (byte[])obj7;
                    MemoryStream ms = new MemoryStream(b);
                    object obj8 = dt.Rows[0]["number_card"];
                    object obj9 = dt.Rows[0]["type_cust"];
                    cus = obj9.ToString();
                    FU.lb_cus_character.Text = cus;
                    FU.lb_cus_character.Visible = true;
                    if (cus == "موظف")
                    {
                        FU.panel1.Visible = true;
                        FU.group_info_emp.Visible = true;
                        FU.txt_dep_emp.Text = obj6.ToString();
                        FU.txt_info_emp.Text = obj5.ToString();
                    }
                    else if (cus == "استاذ")
                    {
                        FU.panel2.Visible = true;
                        FU.grop_info_prof.Visible = true;
                        FU.txt_dep_prof.Text = obj6.ToString();
                        FU.txt_info_prof.Text = obj5.ToString();
                    }
                    else if (cus == "طالب")
                    {
                        FU.panel5.Visible = true;
                        FU.grop_info_stud.Visible = true;
                        FU.txt_dep_stu.Text = obj6.ToString();
                        FU.txt_info_stu.Text = obj5.ToString();
                    }
                    FU.txt_cus_name.Text = Convert.ToString(obj1);
                    FU.txt_cus_location.Text = Convert.ToString(obj2);
                    FU.txt_cus_phone.Text = Convert.ToString(obj3);
                    FU.txt_cus_email.Text = Convert.ToString(obj4);
                    FU.txt_number_card.Text = Convert.ToString(obj8);
                    FU.cover.Image = Image.FromStream(ms);
                    FU.btn_add_cust.Enabled = false;
                    FU.btn_add_cust.Visible = false;
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(FU.panel13);
                    pn_order.Visible = true;
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات طلاب لعرض تفاصيل عنهم");
                }
            }
            else if (state == "user")
            {
                try
                {
                    presentation_layer_format.FRM_ADD_USER FU = new presentation_layer_format.FRM_ADD_USER();
                    DataTable dt = new DataTable();
                    dt = class_connect.load_message(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    FU.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    object obj1 = dt.Rows[0]["cname"];
                    object obj2 = dt.Rows[0]["cuser"];
                    object obj3 = dt.Rows[0]["cpassword"];
                    object obj4 = dt.Rows[0]["cprim"];
                    object obj5 = dt.Rows[0]["ccover"];
                    object obj6 = dt.Rows[0]["cphone"];
                    object obj7 = dt.Rows[0]["cemail"];
                    object obj8 = dt.Rows[0]["caddress"];
                    byte[] bb = (byte[])obj5;
                    MemoryStream mms = new MemoryStream(bb);
                    FU.ccover.Image = Image.FromStream(mms);
                    FU.txt_fname.Text = obj1.ToString();
                    FU.txt_uname.Text = obj2.ToString();
                    FU.txt_passward.Text = obj3.ToString();
                    FU.comboBox1.Text = obj4.ToString();
                    FU.txt_phone_emp.Text = obj6.ToString();
                    FU.txt_email_emp.Text = obj7.ToString();
                    FU.txt_address_emp.Text = obj8.ToString();
                    FU.Enabled = false;
                    pn_home.Visible = false;
                    pn_main.Visible = false;
                    FU.lb_add_image.Visible = false;
                    FU.btn_add.Visible = false;
                    pn_order.Controls.Clear();
                    pn_order.Controls.Add(FU.panel1);
                    pn_order.Visible = true;
                }
                catch
                {
                    MessageBox.Show("لا يوجد بيانات مستخدمين لعرض تفاصيل عنهم ");
                }
            }
            else if (state == "message_type"||state == "message" || state == "message_unread"|| state == "message_unread_customers" || state == "message_unread_seels_manager" || state == "message_unread_borrow_manager" || state == "message_unread_data_entray"|| state == "message_unread_customers_type"|| state == "message_unread_seels_manager_type"|| state == "message_unread_borrow_manager_type"|| state == "message_unread_data_entray_type" || state == "message_unread_type")
            {
                //try
                //{
                presentation_layer_format.FRM_connect_lib FU = new presentation_layer_format.FRM_connect_lib();
                DataTable dt = new DataTable();
                dt = class_connect.load_message(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                FU.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                object obj1 = dt.Rows[0]["name_sender"];
                FU.txt_name.Text = obj1.ToString();
                object obj3 = dt.Rows[0]["type_sender"];
                FU.txt_type_sender.Text = obj3.ToString();
                if (obj3.ToString() == "زائر")
                {
                    object obj2 = dt.Rows[0]["number_card_sender"];
                    FU.txt_number.Text = obj2.ToString();
                    FU.txt_number.Visible = true;
                    FU.label11.Visible = true;
                }
                else
                {
                    FU.label11.Visible = false;
                    FU.txt_number.Visible = false;
                }
                object obj4 = dt.Rows[0]["info_message"];
                FU.txt_info.Text = obj4.ToString();
                FU.txt_info.Enabled = false;
                object obj9 = dt.Rows[0]["file_name"];
                if (obj9.ToString() != "")
                {
                    FU.txt_name_pdf.Text = obj9.ToString();
                    object obj8 = dt.Rows[0]["pdf"];
                    FU.linkLabel2.Visible = true;
                    FU.txt_name_pdf.Visible = true;
                    FU.txt_name_pdf.Enabled = false;
                    FU.linkLabel2.Text = "فتح الملف";
                    FU.pictureBox1.Visible = true;
                }
                else
                {
                    FU.txt_name_pdf.Visible = false;
                    FU.pictureBox1.Visible = false;
                    FU.linkLabel2.Visible = false;
                }
                object obj6 = dt.Rows[0]["message_for"];
                if (obj6.ToString() == "زائر")
                {
                    object obj11 = dt.Rows[0]["number_card_recipient"];
                    object obj10 = dt.Rows[0]["name_recipient"];
                    FU.panel15.Visible = true;
                    FU.txt_name_cust.Text = obj10.ToString();
                    FU.txt_name_cust.Enabled = false;
                    FU.comboBox1.Text = obj11.ToString();
                    FU.comboBox1.Enabled = false;

                }
                else
                {
                    FU.panel15.Visible = false;
                }
                object obj7 = dt.Rows[0]["type_message"];
                FU.combo_message_for.Text = obj6.ToString();
                FU.combo_message_for.Enabled = false;
                FU.txt_type_message.Text = obj7.ToString();
                FU.txt_type_message.Enabled = false;
                object obj5 = dt.Rows[0]["cover"];
                if (obj5.ToString() != "")
                {
                    FU.panel15.Visible = true;
                    FU.linkLabel1.Visible = true;
                    FU.pic_message.Visible = true;
                    FU.linkLabel1.Text = "تحميل الصورة";
                    byte[] bb = (byte[])obj5;
                    MemoryStream mms = new MemoryStream(bb.ToArray());
                    FU.pic_message.Image = Image.FromStream(mms);
                }
                else
                {
                    FU.panel15.Visible = false;
                    FU.linkLabel1.Visible = false;
                    FU.pic_message.Visible = false;
                }
                class_connect.update_state(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), lb_prim_main.Text);
                FU.Enabled = false;
                pn_home.Visible = false;
                pn_main.Visible = false;
                FU.btn_add_boro.Visible = false;
                pn_order.Controls.Clear();
                pn_order.Controls.Add(FU.panel13);
                pn_order.Visible = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }
        //btn students
        private void btn_students_Click(object sender, EventArgs e)
        {
            state = "customers";
            FRM_MAIN_Activated(sender, e);
        }

        private void btn_selles_Click(object sender, EventArgs e)
        {
            state = "seels";
            FRM_MAIN_Activated(sender, e);
        }

        private void btn_metaphor_Click(object sender, EventArgs e)
        {
            state = "boro";
            FRM_MAIN_Activated(sender, e);
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            state = "user";
            FRM_MAIN_Activated(sender, e);
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            if (lb_prim_main.Text == "زائر")
            {
                class_customers.update_state_for_logout(name_customers, number_card_log_in);
            }
            else
            {
                class_user.logout(lb_name_main.Text);
            }
            this.Close();
            presentation_layer_format.FRM_WELCOM fw = new FRM_WELCOM();
            fw.lb_email.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            fw.lb_whtsapp.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone2;
            fw.lb_face_book.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            fw.lb_instgrame.Text = Library_Mnagement_System.Properties.Settings.Default.lib_instgrame;
            fw.lb_name_lib.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            fw.lb_address_lip.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            fw.txt_phone_lib.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            fw.lb_def.Text = Library_Mnagement_System.Properties.Settings.Default.lib_info;
            fw.pictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            fw.lb_def.Visible = true;
            fw.panel1.Controls.Clear();
            fw.panel1.Controls.Add(fw.panel3);
            fw.Show();
        }

        private void btn_m_add_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_ADDBOOK ADD_book = new FRM_ADDBOOK();
            ADD_book.btn_add_edite_book.ButtonText = "اضافة";
            ADD_book.id = 0;
            try
            {
                Business_layer_class.cls_BOOKS class_book = new Business_layer_class.cls_BOOKS();
                DataTable dt = new DataTable();
                dt = class_book.loadcat();
                object[] obj = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj[i] = dt.Rows[i]["CAT_NAME"];
                }
                ADD_book.comboBox1.Items.AddRange(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lb_mainsystem.Text = "اضافة كتاب";
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_order.Controls.Clear();
            pn_order.Controls.Add(ADD_book.panel13);
            pn_order.Visible = true;
        }

        private void btn_m_update_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_ADDCUSTOMERS add_cus = new presentation_layer_format.FRM_ADDCUSTOMERS();
            add_cus.id = 0;
            lb_mainsystem.Text = "اضافة عميل";
            add_cus.btn_add_cust.ButtonText = "اضافة عميل";
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_order.Controls.Clear();
            pn_order.Controls.Add(add_cus.panel13);
            pn_order.Visible = true;
        }
        private void btn_m_delete_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_ADDSELL SELL = new presentation_layer_format.FRM_ADDSELL();
            SELL.id = 0;
            lb_mainsystem.Text = " عملية بيع";
            SELL.date_sell.Value = DateTime.Now;
            pn_home.Visible = false;
            pn_main.Visible = false;
            DataTable dt1 = new DataTable();
            dt1 = class_books.load_for_seels();
            SELL.datagrid_books.DataSource = dt1;
            SELL.datagrid_books.Columns[0].HeaderText = "اسم الكتاب";
            SELL.datagrid_books.Columns[1].HeaderText = "ISBN";
            SELL.datagrid_books.Columns[2].HeaderText = "السعر";
            DataTable dt2 = new DataTable();
            dt2 = class_customers.load_for_seels();
            SELL.datagrid_boro.DataSource = dt2;
            SELL.datagrid_boro.Columns[0].HeaderText = "اسم المستعير";
            SELL.datagrid_boro.Columns[1].HeaderText = "رقم البطاقة ";
            pn_order.Controls.Clear();
            pn_order.Controls.Add(SELL.panel13);
            pn_order.Visible = true;
        }
        private void btn_m_detel_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_ADDBORO boro = new presentation_layer_format.FRM_ADDBORO();
            boro.id = 0;
            lb_mainsystem.Text = " عملية استعارة";
            pn_home.Visible = false;
            pn_main.Visible = false;
            DataTable dt1 = new DataTable();
            dt1 = class_books.load_for_seels();
            boro.datagrid_books.DataSource = dt1;
            boro.datagrid_books.Columns[0].HeaderText = "اسم الكتاب";
            boro.datagrid_books.Columns[1].HeaderText = "ISBN";
            boro.datagrid_books.Columns[2].HeaderText = "السعر";
            DataTable dt2 = new DataTable();
            dt2 = class_customers.load_for_seels();
            boro.datagrid_boro.DataSource = dt2;
            boro.datagrid_boro.Columns[0].HeaderText = "اسم المستعير";
            boro.datagrid_boro.Columns[1].HeaderText = "رقم البطاقة ";
            pn_order.Controls.Clear();
            pn_order.Controls.Add(boro.panel13);
            pn_order.Visible = true;
        }
        private void btn_m_cat_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_CAT cat = new presentation_layer_format.FRM_CAT();
            cat.id = 0;
            cat.Show();
        }
        private void btn_information_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_reports reports = new presentation_layer_format.FRM_reports();
            lb_mainsystem.Text = "التقارير";
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_order.Controls.Clear();
            pn_order.Controls.Add(reports.panel1);
            pn_order.Visible = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_backup FB = new FRM_backup();
            FB.Show();
        }
        private void btn_detel_lib_Click(object sender, EventArgs e)
        {
            Business_layer_class.cls_user class_user = new Business_layer_class.cls_user();
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            presentation_layer_format.FRM_info_lib fd = new FRM_info_lib();
            if (pn_se.Visible == false)
            {
                pn_se.Visible = true;

                if (dt.Rows.Count > 0)
                {
                    lb_up_def.Visible = true;
                }
                else
                {
                    lb_up_def.Visible = false;
                }
            }
            else
            {
                pn_se.Visible = false;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_info_lib add_info = new presentation_layer_format.FRM_info_lib();
            lb_mainsystem.Text = "تفاصيل المكتبة";
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_order.Controls.Clear();
            pn_order.Controls.Add(add_info.panel13);
            pn_order.Visible = true;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer_format.FRM_info_lib add_info = new presentation_layer_format.FRM_info_lib();
                lb_mainsystem.Text = "تفاصيل المكتبة";
                add_info.txt_facebook.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
                add_info.txt_instgrame.Text = Library_Mnagement_System.Properties.Settings.Default.lib_instgrame;
                add_info.txt_namelib.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
                add_info.txt_email.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
                add_info.txt_phone1.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
                add_info.txt_def.Text = Library_Mnagement_System.Properties.Settings.Default.lib_info;
                add_info.txt_address.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
                add_info.txt_phone2.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone2;
                add_info.pic_lib.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
                add_info.btn_add_boro.Enabled = false;
                add_info.btn_add_boro.Visible = false;
                add_info.linkLabel1.Visible = false;
                pn_home.Visible = false;
                pn_main.Visible = false;
                pn_order.Controls.Clear();
                pn_order.Controls.Add(add_info.panel13);
                pn_order.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_name_book_poro_Click(object sender, EventArgs e)
        {
            state = "book_poro_students";
            FRM_MAIN_Activated(sender, e);
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            state = "book_poro_tajawz";
            FRM_MAIN_Activated(sender, e);
        }
        private void btn_add_emp_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_ADD_USER add_user = new presentation_layer_format.FRM_ADD_USER();
            add_user.id = 0;
            lb_mainsystem.Text = "اضافة موظف";
            add_user.btn_add.Text = "اضافة";
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_order.Controls.Clear();
            pn_order.Controls.Add(add_user.panel1);
            pn_order.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToString();
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            pn_main.BackColor = Color.FromArgb(191, 255, 232);
            Library_Mnagement_System.Properties.Settings.Default.mycolorMAIN = Color.FromArgb(191, 255, 232);
            pn_top.BackColor = Color.FromArgb(84, 128, 129);
            Library_Mnagement_System.Properties.Settings.Default.mycolorTOP = Color.FromArgb(84, 128, 129);
            pn_T.BackColor = Color.FromArgb(144, 232, 197);
            Library_Mnagement_System.Properties.Settings.Default.mycolorTITEL = Color.FromArgb(144, 232, 197);
            Library_Mnagement_System.Properties.Settings.Default.Save();
        }
        private void btn_pn_store_cat_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pn_top.BackColor = dialog.Color;
                Library_Mnagement_System.Properties.Settings.Default.mycolorTOP = dialog.Color;
                Library_Mnagement_System.Properties.Settings.Default.Save();
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pn_main.BackColor = dialog.Color;
                Library_Mnagement_System.Properties.Settings.Default.mycolorMAIN = dialog.Color;
                Library_Mnagement_System.Properties.Settings.Default.Save();
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pn_T.BackColor = dialog.Color;
                Library_Mnagement_System.Properties.Settings.Default.mycolorTITEL = dialog.Color;
                Library_Mnagement_System.Properties.Settings.Default.Save();
            }
        }
        private void print_report_cat()
        {
            Reporting.report_cat report_Cat = new Reporting.report_cat();
            report_Cat.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_Cat.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_Cat.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_Cat.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_Cat.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_Cat.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_Cat.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_Cat.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_Cat.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_Cat.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_Cat.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_Cat.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_Cat.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_seels()
        {
            Reporting.report_seels report_seels = new Reporting.report_seels();
            report_seels.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_seels.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_seels.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_seels.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_seels.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_seels.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_seels.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_seels.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_seels.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_seels.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_seels.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_seels.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_seels.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_customers()
        {
            Reporting.report_customers report_scustomers = new Reporting.report_customers();
            report_scustomers.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_scustomers.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_scustomers.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_scustomers.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_scustomers.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_scustomers.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_scustomers.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_scustomers.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_scustomers.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_scustomers.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_scustomers.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_scustomers.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_scustomers.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_books()
        {
            Reporting.report_books report_boos = new Reporting.report_books();
            report_boos.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_boos.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_boos.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_boos.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_boos.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_boos.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_boos.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_boos.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_boos.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_boos.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_boos.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_boos.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_boos.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_poro()
        {
            Reporting.report_poro report_poro = new Reporting.report_poro();
            report_poro.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_poro.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_poro.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_poro.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_poro.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_poro.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_poro.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_poro.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_poro.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_poro.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_poro.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_poro.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_poro.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_book_limit()
        {
            Reporting.print_report_book_limit report_book_limit = new Reporting.print_report_book_limit();
            report_book_limit.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_limit.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_limit.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_limit.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_limit.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_limit.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_limit.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_limit.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_limit.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_limit.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_book_limit.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_book_limit.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_book_limit.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_book_poro()
        {
            Reporting.report_book_poro report_book_poro = new Reporting.report_book_poro();
            report_book_poro.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_poro.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_poro.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_poro.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_poro.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_poro.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_poro.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_poro.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_poro.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_poro.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_book_poro.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_book_poro.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_book_poro.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_book_tody()
        {
            Reporting.report_book_return_today report_book_return = new Reporting.report_book_return_today();
            report_book_return.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_return.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_return.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_return.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_return.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_return.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_return.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_return.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_return.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_return.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_book_return.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_book_return.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_book_return.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void print_report_book_pdf()
        {
            Reporting.report_book_pdf report_book_pdf = new Reporting.report_book_pdf();
            report_book_pdf.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_pdf.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_pdf.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_pdf.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_pdf.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_pdf.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_pdf.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_pdf.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_pdf.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_pdf.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_book_pdf.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_book_pdf.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_book_pdf.ExportToDocx(opd2.FileName);
                }
            }
        }
        public void print_report_book_poro_custmer()
        {
            DataTable ds = new DataTable();
            ds = class_boro.book_poro_students(number_card, "غير مستعاد");
            Reporting.report_book_poro_cust report_book_poro_cust = new Reporting.report_book_poro_cust();
            report_book_poro_cust.DataSource = ds;
            report_book_poro_cust.label1.Text = lb_mainsystem.Text;
            report_book_poro_cust.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_poro_cust.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_poro_cust.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_poro_cust.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_poro_cust.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_poro_cust.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_poro_cust.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_poro_cust.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_poro_cust.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_poro_cust.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_book_poro_cust.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_book_poro_cust.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_book_poro_cust.ExportToDocx(opd2.FileName);
                }
            }
        }
        string TE;
        public void print_report_bbok_inside_cat()
        {
            DataTable ds = new DataTable();
            ds = class_cat.load_books_inside_cat(id_Cat);
            Reporting.report_books_inside_cat report_books_inside_cat = new Reporting.report_books_inside_cat();
            report_books_inside_cat.DataSource = ds;
            report_books_inside_cat.label1.Text = lb_mainsystem.Text;
            report_books_inside_cat.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_books_inside_cat.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_books_inside_cat.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_books_inside_cat.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_books_inside_cat.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_books_inside_cat.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_books_inside_cat.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_books_inside_cat.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_books_inside_cat.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_books_inside_cat.xrTableCell4.Text = obj4.ToString();
            if (TE == "pdf")
            {
                SaveFileDialog opd = new SaveFileDialog();
                var res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    opd.FileName = "" + opd.FileName + ".pdf";
                    report_books_inside_cat.ExportToPdf(opd.FileName);
                }
            }
            else if (TE == "Exel")
            {
                SaveFileDialog opd1 = new SaveFileDialog();
                var res1 = opd1.ShowDialog();

                if (res1 == DialogResult.OK)
                {
                    opd1.FileName = "" + opd1.FileName + ".Xlsx";
                    report_books_inside_cat.ExportToXlsx(opd1.FileName);
                }
            }
            else if (TE == "Word")
            {
                SaveFileDialog opd2 = new SaveFileDialog();
                var res2 = opd2.ShowDialog();

                if (res2 == DialogResult.OK)
                {
                    opd2.FileName = "" + opd2.FileName + ".Docx";
                    report_books_inside_cat.ExportToDocx(opd2.FileName);
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (state == "CAT")
            {
                TE = "pdf";
                print_report_cat();
            }
            else if (state == "CAT1")
            {
                TE = "pdf";
                print_report_bbok_inside_cat();
            }
            else if (state == "seels")
            {
                TE = "pdf";
                print_report_seels();
            }
            else if (state == "customers")
            {
                TE = "pdf";
                print_report_customers();
            }
            else if (state == "books")
            {
                TE = "pdf";
                print_report_books();
            }
            else if (state == "boro")
            {
                TE = "pdf";
                print_report_poro();
            }
            else if (state == "book_poro_limit")
            {
                TE = "pdf";
                print_report_book_limit();
            }
            else if (state == "book_poro_today")
            {
                TE = "pdf";
                print_report_book_tody();
            }
            else if (state == "book_poro_tajawz")
            {
                TE = "pdf";
                print_report_book_poro();
            }
            else if (state == "bookpdf")
            {
                TE = "pdf";
                print_report_book_pdf();
            }
            else if (state == "book_poro_students")
            {
                TE = "pdf";
                print_report_book_poro_custmer();
            }
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (state == "CAT")
            {
                TE = "Exel";
                print_report_cat();
            }
            else if (state == "CAT1")
            {
                TE = "Exel";
                print_report_bbok_inside_cat();
            }
            else if (state == "seels")
            {
                TE = "Exel";
                print_report_seels();
            }
            else if (state == "customers")
            {

                TE = "Exel";
                print_report_customers();
            }
            else if (state == "books")
            {
                TE = "Exel";
                print_report_books();
            }
            else if (state == "boro")
            {
                TE = "Exel";
                print_report_poro();
            }
            else if (state == "book_poro_limit")
            {
                TE = "Exel";
                print_report_book_limit();
            }
            else if (state == "book_poro_today")
            {
                TE = "Exel";
                print_report_book_tody();
            }
            else if (state == "book_poro_tajawz")
            {
                TE = "Exel";
                print_report_book_poro();
            }
            else if (state == "bookpdf")
            {
                TE = "Exel";
                print_report_book_pdf();
            }
            else if (state == "book_poro_students")
            {
                TE = "Exel";
                print_report_book_poro_custmer();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (state == "CAT")
            {
                TE = "Word";
                print_report_cat();
            }
            else if (state == "CAT1")
            {
                TE = "Word";
                print_report_bbok_inside_cat();
            }
            else if (state == "seels")
            {
                TE = "Word";
                print_report_seels();
            }
            else if (state == "customers")
            {
                TE = "Word";
                print_report_customers();
            }
            else if (state == "books")
            {
                TE = "Word";
                print_report_books();
            }
            else if (state == "boro")
            {
                TE = "Word";
                print_report_poro();
            }
            else if (state == "book_poro_limit")
            {
                TE = "Word";
                print_report_book_limit();
            }
            else if (state == "book_poro_today")
            {
                TE = "Word";
                print_report_book_tody();
            }
            else if (state == "book_poro_tajawz")
            {
                TE = "Word";
                print_report_book_poro();
            }
            else if (state == "bookpdf")
            {
                TE = "Word";
                print_report_book_pdf();
            }
            else if (state == "book_poro_students")
            {
                TE = "Word";
                print_report_book_poro_custmer();
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            state = "book_poro_today";
            FRM_MAIN_Activated(sender, e);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            state = "book_poro_limit";
            FRM_MAIN_Activated(sender, e);
        }

        private void btn_book_pdf_Click(object sender, EventArgs e)
        {
            state = "bookpdf";
            FRM_MAIN_Activated(sender, e);
        }
        private void btn_add_pdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "|*.pdf;*.txt";
            var res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                using (Stream strem = File.OpenRead(ofd.FileName))
                {
                    byte[] buffer = new byte[strem.Length];
                    strem.Read(buffer, 0, buffer.Length);
                    var fi = new FileInfo(ofd.FileName);
                    string extn = fi.Extension;
                    string name = fi.Name;
                    string qu = "INSERT INTO PDF (Data,EX,FIlename)VALUES(@Data,@extn,@name)";
                    using (SqlConnection cn = GetCon())
                    {
                        SqlCommand cmd = new SqlCommand(qu, cn);
                        cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value = buffer;
                        cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            state = "message";
            FRM_MAIN_Activated(sender, e);
            lb_mainsystem.Text = "البريد الصادر";
        }
        private void btn_send_message_Click(object sender, EventArgs e)
        {
            presentation_layer_format.FRM_connect_lib message = new presentation_layer_format.FRM_connect_lib();
            message.id = 0;
            if (lb_prim_main.Text == "مسؤول مبيعات" || lb_prim_main.Text == "مسؤول اعارة" || lb_prim_main.Text == "مدخل بيانات")
            {
                if (state == "book_poro_today" || state == "book_poro_limit")
                {
                    var date1 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
                    var date2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
                    string name_book = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    string isbn_book = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    string name_borrow = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    lb_mainsystem.Text = "التواصل مع المستعير";
                    message.txt_number.Visible = false;
                    message.label11.Visible = false;
                    message.combo_message_for.Enabled = false;
                    message.combo_message_for.Text = "زائر";
                    message.txt_type_message.Text = "طلب ارجاع الكتاب لتجاوز المدة المحددة";
                    message.txt_info.Text = "السيد " + name_borrow + " " +
                        "لقد قمت باستعارة الكتاب  " + name_book + " ذو الرقم العالمي  " + isbn_book + " في تاريخ  " + date1 + " وتم الاتفاق على تاريخ " + date2 + " لتقوم بإرجاع الكتاب ونود اعلامك بتجاوزك التاريخ المذكور نرجو مراجعة مسؤول الاستعارة او مدير المكتبة لإرجاع الكتاب او تجديد الاستعارة ولكم جزل الشكر  ";
                    message.txt_name.Text = lb_name_main.Text;
                    message.txt_type_sender.Text = lb_prim_main.Text;
                    message.comboBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    message.comboBox1.Enabled = false;
                    message.txt_name_cust.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    message.txt_name_cust.Enabled = false;
                    message.panel6.Visible = true;
                }
                else
                {
                    lb_mainsystem.Text = " التواصل مع لمدير";
                    message.txt_number.Visible = false;
                    message.label11.Visible = false;
                    message.combo_message_for.Enabled = false;
                    message.txt_name.Text = lb_name_main.Text;
                    message.combo_message_for.Text = "مدير";
                    message.txt_type_sender.Text = lb_prim_main.Text;
                }
            }
            else if (lb_prim_main.Text == "زائر")
            {
                message.txt_number.Visible = true;
                message.label11.Visible = true;
                lb_mainsystem.Text = " يسرنا تواصلك معنا";
                message.txt_name.Text = name_customers;
                message.txt_number.Text = number_card_log_in;
                message.txt_type_sender.Text = type_cust;
                message.combo_message_for.Text = "مدير";
                message.combo_message_for.Enabled = false;
            }
            else if (lb_prim_main.Text == "مدير")
            {
                if (state == "book_poro_today" || state == "book_poro_limit")
                {
                    var date1 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
                    var date2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
                    string name_book= Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    string isbn_book = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    string name_borrow = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    lb_mainsystem.Text = "التواصل مع المستعير";
                    message.txt_number.Visible = false;
                    message.label11.Visible = false;
                    message.combo_message_for.Enabled = false;
                    message.combo_message_for.Text = "زائر";
                    message.txt_type_message.Text = "طلب ارجاع الكتاب لتجاوز المدة المحددة";
                    message.txt_info.Text = "السيد "+name_borrow+" " +
                        "لقد قمت باستعارة الكتاب  "+name_book+" ذو الرقم العالمي  "+isbn_book+" في تاريخ  " + date1 + " وتم الاتفاق على تاريخ " + date2 + " لتقوم بإرجاع الكتاب ونود اعلامك بتجاوزك التاريخ المذكور نرجو مراجعة مسؤول الاستعارة او مدير المكتبة لإرجاع الكتاب او تجديد الاستعارة ولكم جزل الشكر  ";
                    message.txt_name.Text = lb_name_main.Text;
                    message.txt_type_sender.Text = lb_prim_main.Text;
                    message.comboBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    message.comboBox1.Enabled = false;
                    message.txt_name_cust.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    message.txt_name_cust.Enabled = false;
                    message.panel6.Visible = true;
                }
                else
                {
                    message.txt_name_cust.Enabled = false;
                    message.panel6.Visible = false;
                    message.comboBox1.Enabled = true;
                    lb_mainsystem.Text = "التواصل مع الاداريين و العملاء";
                    message.txt_number.Visible = false;
                    message.label11.Visible = false;
                    message.combo_message_for.Enabled = true;
                    message.txt_name.Text = lb_name_main.Text;
                    message.txt_type_sender.Text = lb_prim_main.Text;
                }
            }
            pn_home.Visible = false;
            pn_main.Visible = false;
            pn_order.Controls.Clear();
            pn_order.Controls.Add(message.panel13);
            pn_order.Visible = true;
        }
        private void btn_message_unread_Click(object sender, EventArgs e)
        {
            if (lb_prim_main.Text == "مدير")
            {
                state = "message_unread";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "مدخل بيانات")
            {
                state = "message_unread_data_entray";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "مسؤول اعارة")
            {
                state = "message_unread_borrow_manager";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "مسؤول مبيعات")
            {

                state = "message_unread_seels_manager";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "زائر")
            {
                state = "message_unread_customers";
                FRM_MAIN_Activated(sender, e);
            }
            lb_mainsystem.Text = "الرسائل الواردة غير المقروءة";
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {

            if (lb_prim_main.Text == "مدير")
            {
                state = "message_unread_type";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "مدخل بيانات")
            {
                state = "message_unread_data_entray_type";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "مسؤول اعارة")
            {
                state = "message_unread_borrow_manager_type";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "مسؤول مبيعات")
            {

                state = "message_unread_seels_manager_type";
                FRM_MAIN_Activated(sender, e);
            }
            else if (lb_prim_main.Text == "زائر")
            {
                state = "message_unread_customers_type";
                FRM_MAIN_Activated(sender, e);
            }
            lb_mainsystem.Text = "الرسائل الصادرة غير المقروءة";
        }

        private void btn_message_for_Click(object sender, EventArgs e)
        {
            state = "message_type";
            FRM_MAIN_Activated(sender, e);
            lb_mainsystem.Text = "البريد الوارد";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
