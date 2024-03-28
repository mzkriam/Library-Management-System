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
    public partial class FRM_Return_book : Form
    {
        Business_layer_class.cls_seels class_seels = new Business_layer_class.cls_seels();
        Business_layer_class.cls_boro class_boro = new Business_layer_class.cls_boro();
        public string isbn;
        public string number_card;
        public int id;
        public string state;
        public FRM_Return_book()
        {
            InitializeComponent();
        }
        private void btn_add_boro_Click(object sender, EventArgs e)
        {
            if (state == "poro")
            {
                DataTable dt = new DataTable();
                dt = class_boro.select_num(isbn);
                object o = dt.Rows[0]["num_book_avilable"];
                int num_book = Convert.ToInt32(o);
                int new_num_book = num_book + 1;
                DataTable dt1 = new DataTable();
                dt1 = class_boro.select_card(number_card);
                object o1 = dt1.Rows[0]["num_book_pro"];
                int num_poro = Convert.ToInt32(o1);
                int new_num_book_poro = num_poro - 1;
                dt = class_boro.update_return_poro(isbn, new_num_book, number_card, new_num_book_poro, "مستعاد", id);
                MessageBox.Show("تمت عملية الاستعادة بنجاح", "عملية مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (state == "seels")
            {
                DataTable dt = new DataTable();
                dt = class_boro.select_num(isbn);
                object o = dt.Rows[0]["num_book_avilable"];
                int num_book = Convert.ToInt32(o);
                int new_num_book = num_book + 1;
                class_boro.update_number_book(new_num_book, isbn);
                class_seels.delete_seels(id);
                MessageBox.Show("تمت عملية الاستعادة بنجاح", "عملية مكتملة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
    