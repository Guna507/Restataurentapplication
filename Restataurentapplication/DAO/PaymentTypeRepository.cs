using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Restataurentapplication.Interface;

namespace Restataurentapplication.DAO
{
    public class PaymentTypeRepository : IPaymentType
    {
        
        public List<Models.PaymentTypeModel> GetAllPaymentType(string strConn)
        {
            List<Models.PaymentTypeModel> patientDetails = new List<Models.PaymentTypeModel>();
            
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataTable dtData = new DataTable();
                SqlCommand cmd = new SqlCommand("[GetAllPaymentTypes]", connection);//Procedure Name 
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // cmd.Parameters.AddWithValue("@iActionId", StrActionId);
                SqlDataAdapter dba = new SqlDataAdapter(cmd);
                dba.Fill(dtData);
                cmd.Parameters.Clear();
                patientDetails = CommonMethods.ConvertDataTable<Models.PaymentTypeModel>(dtData);
                return patientDetails;
            }
        }


    }
}
