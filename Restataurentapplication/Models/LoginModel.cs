using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public IEnumerable<LoginModel> GetUsers()
        {
            return new List<LoginModel>() { new LoginModel { Id = 101, UserName = "guna", EmailId = "anet@test.com", Password = "guna@123" } };
        }
    }
}
