using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Restataurentapplication.Interface;
using Restataurentapplication.Models;

namespace Restataurentapplication.Controllers
{
    public class PaymentController : Controller
    {

        private readonly IPaymentType _IPayment;
        private readonly ICustomer _ICustomer;
        private readonly IItemTypes _IitemType;
        private readonly IOrderdetails _IOrderdetails;
        public IConfiguration Configuration { get; }
        public PaymentController(IConfiguration configuration, IPaymentType strPayment, ICustomer strcustomer, IItemTypes stritemtypes, IOrderdetails strorderdetails)
        {
            Configuration = configuration;
            _IPayment = strPayment;
            _ICustomer = strcustomer;
            _IitemType = stritemtypes;
            _IOrderdetails = strorderdetails;
        }
        // GET: PaymentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentController/Details/5
        public ActionResult GetorderDetails(Int64 id)
        {

            var objmultiplerecords = new Tuple<List<PaymentTypeModel>, List<CustomerModel>, List<ItemModel>>(_IPayment.GetAllPaymentType(Configuration.GetConnectionString("myDb1")), _ICustomer.GetAllCustomerType(Configuration.GetConnectionString("myDb1")), _IitemType.GetAllitems(Configuration.GetConnectionString("myDb1")));
            return View(objmultiplerecords);
           // return View();
        }

        [HttpGet]
        public List<OrderDetailsModel> GetorderDetailsByCustId(int custid)
        {
            OrderDetailsModel objOrderDetailsModel = new OrderDetailsModel();
            //string stres = string.Empty;
            return _IOrderdetails.GetorderdetailByid(custid,Configuration.GetConnectionString("myDb1"));
        }



        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
