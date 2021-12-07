using Restataurentapplication.DAO;
using Restataurentapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.Interface
{
    public  interface IPaymentType 
    {
             List<PaymentTypeModel> GetAllPaymentType(string connectionString);
            

    }
}
