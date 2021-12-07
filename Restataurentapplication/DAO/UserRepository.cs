using Restataurentapplication.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.DAO
{
    public class UserRepository : IUser
    {
        public List<Models.LoginModel> GetuserDetails(string strConn,string strUserName,string strPassword)
        {
            List<Models.LoginModel> loginDetails = new List<Models.LoginModel>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataTable dtData = new DataTable();
                SqlCommand cmd = new SqlCommand("GetLoginUser", connection);//Procedure Name 
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                 cmd.Parameters.AddWithValue("@UserName", strUserName);
                cmd.Parameters.AddWithValue("@Password", strPassword);
                SqlDataAdapter dba = new SqlDataAdapter(cmd);
                dba.Fill(dtData);
                cmd.Parameters.Clear();
                loginDetails = CommonMethods.ConvertDataTable<Models.LoginModel>(dtData);
                return loginDetails;
            }
        }
    }
}
