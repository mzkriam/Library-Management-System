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
    class cls_customers
    {
        data_access_layer.CALL_DAL call_dal = new data_access_layer.CALL_DAL();
         public DataTable load_customers()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_customers", pr);
            return dt;
        }
        public DataTable load_number_card_cust_to_message()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = call_dal.read("p_load_cust_to_message", pr);
            return dt;
        }
        public DataTable load_name_cust_to_message(string number_card)
        {           
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_card", number_card);
            dt = call_dal.read("p_load_name_cust_for_message", pr);
            return dt;
        }
        public void insert_customers(string cust_name,string cust_loc,string number_card, string phone,string eamil , string info_cust, string dep,MemoryStream cover,string type_cust,int num_book_pro,string state)
        {
            SqlParameter[] pr = new SqlParameter[11];
            pr[0] = new SqlParameter("name", cust_name);
            pr[1] = new SqlParameter("location", cust_loc);
            pr[2] = new SqlParameter("number_card", number_card);
            pr[3] = new SqlParameter("phone",phone);
            pr[4] = new SqlParameter("email",eamil);
            pr[5] = new SqlParameter("info_cust", info_cust);
            pr[6] = new SqlParameter("department",dep);
            pr[7] = new SqlParameter("cover",cover.ToArray());
            pr[8] = new SqlParameter("type_cust", type_cust);
            pr[9] = new SqlParameter("num_book_pro", num_book_pro);
            pr[10] = new SqlParameter("state_customer", state);
            call_dal.open();
            call_dal.excute("p_insert_customers", pr);
            call_dal.close();
        }
        public DataTable select_update_customers(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@id", id);
            dt = call_dal.read("p_select_update_customers", pr);
            return dt;
        }
        public void update_customers(string name , string location,string number_card, string phone,string email,string info_cust,string department,MemoryStream cover,int id,string type_cust)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter("name", name);
            pr[1] = new SqlParameter("location", location);
            pr[2] = new SqlParameter("number_card", number_card);
            pr[3] = new SqlParameter("phone", phone);
            pr[4] = new SqlParameter("email", email);
            pr[5] = new SqlParameter("info_cust", info_cust);
            pr[6] = new SqlParameter("department", department);
            pr[7] = new SqlParameter("cover", cover.ToArray());
            pr[8] = new SqlParameter("Id", id);
            pr[9] = new SqlParameter("type_cust", type_cust);
            call_dal.open();
            call_dal.excute("p_update_customers", pr);
            call_dal.close();
        }
        public void delete_customers(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            call_dal.open();
            call_dal.excute("p_delete_customer", pr);
            call_dal.close();
        }
       public DataTable search_customers(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter []pr= new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_customers", pr);
            return dt;
        }
        public DataTable load_for_seels()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_customers_for_seels", pr);
            return dt;
        }
        public DataTable search_for_seels(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_customers_for_seels", pr);
            return dt;
        }
        public DataTable check_number_card_customers(string number_card)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@number_card", number_card);
            dt = call_dal.read("p_check_number_card_customers", pr);
            return dt;
        }
        public DataTable log_in(string name, string number_card)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("number_card", number_card);
            pr[1] = new SqlParameter("name", name);
            dt = call_dal.read("p_log_in_customer", pr);
            return dt;
        }
        public void update_state_for_login(string name, string number_card)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("name", name);
            pr[1] = new SqlParameter("number_card", number_card);
            call_dal.open();
            call_dal.excute("pr_update_customer_login", pr);
            call_dal.close();
        }
        public void update_state_for_logout(string name, string number_card)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("name", name);
            pr[1] = new SqlParameter("number_card", number_card);
            call_dal.open();
            call_dal.excute("pr_update_customer_logout", pr);
            call_dal.close();
        }
    }
}
