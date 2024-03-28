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
    public partial class FRM_CAT : Form
    {
        public int id;
        presentation_layer_class.cls_cat call_class_cat = new presentation_layer_class.cls_cat();
        public FRM_CAT()
        {
            InitializeComponent();
        }

        private void btn_closee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_cat.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم الصنف ", "متطلبات الادخال", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else 
            {
                if (id == 0)
                {
                    //add
                    DataTable dt = new DataTable();
                    dt = call_class_cat.check_name_cat(txt_cat.Text);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("اسم الصنف موجود من قبل", "صنف مكرر", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        call_class_cat.insert(txt_cat.Text);
                        MessageBox.Show("تم ادخال الصنف الجديد بنجاح", "ادخال صنف جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
                else
                {
                    //edite
                    DataTable dt = new DataTable();
                    dt = call_class_cat.check_name_cat(txt_cat.Text);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("اسم الصنف موجود من قبل", "صنف مكرر", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = call_class_cat.select_book_name(txt_cat.Text, id);
                        call_class_cat.update(txt_cat.Text, id);
                        this.Close();
                        MessageBox.Show("تم تعديل بيانات الصنف الجديد بنجاح", "تعديل صنف ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
