using Restataurentapplication.Interface;
using Restataurentapplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.DAO
{
    public class OrderDetailsRepository : IOrderdetails
    {
        public Int64 Getorderdetailid(string strConn, int stritemid)
        {
            // List<Models.ItemModel> ItemDetails = new List<Models.ItemModel>();
            Int64 Orderdetailsid;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataTable dtData = new DataTable();
                SqlCommand cmd = new SqlCommand("Getorderdetailid", connection);//Procedure Name 
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@itemid", stritemid);
                //SqlDataAdapter dba = new SqlDataAdapter(cmd);
                //dba.Fill(dtData);
                Orderdetailsid = Convert.ToInt64(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                // ItemDetails = CommonMethods.ConvertDataTable<Models.ItemModel>(dtData);
                //decimal ditem = decimal.Parse(stritemprice, CultureInfo.InvariantCulture);
                return Orderdetailsid;
            }
        }

        public List<OrderDetailsModel> GetorderdetailByid(int CustomerID,string strConn)
        {
            //try
           // {
                List<OrderDetailsModel> objlistOrderDetailsModel = new List<OrderDetailsModel>();
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    DataTable dtData = new DataTable();
                    SqlCommand cmd = new SqlCommand("[Getorderdetails]", connection);//Procedure Name 
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@CustomerId", CustomerID);
                    SqlDataAdapter dba = new SqlDataAdapter(cmd);
                    dba.Fill(dtData);
                    cmd.Parameters.Clear();
                    objlistOrderDetailsModel = CommonMethods.ConvertDataTable<OrderDetailsModel>(dtData);
                    // return objlistOrderDetailsModel;
                }
                return objlistOrderDetailsModel;
          //  }
            //catch(Exception ex)
            //{
            //    return ex.Message;
            //}
        }
    }
}
