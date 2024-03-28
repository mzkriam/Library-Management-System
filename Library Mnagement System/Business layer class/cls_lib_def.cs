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
    class cls_lib_def
    {
        data_access_layer.CALL_DAL dal = new data_access_layer.CALL_DAL();
        public void insert_info_lib(string libname, string libemail, string libphone, string libdef, string lib_address, string libphone2,MemoryStream ms)
        {
            //libname,libemail,libphone,libdef,lib_address,libphone2
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter("libname", libname);
            pr[1] = new SqlParameter("libemail", libemail);
            pr[2] = new SqlParameter("libphone", libphone);
            pr[3] = new SqlParameter("libdef", libdef);
            pr[4] = new SqlParameter("libaddress", lib_address);
            pr[5] = new SqlParameter("libphone2", libphone2);
            pr[6] = new SqlParameter("cover", ms.ToArray());
            dal.open();
            dal.excute("p_insert_info_lib", pr);
            dal.close();

        }
        public DataTable def()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = dal.read("p_select_def_wel", pr);
            return dt;
        }
        public DataTable load_info()
        {
            DataTable dt = new DataTable();
            SqlParameter[] pr = null;
            dt = dal.read("p_load_info_lib", pr);
            return dt;
        }
    }
}
