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
    class cls_seels
    {
        data_access_layer.CALL_DAL cal_da = new data_access_layer.CALL_DAL();

        public DataTable load_seels()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = cal_da.read("p_load_seels",pr);
            return dt;
        }
        public void insert(string Sname_customer, string Snumber_card_customer, string Stitel_book, string Sisbn, string Sdate, float Sprise,int id_book,int id_customer)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter("Sname_customer", Sname_customer);
            pr[1] = new SqlParameter("Snumber_card_customer", Snumber_card_customer);
            pr[2] = new SqlParameter("Stitel_book", Stitel_book);
            pr[3] = new SqlParameter("Sisbn", Sisbn);
            pr[4] = new SqlParameter("Sdate", Sdate);
            pr[5] = new SqlParameter("Sprise", Sprise);
            pr[6] = new SqlParameter("id_book", id_book);
            pr[7] = new SqlParameter("id_customer", id_customer);
            cal_da.open();
            cal_da.excute("p_insert_sell", pr);
            cal_da.close();
        }
        public void update(string Sname_customer, string Snumber_card_customer, string Stitel_book,string Sisbn ,string Sdate, int Sprise, int id ,int id_book, int id_customer) 
        { 
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter("Sname_customer", Sname_customer);
            pr[1] = new SqlParameter("Snumber_card_customer", Snumber_card_customer);
            pr[2] = new SqlParameter("Stitel_book", Stitel_book);
            pr[3] = new SqlParameter("Sisbn", Sisbn);
            pr[4] = new SqlParameter("Sdate", Sdate);
            pr[5] = new SqlParameter("Sprise", Sprise);
            pr[6] = new SqlParameter("id", id);
            pr[7] = new SqlParameter("id_book", id_book);
            pr[8] = new SqlParameter("id_customer", id_customer);
            cal_da.open();
            cal_da.excute("p_update_seels", pr);
            cal_da.close();
        }
        public void delete_seels(int id)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            cal_da.open();
            cal_da.excute("p_delete_seels", pr);
            cal_da.close();
        }
        public DataTable search(string search)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("search", search);
            dt = cal_da.read("p_search_seels", pr);
            return dt;
        }
        public DataTable update_edite_sell(string number_isbn, int new_num_book_avilable)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("number_isbn", number_isbn);
            pr[1] = new SqlParameter("new_num_book_avilable", new_num_book_avilable);
            cal_da.open();
            cal_da.open();
            dt = cal_da.read("p_update_edite_sell", pr);
            cal_da.close();
            return dt;
        }
        public DataTable update_seel(int id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("id", id);
            dt = cal_da.read("p_select_edite_seel", pr);
            return dt;
        }
    }
}
