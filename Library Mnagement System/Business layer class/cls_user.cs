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
    class cls_user
    {
        data_access_layer.CALL_DAL call_dal = new data_access_layer.CALL_DAL();
        public DataTable load_user()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = call_dal.read("Pr_load_user", pr);
            return dt;
        }
        public DataTable load_NO_to_message(string cprim)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cprim", cprim);
            dt = call_dal.read("p_load_no_to_message", pr);
            return dt;
        }
        public DataTable load_name_to_message(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_load_namee_to_message", pr);
            return dt;
        }
        public void insert_user(string cname, string cuser, string cpassward, string cprem, string cstate, MemoryStream ccover, string cphone, string cemail, string caddress)
        {
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter("cname", cname);
            pr[1] = new SqlParameter("cuser", cuser);
            pr[2] = new SqlParameter("cpassward", cpassward);
            pr[3] = new SqlParameter("cprem", cprem);
            pr[4] = new SqlParameter("cstate", cstate);
            pr[5] = new SqlParameter("ccover", ccover.ToArray());
            pr[6] = new SqlParameter("cphone", cphone);
            pr[7] = new SqlParameter("cemail", cemail);
            pr[8] = new SqlParameter("caddress", caddress);
            call_dal.open();
            call_dal.excute("p_insert_user", pr);
            call_dal.close();
        }
        public DataTable load_update(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = call_dal.read("p_select_update_user", pr);
            return dt;
        }
        public void delete_user(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            call_dal.open();
            call_dal.excute("p_delete_user", pr);
            call_dal.close();
        }
        public void update_user(string cname, string cuser, string cpassward, string cprem, MemoryStream ccover, int id, string cphone, string cemail, string caddress)
        {
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter("id", id);
            pr[1] = new SqlParameter("cname", cname);
            pr[2] = new SqlParameter("cuser", cuser);
            pr[3] = new SqlParameter("cpassward", cpassward);
            pr[4] = new SqlParameter("cprem", cprem);
            pr[5] = new SqlParameter("ccover", ccover.ToArray());
            pr[6] = new SqlParameter("cphone", cphone);
            pr[7] = new SqlParameter("cemail", cemail);
            pr[8] = new SqlParameter("caddress", caddress);
            call_dal.open();
            call_dal.excute("p_update_user", pr);
            call_dal.close();
        }
        public DataTable search_user(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = call_dal.read("p_search_user", pr);
            return dt;
        }

        public DataTable logout(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_update_state_in_user_logout", pr);
            return dt;
        }        
        public DataTable login_select(string cuser, string cpassword)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("cpassword", cpassword);
            dt = call_dal.read("pr_select_login", pr);
            return dt;
        }
        public void update_state_for_login(string cuser, string cpassword)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("cuser", cuser);
            pr[1] = new SqlParameter("cpassword", cpassword);
            call_dal.open();
            call_dal.excute("pr_update_user_login", pr);
            call_dal.close();
        }
        public DataTable start(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("pr_start", pr);
            return dt;
        }
        public DataTable check_have_user(string cuser)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("cuser", cuser);
            dt = call_dal.read("p_check_have_user", pr);
            return dt;
        }       
    }
}

