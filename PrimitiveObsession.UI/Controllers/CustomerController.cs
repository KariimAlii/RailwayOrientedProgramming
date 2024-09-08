using Microsoft.AspNetCore.Mvc;
using PrimitiveObsession.UI.Models;
using System.ComponentModel.DataAnnotations;

namespace PrimitiveObsession.UI.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepo _customerRepo = new CustomerRepo();
        public IActionResult Create(CustomerModel customerModel)
        {
            if(!ModelState.IsValid)
            {
                return View(customerModel);
            }

            var customer = new Customer(customerModel.Name, customerModel.Email);

            _customerRepo.AddCustomer(customer);

            return RedirectToAction("Index");
        }
        public class CustomerModel
        {
            // 🚩🚩Duplicated Validation
            [Required]
            [StringLength(100, ErrorMessage = "Name is too long")]
            public string Name { get; set; }

            // 🚩🚩Duplicated Validation
            [Required]
            [EmailAddress]
            [StringLength(100, ErrorMessage = "Email is too long")]
            public string Email { get; set; }
        }
    }
}
