using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Library_Mnagement_System.presentation_layer_class
{
    class cls_cat
    {
        data_access_layer.CALL_DAL call_dal = new data_access_layer.CALL_DAL();
        public DataTable load()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("PR_LOAD_CAT", pr);
            return dt;   
        }
        public DataTable load_for_delet(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = call_dal.read("p_view_for_delete", pr);
            return dt;
        }
        public void insert(string cat_name)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("CAT_NAME", cat_name);
            call_dal.open();
            call_dal.excute("P_ADD_CAT", pr);
            call_dal.close();
        }
        public void update(string cat_name,int Id)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cat_name", cat_name);
            pr[1] = new SqlParameter("ID", Id);
            call_dal.open();
            call_dal.excute("P_cat_update", pr);
            call_dal.close();
        }
        public void delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            call_dal.open();
            call_dal.excute("P_DELETE_CAT", pr);
            call_dal.close();
        } 
        public DataTable search(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter []pr=new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            dt = call_dal.read("P_SEARCH_CAT", pr);
            return dt;
        }
        public DataTable load_books_inside_cat(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = call_dal.read("load_books_inside_cat", pr);
            return dt;
        }
        public DataTable search_books_inside_cat( string search, int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("id", id);
            dt = call_dal.read("search_books_inside_cat", pr);
            return dt;
        }        
        public DataTable select_book_name(string name_cat,int id_cat)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("name_cat", name_cat);
            pr[1] = new SqlParameter("id_cat", id_cat);
            dt = call_dal.read("update_name_cat_in_books", pr);
            return dt;
        }
        public DataTable check_name_cat(string CAT_NAME)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);           
            dt = call_dal.read("p_check_CAT_NAME", pr);
            return dt;
        }

    }
}
