using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Restataurentapplication.Interface;
using Restataurentapplication.Models;

namespace Restataurentapplication.Controllers
{
    public class RestaurentController : Controller
    {
        private readonly IPaymentType _IPayment;
        private readonly ICustomer _ICustomer;
        private readonly IItemTypes _IitemType;
        public IConfiguration Configuration { get; }
        public RestaurentController(IConfiguration configuration, IPaymentType strPayment, ICustomer strcustomer, IItemTypes stritemtypes)
        {
            Configuration = configuration;
            _IPayment = strPayment;
            _ICustomer = strcustomer;
            _IitemType = stritemtypes;
        }

        [Authorize]
        public IActionResult Index()
        {
            var objmultiplerecords = new Tuple<List<PaymentTypeModel>, List<CustomerModel>, List<ItemModel>>(_IPayment.GetAllPaymentType(Configuration.GetConnectionString("myDb1")), _ICustomer.GetAllCustomerType(Configuration.GetConnectionString("myDb1")), _IitemType.GetAllitems(Configuration.GetConnectionString("myDb1")));
            return View(objmultiplerecords);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetItemUnitPrice(int itemId)
        {
            //decimal Unitprice = 0.05m;
            decimal Unitprice = _IitemType.GetItempricebyitem(Configuration.GetConnectionString("myDb1"),itemId);
            return Json(Unitprice);
        }
        [HttpPost]
        public JsonResult InsertorderDetails(OrderViewModel objOrderViewModel)
        {
            return Json("1");
        }
        [HttpPost]
        public void PassThings(List<Thing> things)
        {
            var t = things;
        }

        public class Thing
        {
            public int id { get; set; }
            public string color { get; set; }
        }

    }
}
