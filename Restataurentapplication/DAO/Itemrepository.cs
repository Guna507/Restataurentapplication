using Restataurentapplication.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.DAO
{
    public class Itemrepository : IItemTypes
    {
        public List<Models.ItemModel> GetAllitems(string strConn)
        {
            List<Models.ItemModel> ItemDetails = new List<Models.ItemModel>();

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataTable dtData = new DataTable();
                SqlCommand cmd = new SqlCommand("GetAllItems", connection);//Procedure Name 
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                // cmd.Parameters.AddWithValue("@iActionId", StrActionId);
                SqlDataAdapter dba = new SqlDataAdapter(cmd);
                dba.Fill(dtData);
                cmd.Parameters.Clear();
                ItemDetails = CommonMethods.ConvertDataTable<Models.ItemModel>(dtData);
                return ItemDetails;
            }
        }

        public decimal GetItempricebyitem(string strConn,int stritemid)
        {
            // List<Models.ItemModel> ItemDetails = new List<Models.ItemModel>();
            string stritemprice = string.Empty;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataTable dtData = new DataTable();
                SqlCommand cmd = new SqlCommand("Getitempricebyitem", connection);//Procedure Name 
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                 cmd.Parameters.AddWithValue("@itemid", stritemid);
                //SqlDataAdapter dba = new SqlDataAdapter(cmd);
                //dba.Fill(dtData);
                stritemprice=cmd.ExecuteScalar().ToString();
                cmd.Parameters.Clear();
                // ItemDetails = CommonMethods.ConvertDataTable<Models.ItemModel>(dtData);
                decimal ditem = decimal.Parse(stritemprice, CultureInfo.InvariantCulture);
                return ditem;
            }
        }

    }
}
