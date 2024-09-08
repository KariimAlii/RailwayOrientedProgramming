using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrimitiveObsession.UI.Models;
using System.ComponentModel.DataAnnotations;

namespace PrimitiveObsession.UI.Controllers
{
    public class Customer2Controller : Controller
    {
        private CustomerRepo_Refactor _customerRepo = new CustomerRepo_Refactor();
        [HttpPost]
        public IActionResult Create(CustomerModel customerModel)
        {
            Result<UsernameVO> usernameResult = UsernameVO.CreateUsername(customerModel.Name);

            Result<EmailVO> emailResult = EmailVO.CreateEmail(customerModel.Email);

            if (usernameResult.IsFailure)
                ModelState.AddModelError("Name", usernameResult.Error);

            if (emailResult.IsFailure)
                ModelState.AddModelError("Email", emailResult.Error);

            if (!ModelState.IsValid)
            {
                return View(customerModel);
            }

            var customer = new Customer_Refactor(usernameResult.Value, emailResult.Value);

            _customerRepo.AddCustomer(customer);

            return RedirectToAction("Index");
        }
        public class CustomerModel
        {
            public string Name { get; set; }

            public string Email { get; set; }
        }
    }
}
