using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UpSchool_UnitofWork_BussinessLayer.Abstract;
using UpSchool_UnitofWork_EntityLayer.Concrete;
using UpSchool_UnitofWork_PresentationLayer.Models;

namespace UpSchool_UnitofWork_PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccounService _accounService;

        public AccountController(IAccounService accounService)
        {
            _accounService = accounService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

            [HttpPost]
        public IActionResult Index(AccountViewModel p)
        {
            var value1 = _accounService.TGetByID(p.SenderID);
            var value2 = _accounService.TGetByID(p.ReceiverID);

            value1.AccountBalance -= p.Amount;
            value2.AccountBalance += p.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                value1,
                value2
            };
            _accounService.TMultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
