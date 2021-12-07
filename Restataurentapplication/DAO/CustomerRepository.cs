using Restataurentapplication.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.DAO
{
    public class CustomerRepository : ICustomer
    {
        public List<Models.CustomerModel> GetAllCustomerType(string strConn)
        {
            List<Models.CustomerModel> CustomerDetails = new List<Models.CustomerModel>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataTable dtData = new DataTable();
                SqlCommand cmd = new SqlCommand("[GetAllCustomer]", connection);//Procedure Name 
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // cmd.Parameters.AddWithValue("@iActionId", StrActionId);
                SqlDataAdapter dba = new SqlDataAdapter(cmd);
                dba.Fill(dtData);
                cmd.Parameters.Clear();
                CustomerDetails = CommonMethods.ConvertDataTable<Models.CustomerModel>(dtData);
                return CustomerDetails;
            }
        }

    }
}
