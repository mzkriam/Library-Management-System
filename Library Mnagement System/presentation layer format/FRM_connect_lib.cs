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
using System.Data.SqlClient;

namespace Library_Mnagement_System.presentation_layer_format
{
    public partial class FRM_connect_lib : Form
    {
        public FRM_connect_lib()
        {
            InitializeComponent();
        }
        static string path = "";
        public string number_card;
        public int id;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pn_message.Visible = false;
        }
        //add pict
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (id == 0)
                {

                    lb_message.Text = "الرجاء الانتظار ...!";
                    pic_update.Visible = true;
                    pic_errore.Visible = false;
                    pic_dell.Visible = false;
                    pn_message.Visible = true;
                    Stream stream = null;
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "PNG & JPG & JPEG & IMG Files|*.png;*.jpg;*.img*.jpeg;";
                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        if ((stream = ofd.OpenFile()) != null)
                        {
                            pic_message.Load(ofd.FileName);
                            linkLabel1.Visible = false;
                        }
                    }
                    lb_message.Text = "تمت العملية بنجاح";
                    pic_update.Visible = false;
                    pic_errore.Visible = false;
                    pic_dell.Visible = true;
                    pn_message.Visible = true;
                    panel15.Visible = true;
                }
                else
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "PNG & JPG & JPEG & IMG Files | *.png; *.jpg; *.img *.jpeg; ";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        pic_message.Image.Save(save.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FRM_info_lib_Load(object sender, EventArgs e)
        {

        }
        //add pdf
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (id == 0)
            {
                lb_message.Text = "الرجاء الانتظار ...!";
                pic_update.Visible = true;
                pic_errore.Visible = false;
                pic_dell.Visible = false;
                pn_message.Visible = true;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "|*.pdf;*.txt";
                ofd.ShowDialog();
                path = ofd.FileName;
                txt_name_pdf.Text = path;
                linkLabel2.Visible = false;
                lb_message.Text = "تمت العملية بنجاح";
                pic_update.Visible = false;
                pic_errore.Visible = false;
                pic_dell.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                using (SqlConnection cn = GetCon())
                {
                    string Q = "select Id,file_name,EX_pdf,pdf from TP_connect_with_lib where Id=@id";
                    SqlCommand cmd = new SqlCommand(Q, cn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader["file_name"].ToString();
                        var data = (byte[])reader["pdf"];
                        string extn = reader["EX_pdf"].ToString();
                        string newfilename = name.Replace(extn, DateTime.Now.ToString("ddMMyyyy")) + extn;
                        File.WriteAllBytes(newfilename, data);
                        System.Diagnostics.Process.Start(newfilename);
                    }
                }
            }
        }
        private SqlConnection GetCon()
        {
            return new SqlConnection(@"Data Source=DESKTOP-6N1SK7T\ZKARIA2019;Initial Catalog=LMS;Integrated Security=True");
        }
        private void btn_add_boro_Click(object sender, EventArgs e)
        {
            if (txt_type_sender.Text == combo_message_for.Text)
            {
                lb_message.Text = "الرجاء تحديد مستلم الرسالة";
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else if (combo_message_for.Text == "")
            {
                lb_message.Text = "الرجاء تحديد مستلم الرسالة";
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else if (txt_info.Text == "" || txt_type_message.Text == "")
            {
                lb_message.Text = "الرجاء تحديد نوع الرسالة وكتابة مضمونها";
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else if (combo_message_for.Text != "مدير" && txt_name_cust.Text == "")
            {

                lb_message.Text = "الرجاء تحديد مستلم الرسالة";
                pic_errore.Visible = true;
                pn_message.Visible = true;
            }
            else
            {
                lb_message.Text = "";
                lb_message.Text = "الرجاء الانتظار ...!";
                pic_update.Visible = true;
                pic_errore.Visible = false;
                pic_dell.Visible = false;
                pn_message.Visible = true;
                //not null image and not null pdf
                if (pic_message.Image != null && txt_name_pdf.Text != "")
                {
                    using (SqlConnection cn = GetCon())
                    {
                        MemoryStream ms = new MemoryStream();
                        pic_message.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] pic = ms.ToArray();
                        using (Stream strem = File.OpenRead(path))
                        {
                            string qu = "INSERT INTO TP_connect_with_lib (name_sender,type_sender,info_message,message_for,type_message,state_message,cover,pdf,EX_pdf,file_name,number_card_sender,number_card_recipient,name_recipient)VALUES(@name_sender,@type_sender,@info_message,@message_for,@type_message,@state_message,@cover,@pdf,@extn,@name,@number_card_sender,@number_card_recipient,@name_recipient)";
                            SqlCommand cmd = new SqlCommand(qu, cn);
                            byte[] buffer = new byte[strem.Length];
                            strem.Read(buffer, 0, buffer.Length);
                            var fi = new FileInfo(path);
                            string extn = fi.Extension;
                            string name = fi.Name;
                            cmd.Parameters.AddWithValue("@cover", pic);
                            cmd.Parameters.Add("@pdf", SqlDbType.VarBinary).Value = buffer;
                            cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                            cmd.Parameters.Add("@number_card_sender", SqlDbType.NVarChar).Value = txt_number.Text;
                            cmd.Parameters.Add("@number_card_recipient", SqlDbType.NVarChar).Value = comboBox1.Text;
                            cmd.Parameters.Add("@name_recipient", SqlDbType.NVarChar).Value = txt_name_cust.Text;
                            cmd.Parameters.Add("@name_sender", SqlDbType.NVarChar).Value = txt_name.Text;
                            cmd.Parameters.Add("@type_sender", SqlDbType.NVarChar).Value = txt_type_sender.Text;
                            cmd.Parameters.Add("@info_message", SqlDbType.NVarChar).Value = txt_info.Text;
                            cmd.Parameters.Add("@message_for", SqlDbType.NVarChar).Value = combo_message_for.Text;
                            cmd.Parameters.Add("@type_message", SqlDbType.NVarChar).Value = txt_type_message.Text;
                            cmd.Parameters.Add("@state_message", SqlDbType.NVarChar).Value = "غير مقروءة";
                            if (cn.State == ConnectionState.Closed)
                            {
                                cn.Open();
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                //null image and null pdf
                else if (pic_message.Image == null && txt_name_pdf.Text == "")
                {
                    using (SqlConnection cn = GetCon())
                    {
                        string qu = "INSERT INTO TP_connect_with_lib (name_sender,number_card_sender,type_sender,info_message,message_for,type_message,state_message,number_card_recipient,name_recipient)VALUES(@name_sender,@number_card_sender,@type_sender,@info_message,@message_for,@type_message,@state_message,@number_card_recipient,@name_recipient)";
                        SqlCommand cmd = new SqlCommand(qu, cn);
                        cmd.Parameters.Add("@name_sender", SqlDbType.NVarChar).Value = txt_name.Text;
                        cmd.Parameters.Add("@number_card_sender", SqlDbType.NVarChar).Value = txt_number.Text;
                        cmd.Parameters.Add("@number_card_recipient", SqlDbType.NVarChar).Value = comboBox1.Text;
                        cmd.Parameters.Add("@name_recipient", SqlDbType.NVarChar).Value = txt_name_cust.Text;
                        cmd.Parameters.Add("@type_sender", SqlDbType.NVarChar).Value = txt_type_sender.Text;
                        cmd.Parameters.Add("@info_message", SqlDbType.NVarChar).Value = txt_info.Text;
                        cmd.Parameters.Add("@message_for", SqlDbType.NVarChar).Value = combo_message_for.Text;
                        cmd.Parameters.Add("@type_message", SqlDbType.NVarChar).Value = txt_type_message.Text;
                        cmd.Parameters.Add("@state_message", SqlDbType.NVarChar).Value = "غير مقروءة";

                        if (cn.State == ConnectionState.Closed)
                        {
                            cn.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                //null image and not null pdf
                else if (pic_message.Image == null && txt_name_pdf.Text != "")
                {
                    using (SqlConnection cn = GetCon())
                    {
                        using (Stream strem = File.OpenRead(path))
                        {
                            string qur = "INSERT INTO TP_connect_with_lib (name_sender,type_sender,info_message,message_for,type_message,state_message,pdf,EX_pdf,file_name,number_card_recipient,name_recipient)VALUES(@name_sender,@type_sender,@info_message,@message_for,@type_message,@state_message,@pdf,@extn,@name,@number_card_recipient,@name_recipient)";
                            SqlCommand cmdd = new SqlCommand(qur, cn);
                            byte[] buffer = new byte[strem.Length];
                            strem.Read(buffer, 0, buffer.Length);
                            var fi = new FileInfo(path);
                            string extn = fi.Extension;
                            string name = fi.Name;
                            cmdd.Parameters.Add("@pdf", SqlDbType.VarBinary).Value = buffer;
                            cmdd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                            cmdd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                            cmdd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                            cmdd.Parameters.Add("@number_card_sender", SqlDbType.NVarChar).Value = txt_number.Text;
                            cmdd.Parameters.Add("@number_card_recipient", SqlDbType.NVarChar).Value = comboBox1.Text;
                            cmdd.Parameters.Add("@name_sender", SqlDbType.NVarChar).Value = txt_name.Text;
                            cmdd.Parameters.Add("@type_sender", SqlDbType.NVarChar).Value = txt_type_sender.Text;
                            cmdd.Parameters.Add("@info_message", SqlDbType.NVarChar).Value = txt_info.Text;
                            cmdd.Parameters.Add("@message_for", SqlDbType.NVarChar).Value = combo_message_for.Text;
                            cmdd.Parameters.Add("@type_message", SqlDbType.NVarChar).Value = txt_type_message.Text;
                            cmdd.Parameters.Add("@state_message", SqlDbType.NVarChar).Value = "غير مقروءة";
                            if (cn.State == ConnectionState.Closed)
                            {
                                cn.Open();
                            }
                            cmdd.ExecuteNonQuery();
                        }
                    }
                }
                //not null image and null pdf
                else if (pic_message.Image != null && txt_name_pdf.Text == "")
                {
                    {
                        using (SqlConnection cn = GetCon())
                        {
                            MemoryStream ms = new MemoryStream();
                            pic_message.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] pic = ms.ToArray();
                            string qur = "INSERT INTO TP_connect_with_lib (name_sender,type_sender,info_message,message_for,type_message,state_message,cover,number_card_recipient,name_recipient)VALUES(@name_sender,@type_sender,@info_message,@message_for,@type_message,@state_message,@cover,@number_card_recipient,@name_recipient)";
                            SqlCommand cmdd = new SqlCommand(qur, cn);
                            cmdd.Parameters.AddWithValue("@cover", pic);
                            cmdd.Parameters.Add("@number_card_sender", SqlDbType.NVarChar).Value = txt_number.Text;
                            cmdd.Parameters.Add("@number_card_recipient", SqlDbType.NVarChar).Value = comboBox1.Text;
                            cmdd.Parameters.Add("@name_sender", SqlDbType.NVarChar).Value = txt_name.Text;
                            cmdd.Parameters.Add("@type_sender", SqlDbType.NVarChar).Value = txt_type_sender.Text;
                            cmdd.Parameters.Add("@info_message", SqlDbType.NVarChar).Value = txt_info.Text;
                            cmdd.Parameters.Add("@message_for", SqlDbType.NVarChar).Value = combo_message_for.Text;
                            cmdd.Parameters.Add("@type_message", SqlDbType.NVarChar).Value = txt_type_message.Text;
                            cmdd.Parameters.Add("@state_message", SqlDbType.NVarChar).Value = "غير مقروءة";
                            if (cn.State == ConnectionState.Closed)
                            {
                                cn.Open();
                            }
                            cmdd.ExecuteNonQuery();
                        }
                    }
                }
                lb_message.Text = "تمت العملية بنجاح";
                pic_update.Visible = false;
                pic_errore.Visible = false;
                pic_dell.Visible = true;
                pn_message.Visible = true;
                txt_info.Text = "";
                combo_message_for.Text = "";
                comboBox1.Text = "";
                path = "";
                txt_name_pdf.Text = "";
                pic_message.Image = null;
                txt_type_message.Text = "";
            End:
                ;
            }
        }      
        private void error()
        {
            lb_message.Text = "الرجاء اختيار العميل";
            pic_update.Visible = false;
            pic_errore.Visible = true;
            pic_dell.Visible = false;
            pn_message.Visible = true;
        }
        Business_layer_class.cls_customers class_cust = new Business_layer_class.cls_customers();
        Business_layer_class.cls_user class_user = new Business_layer_class.cls_user();
        private void combo_message_for_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_message_for.Text == "زائر")
            {
                comboBox1.Items.Clear();
                DataTable dt = new DataTable();
                dt = class_cust.load_number_card_cust_to_message();
                object[] obj = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj[i] = dt.Rows[i]["number_card"];
                }
                comboBox1.Items.AddRange(obj);
                panel6.Visible = true;
            }                       
            else if(combo_message_for.Text == "مسؤول مبيعات"|| combo_message_for.Text == "مسؤول اعارة"|| combo_message_for.Text == "مدخل بيانات")
            {
                comboBox1.Items.Clear();
                DataTable dt = new DataTable();
                dt = class_user.load_NO_to_message(combo_message_for.Text);
                object[] obj = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    obj[i] = dt.Rows[i]["cuser"];
                }
                comboBox1.Items.AddRange(obj);
                panel6.Visible = true;
            }    
            else
            {
                panel6.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_message_for.Text == "زائر")
            {
                DataTable dt = new DataTable();
                string name = comboBox1.Text;
                dt = class_cust.load_name_cust_to_message(name);
                object obj = dt.Rows[0]["name"];
                txt_name_cust.Text = obj.ToString();
            }
            else
            {
                DataTable dt = new DataTable();
                string name = comboBox1.Text;
                dt = class_user.load_name_to_message(comboBox1.Text);
                object obj = dt.Rows[0]["cname"];
                txt_name_cust.Text = obj.ToString();                       
            }
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
       
    
    
    