using Restataurentapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.Interface
{
    public interface IOrderdetails
    {
        List<OrderDetailsModel> GetorderdetailByid(int CustomerID, string strConn);
    }
}
