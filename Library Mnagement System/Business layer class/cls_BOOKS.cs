using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Library_Mnagement_System.Business_layer_class
{
    class cls_BOOKS
    {
        data_access_layer.CALL_DAL call_dal = new data_access_layer.CALL_DAL();
        public DataTable load_book()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_book", pr);
            return dt;
        }
        public DataTable load_pdf()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_select_pdf", pr);
            return dt;
        }
        public DataTable load_book_poro()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_boro", pr);
            return dt;
        }
        public DataTable loadcat()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = call_dal.read("p_load_cat_to_compobox", pr);
            return dt;
        }
        //insert_book_into_DB
        public void insert(string number_isbn, string title, string auther, string price, string date , int rate, MemoryStream cover, string cat,string def_book,string state_book,string lang_book,string Publisher, string investigator, int num_book,int num_folders_in_book,int num_book_avilable,string position_book, string about_book,string book_for,int id_cat)
        {
            SqlParameter[] pr = new SqlParameter[20];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            pr[1] = new SqlParameter("TITLE", title);
            pr[2] = new SqlParameter("ATHER", auther);
            pr[3] = new SqlParameter("PRICE", price);
            pr[4] = new SqlParameter("DATE", date);
            pr[5] = new SqlParameter("RATE", rate);
            pr[6] = new SqlParameter("COVER", cover.ToArray());
            pr[7] = new SqlParameter("CAT", cat);
            pr[8] = new SqlParameter("def_book", def_book);
            pr[9] = new SqlParameter("state_book", state_book);
            pr[10] = new SqlParameter("lang_book", lang_book);
            pr[11] = new SqlParameter("name_na", Publisher);//الناشر 
            pr[12] = new SqlParameter("name_mo", investigator); //المحقق / المترجم 
            pr[13] = new SqlParameter("num_book", num_book);
            pr[14] = new SqlParameter("num_folders_in_book", num_folders_in_book);
            pr[15] = new SqlParameter("num_book_avilable", num_book_avilable);
            pr[16] = new SqlParameter("position_book", position_book);
            pr[17] = new SqlParameter("about_book", about_book);
            pr[18] = new SqlParameter("book_for", book_for);
            pr[19] = new SqlParameter("id_cat", id_cat);
            call_dal.open();
            call_dal.excute("p_add_books", pr);
            call_dal.close();
        }
        public DataTable update_books(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = call_dal.read("p_selectedite", pr);
            return dt;
        }

                      
        public void updatebooks(int id,string number_isbn, string title, string auther, string price, string date, int rate, MemoryStream cover, string cat, string def_book, string state_book, string lang_book, string Publisher, string investigator, int num_book, int num_folders_in_book, int num_book_avilable,string position_book, string about_book, string book_for,int id_cat)
        {
            SqlParameter[] pr = new SqlParameter[21];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            pr[1] = new SqlParameter("TITLE", title);
            pr[2] = new SqlParameter("ATHER", auther);
            pr[3] = new SqlParameter("PRICE", price);
            pr[4] = new SqlParameter("DATE", date);
            pr[5] = new SqlParameter("RATE", rate);
            pr[6] = new SqlParameter("COVER", cover.ToArray());
            pr[7] = new SqlParameter("CAT", cat);
            pr[8] = new SqlParameter("def_book", def_book);
            pr[9] = new SqlParameter("state_book", state_book);
            pr[10] = new SqlParameter("lang_book", lang_book);
            pr[11] = new SqlParameter("name_na", Publisher);//الناشر 
            pr[12] = new SqlParameter("name_mo", investigator); //المحقق / المترجم 
            pr[13] = new SqlParameter("num_book", num_book);
            pr[14] = new SqlParameter("num_folders_in_book", num_folders_in_book);
            pr[15] = new SqlParameter("num_book_avilable", num_book_avilable);
            pr[16] = new SqlParameter("position_book", position_book);
            pr[17] = new SqlParameter("about_book", about_book);
            pr[18] = new SqlParameter("book_for", book_for);
            pr[19] = new SqlParameter("Id", id);
            pr[20] = new SqlParameter("id_cat", id_cat);
            call_dal.open();
            call_dal.excute("p_updatebooks", pr);
            call_dal.close();
        }
        public void delete_book(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@id", id);
            call_dal.open();
            call_dal.excute("p_delete_book", pr);
            call_dal.close();
        }
        public void delete_pdf(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@id", id);
            call_dal.open();
            call_dal.excute("p_delete_pdf", pr);
            call_dal.close();
        }
        public DataTable search(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_books", pr);
            return dt;

        }
        public DataTable search_pdf(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_pdf", pr);
            return dt;
        }
        public DataTable load_for_seels()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_books_for_seels", pr);
            return dt;
        }
        public DataTable search_for_seels(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_books_for_seels", pr);
            return dt;
        }
        public DataTable load_prise(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = call_dal.read("p_load_prise_books_for_seels", pr);
            return dt;
        }
        public DataTable check_isbn_book(string number_isbn)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            dt = call_dal.read("p_check_isbn_book", pr);            
            return dt;
        }
        public DataTable select_id_cat(string CAT_NAME)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            dt = call_dal.read("p_select_id_cat", pr);
            return dt;
        }
    }
}
