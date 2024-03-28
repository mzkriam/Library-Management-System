using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class FRM_reports : Form
    {
        public FRM_reports()
        {
            InitializeComponent();
        }
        presentation_layer_format.FRM_MAIN FM = new presentation_layer_format.FRM_MAIN();
        Business_layer_class.cls_user class_user = new Business_layer_class.cls_user();
        Business_layer_class.cls_BOOKS class_book = new Business_layer_class.cls_BOOKS();
        Business_layer_class.cls_boro class_poro = new Business_layer_class.cls_boro();
        Business_layer_class.cls_customers class_customer = new Business_layer_class.cls_customers();
        Business_layer_class.cls_seels class_seel = new Business_layer_class.cls_seels();
        presentation_layer_class.cls_cat class_cat = new presentation_layer_class.cls_cat();
        Reporting.report_all report = new Reporting.report_all();
        private void btn_pn_store_cat_Click(object sender, EventArgs e)
        {
            Reporting.report_cat report_Cat = new Reporting.report_cat();
            report_Cat.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_Cat.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_Cat.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_Cat.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_Cat.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_Cat.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_Cat.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {

                opd.FileName = "" + opd.FileName + ".pdf";
                report_Cat.ExportToPdf(opd.FileName);
            }
        }
        private void btn_report_Click(object sender, EventArgs e)
        {
            Reporting.report_seels report_seels = new Reporting.report_seels();
            report_seels.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_seels.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_seels.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_seels.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_seels.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_seels.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_seels.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {

                opd.FileName = "" + opd.FileName + ".pdf";
                report_seels.ExportToPdf(opd.FileName);
            }
        }
        private void btn_suppliers_Click(object sender, EventArgs e)
        {
            Reporting.report_customers report_scustomers = new Reporting.report_customers();
            report_scustomers.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_scustomers.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_scustomers.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_scustomers.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_scustomers.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_scustomers.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_scustomers.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {

                opd.FileName = "" + opd.FileName + ".pdf";
                report_scustomers.ExportToPdf(opd.FileName);
            }
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            Reporting.report_books report_boos = new Reporting.report_books();
            report_boos.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_boos.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_boos.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_boos.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_boos.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_boos.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_boos.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {

                opd.FileName = "" + opd.FileName + ".pdf";
                report_boos.ExportToPdf(opd.FileName);
            }
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            Reporting.report_poro report_poro = new Reporting.report_poro();
            report_poro.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_poro.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_poro.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_poro.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_poro.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_poro.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_poro.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {

                opd.FileName = "" + opd.FileName + ".pdf";
                report_poro.ExportToPdf(opd.FileName);
            }
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            ////number of books in form main
            DataTable dt1 = new DataTable();
            dt1 = class_book.load_book();
            report.xrLabel7.Text = dt1.Rows.Count.ToString();
            ////number of boro in form main
            DataTable dt2 = new DataTable();
            dt2 = class_poro.load();
            report.xrLabel10.Text = dt2.Rows.Count.ToString();
            ////number of cat in form main
            DataTable dt3 = new DataTable();
            dt3 = class_cat.load();
            report.xrLabel12.Text = dt3.Rows.Count.ToString();
            ////number of seels in form main
            DataTable dt4 = new DataTable();
            dt4 = class_seel.load_seels();
            report.xrLabel9.Text = dt4.Rows.Count.ToString();
            ////number of customer in form main
            DataTable dt5 = new DataTable();
            dt5 = class_customer.load_customers();
            report.xrLabel8.Text = dt5.Rows.Count.ToString();
            ////number of user in form main
            DataTable dt6 = new DataTable();
            dt6 = class_user.load_user();
            report.xrLabel11.Text = dt6.Rows.Count.ToString();
            report.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {
                opd.FileName = "" + opd.FileName + ".pdf";
                report.ExportToPdf(opd.FileName);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Reporting.report_book_poro report_book_poro = new Reporting.report_book_poro();
            report_book_poro.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_poro.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_poro.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_poro.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_poro.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_poro.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_poro.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_poro.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_poro.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_poro.xrTableCell4.Text = obj4.ToString();
            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {
                opd.FileName = "" + opd.FileName + ".pdf";
                report_book_poro.ExportToPdf(opd.FileName);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Reporting.report_book_return_today report_book_return = new Reporting.report_book_return_today();
            report_book_return.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_return.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_return.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_return.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_return.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_return.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_return.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_return.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_return.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_return.xrTableCell4.Text = obj4.ToString();

            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {
                opd.FileName = "" + opd.FileName + ".pdf";
                report_book_return.ExportToPdf(opd.FileName);
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Reporting.print_report_book_limit report_book_limit = new Reporting.print_report_book_limit();
            report_book_limit.xrTableCell5.Text = Library_Mnagement_System.Properties.Settings.Default.lib_name;
            report_book_limit.xrTableCell6.Text = Library_Mnagement_System.Properties.Settings.Default.lib_address;
            report_book_limit.xrPictureBox1.Image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            report_book_limit.vendorPhone.Text = Library_Mnagement_System.Properties.Settings.Default.lib_phone1;
            report_book_limit.vendorEmail.Text = Library_Mnagement_System.Properties.Settings.Default.lib_facebook;
            report_book_limit.vendorWebsite.Text = Library_Mnagement_System.Properties.Settings.Default.lib_email;
            DataTable dt = new DataTable();
            dt = class_user.start(FM.lb_name_main.Text);
            object obj1 = dt.Rows[0]["cname"];
            report_book_limit.xrTableCell1.Text = obj1.ToString();
            object obj2 = dt.Rows[0]["cprim"];
            report_book_limit.xrTableCell3.Text = obj2.ToString();
            object obj3 = dt.Rows[0]["caddress"];
            report_book_limit.xrTableCell2.Text = obj3.ToString();
            object obj4 = dt.Rows[0]["cphone"];
            report_book_limit.xrTableCell4.Text = obj4.ToString();

            SaveFileDialog opd = new SaveFileDialog();
            var res = opd.ShowDialog();
            if (res == DialogResult.OK)
            {
                opd.FileName = "" + opd.FileName + ".pdf";
                report_book_limit.ExportToPdf(opd.FileName);
            }
        }
    }
}