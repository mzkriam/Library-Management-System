using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class frm_star : SplashScreen
    {
        presentation_layer_format.FRM_WELCOM fw = new FRM_WELCOM();
        public frm_star()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © " + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {

        }
        private void frm_star_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
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
            timer1.Stop();
            this.Hide();
            fw.Show();
        }
    }
}
  
