using System;
using Microsoft.AspNetCore.Mvc;
using Datapac_uloha.Service;
using Datapac_uloha.Models;

namespace Datapac_uloha.Controller
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
	{
		private readonly CustomerService _customerService;

		public CustomerController(CustomerService customerService)
		{
			_customerService = customerService;
		}

        /********************** Vytvorenie zakaznika **********************/
        //http://localhost:5019/api/CreateNewCustomer/Ferko/Janko/Neznama/222/Zilina
        [HttpPost]
        [Route("CreateNewCustomer/{meno}/{priezvisko}/{ulica}/{pcs}/{obec}")]
        public IActionResult CreateNewCustomer(String meno, String priezvisko, String ulica, String pcs, String obec)
        {
            _customerService.CreateCustomer(meno, priezvisko, ulica, pcs, obec);
            return Ok("Novy zakaznik bol vytvoreny");
        }
    }
}

