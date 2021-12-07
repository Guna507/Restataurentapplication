using Restataurentapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.Interface
{
    public interface IUser
    {
        public List<LoginModel> GetuserDetails(string connectionString, string strUserName, string strPassword);
    }
}
