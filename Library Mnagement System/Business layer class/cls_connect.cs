using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Library_Mnagement_System.Business_layer_class
{
    class cls_connect
    {
        data_access_layer.CALL_DAL call_dal = new data_access_layer.CALL_DAL();
        public DataTable load()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_message_in_lib", pr);
            return dt;
        }
        public DataTable search_in_message_for_manager(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_in_lib", pr);
            return dt;
        }
        public DataTable load_type()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_load_message_in_lib_type", pr);
            return dt;
        }
        public DataTable search_type(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_in_lib_type", pr);
            return dt;
        }
        public DataTable load_message_unread()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_select_message_unread", pr);
            return dt;
        }
        public DataTable load_message_unread_type()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("p_select_message_unread_type", pr);
            return dt;
        }
        public DataTable search_message_unread_type(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_type", pr);
            return dt;
        }
        public DataTable load_message_data_entray_unread_type(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_select_message_unread_data_entray_type", pr);
            return dt;
        }
        public DataTable search_message_data_entray_unread_type(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_data_entray_type", pr);
            return dt;
        }
        public DataTable load_message_borrow_manager_unread_type(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_select_message_unread_borrow_manager_type", pr);
            return dt;
        }
        public DataTable search_message_borrow_manager_unread_type(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_borrow_manager_type", pr);
            return dt;
        }
        public DataTable load_message_seels_manager_unread_type(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_select_message_unread_seels_manager_type", pr);
            return dt;
        }
        public DataTable search_message_seels_manager_unread_type(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_seels_manager_type", pr);
            return dt;
        }
        public DataTable load_message_unread_data_entray(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_select_message_unread_data_entray", pr);
            return dt;
        }
        public DataTable load_message_unread_borow_manager(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_select_message_unread_borrow_manager", pr);
            return dt;
        }
        public DataTable load_message_unread_seels_manager(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_select_message_unread_seels_manager", pr);
            return dt;
        }
        public DataTable load_message_for_seels_manager(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_selecte_message_for_seels_manager", pr);
            return dt;
        }
        public DataTable search_message_for_seels_manager(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_seels_manager", pr);
            return dt;
        }
        public DataTable load_message_for_seels_manager_type(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_selecte_message_for_seels_manager_type", pr);
            return dt;
        }
        public DataTable search_message_for_seels_manager_type(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_seels_manager_type", pr);
            return dt;
        }
        public DataTable load_message_for_borrow_manager(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_selecte_message_for_borrow_manager", pr);
            return dt;
        }
        public DataTable search_message_for_borrow_manager(string cuser,string @search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_borrow_manager", pr);
            return dt;
        }
        public DataTable seaarh_message_for_borrow_manager_type(string cuser, string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_borrow_manager_type", pr);
            return dt;
        }
        public DataTable load_message_for_borrow_manager_type(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_selecte_message_for_borrow_manager_type", pr);
            return dt;
        }
        public DataTable load_message_for_data_entry(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_selecte_message_for_data_entray", pr);
            return dt;
        }
        public DataTable search_message_for_data_entry(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_data_entray", pr);
            return dt;
        }
        public DataTable load_message_for_data_entry_type(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_selecte_message_for_data_entray_type", pr);
            return dt;
        }
        public DataTable search_message_for_data_entry_type(string cuser,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_data_entray_type", pr);
            return dt;
        }
        public DataTable load_message_for_customer(string number_card_sender)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_card_sender", number_card_sender);
            dt = call_dal.read("p_selecte_message_for_customers", pr);
            return dt;
        }
        public DataTable search_message_for_customer(string number_card_sender,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("number_card_sender", number_card_sender);
            dt = call_dal.read("p_search_message_for_customers", pr);
            return dt;
        }
        public DataTable load_message_for_customer_type(string number_card_recipient)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_card_recipient", number_card_recipient);
            dt = call_dal.read("p_selecte_message_for_customers_type", pr);
            return dt;
        }
        public DataTable search_message_for_customer_type(string number_card_recipient,string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("number_card_recipient", number_card_recipient);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_for_customers_type", pr);
            return dt;
        }
        public DataTable load_message_unread_for_customer(string number_card_recipient)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_card_recipient", number_card_recipient);
            dt = call_dal.read("p_selecte_message_unread_for_customers", pr);
            return dt;
        }
        public DataTable load_message_unread_for_customer_type(string number_card_sender)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_card_sender", number_card_sender);
            dt = call_dal.read("p_selecte_message_unread_for_customers_type", pr);
            return dt;
        }
        public DataTable search_message_unread_for_customer_type(string number_card_sender, string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("number_card_sender", number_card_sender);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_for_customers_type", pr);
            return dt;
        }

        public void delete(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            call_dal.open();
            call_dal.excute("p_delete_message", pr);
            call_dal.close();
        }
        public DataTable load_message(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = call_dal.read("p_load_message", pr);
            return dt;
        }
        public void update_state(int id,string message_for) 
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("id", id);
            pr[1] = new SqlParameter("message_for", message_for);
            call_dal.open();
            call_dal.excute("p_update_state_message", pr);
            call_dal.close();
        }
        public DataTable search_message_manger_unread(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_for_manager", pr);
            return dt;
        }
        public DataTable search_message_data_entray_unread(string search,string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_search_message_unread_data_entray", pr);
            return dt;
        }
        public DataTable search_message_borrow_manager_unread(string search, string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_search_message_unread_borrow_manager", pr);
            return dt;
        }
        public DataTable search_message_seels_manager_unread(string search,string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_message_unread_seels_manager", pr);
            return dt;
        }
        public DataTable search_message_customers_unread(string search, string @number_card_recipient)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("number_card_recipient", @number_card_recipient);
            dt = call_dal.read("p_search_message_unread_for_customers", pr);
            return dt;
        }
    }
}
