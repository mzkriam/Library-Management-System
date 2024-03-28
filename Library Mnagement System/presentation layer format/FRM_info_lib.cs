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
    public partial class FRM_info_lib : Form
    {  
        public FRM_info_lib()
        {
            InitializeComponent();
        }
        string fileloc;
        static string path = "";
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
        private void btn_add_boro_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != "")
                {
                    Library_Mnagement_System.Properties.Settings.Default.lib_name = txt_namelib.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_address = txt_address.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_email = txt_email.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_facebook = txt_facebook.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_info = txt_def.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_instgrame = txt_instgrame.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_phone1 = txt_phone1.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_phone2 = txt_phone2.Text;
                    Library_Mnagement_System.Properties.Settings.Default.cover = path;
                    Library_Mnagement_System.Properties.Settings.Default.Save();
                    Image image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
                    pic_lib.Image = image;
                }
                else
                {
                    Library_Mnagement_System.Properties.Settings.Default.lib_name = txt_namelib.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_address = txt_address.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_email = txt_email.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_facebook = txt_facebook.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_info = txt_def.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_instgrame = txt_instgrame.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_phone1 = txt_phone1.Text;
                    Library_Mnagement_System.Properties.Settings.Default.lib_phone2 = txt_phone2.Text;
                    Library_Mnagement_System.Properties.Settings.Default.cover = path;
                    Library_Mnagement_System.Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            fileloc = "";
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "PNG & JPG & IMG Files|*.png;*.jpg;*.img";
            var res = opf.ShowDialog();           
            if (res == DialogResult.OK)
            {
                pic_lib.Image = Image.FromFile(opf.FileName);
                fileloc = opf.FileName;
            }
            path = fileloc;
        }
        private void FRM_info_lib_Load(object sender, EventArgs e)
        {
            fileloc = Library_Mnagement_System.Properties.Settings.Default.cover;
            if (fileloc != "")
            {
                Image image = Image.FromFile(Library_Mnagement_System.Properties.Settings.Default.cover);
            }
        }
    }
}
    