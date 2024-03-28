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
    class cls_boro
    {
        data_access_layer.CALL_DAL cal_dal = new data_access_layer.CALL_DAL();

        public DataTable load()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = cal_dal.read("p_load_boro", pr);
            return dt;
        }
        public DataTable load_t(string state)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("state", state);
            dt = cal_dal.read("p_load_book_boro_ta", pr);
            return dt;
        }
        public void insert_data(string bname_customer, string pnumber_card_customer, string btitel_book, string bisbn, string bdate1, string bdate2, int Bprise, string state_boro,int id_book,int id_cutomers)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter("bname_customer", bname_customer);
            pr[1] = new SqlParameter("pnumber_card_customer", pnumber_card_customer);
            pr[2] = new SqlParameter("btitel_book", btitel_book);
            pr[3] = new SqlParameter("bisbn", bisbn);
            pr[4] = new SqlParameter("bdate1", bdate1);
            pr[5] = new SqlParameter("bdate2", bdate2);
            pr[6] = new SqlParameter("Bprise", Bprise);
            pr[7] = new SqlParameter("state_boro", state_boro);
            pr[8] = new SqlParameter("@id_book", id_book);
            pr[9] = new SqlParameter("@id_cutomers", id_cutomers);
            cal_dal.open();
            cal_dal.excute("p_insert_boro", pr);
            cal_dal.close();
        }
        public void update(int id, string bname_customer, string pnumber_card_customer, string btitel_book, string bisbn, string bdate1, string bdate2, int Bprise,int id_book,int id_customers)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter("id", id);
            pr[1] = new SqlParameter("bname_customer", bname_customer);
            pr[2] = new SqlParameter("pnumber_card_customer", pnumber_card_customer);
            pr[3] = new SqlParameter("btitel_book", btitel_book);
            pr[4] = new SqlParameter("bisbn", bisbn);
            pr[5] = new SqlParameter("bdate1", bdate1);
            pr[6] = new SqlParameter("bdate2", bdate2);
            pr[7] = new SqlParameter("Bprise", Bprise);
            pr[8] = new SqlParameter("id_book", id_book);
            pr[9] = new SqlParameter("id_customers", id_customers);
            cal_dal.open();
            cal_dal.excute("p_update_boro", pr);
            cal_dal.close();
        }       
        public DataTable search_boro(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = cal_dal.read("p_search_boro", pr);
            return dt;
        }
        public DataTable search_book_boro_ta(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = cal_dal.read("p_search_book_boro_ta", pr);
            return dt;
        }
        public DataTable search_book_limit_date(string search,string state,DateTime date)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("date", date);
            pr[2] = new SqlParameter("state", state);
            dt = cal_dal.read("p_search_book_limit_date", pr);
            return dt;
        }
        public DataTable search_book_limit(string search, string state, DateTime date)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("search", search);
            pr[1] = new SqlParameter("date", date);
            pr[2] = new SqlParameter("state", state);
            dt = cal_dal.read("p_search_book_limit", pr);
            return dt;
        }
        public DataTable search_book_poro_customer(string pnumber_card_customer, string state_boro, string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("pnumber_card_customer", pnumber_card_customer);
            pr[1] = new SqlParameter("state_boro", state_boro);
            pr[2] = new SqlParameter("search", search);
            dt = cal_dal.read("p_search_book_poro_customer", pr);
            return dt;
        }
        public DataTable book_poro_students(string pnumber_card_customer,string state_boro)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("pnumber_card_customer", pnumber_card_customer);
            pr[1] = new SqlParameter("state_boro", state_boro);
            dt = cal_dal.read("book_poro_students", pr);
            return dt;
        }
        public DataTable update_boro(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = cal_dal.read("p_select_edite_boro", pr);
            return dt;
        }
        public void update_number_book(int new_number, string num_isbn)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("num_isbn", num_isbn);
            pr[1] = new SqlParameter("new_number", new_number);
            cal_dal.open();
            cal_dal.excute("p_update_number_book", pr);
            cal_dal.close();
        }
        public DataTable select_num(string number_isbn)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            cal_dal.open();
            dt = cal_dal.read("p_select_num_book", pr);
            cal_dal.close();
            return dt;
        }
        public DataTable select_card(string number_card)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("number_card", number_card);
            cal_dal.open();
            dt = cal_dal.read("p_select_num_book_pro", pr);
            cal_dal.close();
            return dt;
        }
        public void update_number_poro(int new_number, string number_card)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("number_card", number_card);
            pr[1] = new SqlParameter("new_number", new_number);
            cal_dal.open();
            cal_dal.excute("p_update_number_poro", pr);
            cal_dal.close();
        }      
        public DataTable update_edite_poro(string number_isbn, int new_num_book_avilable, string number_card, int new_num_book_poro)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            pr[1] = new SqlParameter("new_num_book_avilable", new_num_book_avilable);
            pr[2] = new SqlParameter("number_card", number_card);
            pr[3] = new SqlParameter("new_num_book_poro", new_num_book_poro);
            cal_dal.open();
            dt = cal_dal.read("p_update_edite_poro", pr);
            cal_dal.close();
            return dt;
        }
        public void delete_poro(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            cal_dal.open();
            cal_dal.excute("p_delete_poro", pr);
            cal_dal.close();
        }
        public DataTable update_return_poro(string number_isbn, int new_num_book_avilable, string number_card, int new_num_book_poro,string state_boro,int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            pr[1] = new SqlParameter("new_num_book_avilable", new_num_book_avilable);
            pr[2] = new SqlParameter("number_card", number_card);
            pr[3] = new SqlParameter("new_num_book_poro", new_num_book_poro);
            pr[4] = new SqlParameter("state_boro", state_boro);
            pr[5] = new SqlParameter("id", id);
            cal_dal.open();
            dt = cal_dal.read("p_update_return_poro", pr);
            cal_dal.close();
            return dt;
        }
        public DataTable select_same_poro(string bisbn,string pnumber_card_customer,string state_boro)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("bisbn", bisbn);
            pr[1] = new SqlParameter("pnumber_card_customer", pnumber_card_customer);
            pr[2] = new SqlParameter("state_boro", state_boro);
            cal_dal.open();
            dt = cal_dal.read("p_select_same_poro", pr);
            cal_dal.close();
            return dt;
        }
        public DataTable select_same_book(string bisbn, string pnumber_card_customer, string state_boro)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("bisbn", bisbn);
            pr[1] = new SqlParameter("pnumber_card_customer", pnumber_card_customer);
            pr[2] = new SqlParameter("state_boro", state_boro);
            cal_dal.open();
            dt = cal_dal.read("p_select_same_book", pr);
            cal_dal.close();
            return dt;
        }
        public DataTable select_book_limit_date(DateTime date,string state)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("date", date);
            pr[1] = new SqlParameter("state", state);
            cal_dal.open();
            dt = cal_dal.read("p_select_book_limit_date", pr);
            cal_dal.close();
            return dt;
        }
        public DataTable select_book_limit(DateTime date, string state)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("date", date);
            pr[1] = new SqlParameter("state", state);
            cal_dal.open();
            dt = cal_dal.read("p_select_book_limit", pr);
            cal_dal.close();
            return dt;
        }
    }
}
