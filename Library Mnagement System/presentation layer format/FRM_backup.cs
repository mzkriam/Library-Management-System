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

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class FRM_backup : Form
    {
        int move;
        int movex;
        int movey;

        //for backup database
        string DBNAME;
        string DBbath;
        string DBrestore;
      

        public FRM_backup()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_mainsystem_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movex = e.X;
            movey = e.Y;
        }

        private void lb_mainsystem_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movex, MousePosition.Y - movey);
            }
        }

        private void lb_mainsystem_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                DBNAME = ofd.FileName;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var res = fbd.ShowDialog();
            {
                if (res == DialogResult.OK)
                {
                    DBbath = fbd.SelectedPath;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBNAME + ";Integrated Security=True");
                string FNAME = DBbath + "\\DBLMS";
                string query = "BACKUP DATABASE [" + DBNAME + "] TO DISK ='" + FNAME + " .bak' ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم اخذ نسخة احتياطية", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            var res = opf.ShowDialog();
            if (res == DialogResult.OK)
            {
                DBrestore = opf.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            try
            {
                presentation_layer_format.FRM_MAIN fm = new FRM_MAIN();
                fm.Enabled = false;
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBNAME + ";Integrated Security=True");
                string qurey = "ALTER DATABASE [" + DBNAME + "] SET OFFLINE WITH ROLLBACK IMMEDIATE;RESTORE DATABASE [" + DBNAME + "] FROM DISK = '" + DBrestore + "'";
                SqlCommand cmd = new SqlCommand(qurey, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم اخذ استعادة النسخة الاحتياطية", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fm.Enabled = true;
            }     
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
