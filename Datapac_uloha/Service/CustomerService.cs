using System;
using Datapac_uloha.Data;
using Datapac_uloha.Models;

namespace Datapac_uloha.Service
{
	public class CustomerService
	{
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public String CreateCustomer(String meno, String priezvisko, String ulica, String pcs, String obec)
        {
            var newCust = new Customer
            {
                meno = meno,
                priezvisko = priezvisko,
                ulica = ulica,
                psc = pcs,
                obec = obec    
            };

            // Pridanie nového záznamu do kontextu
            _context.zakaznik.Add(newCust);

            // Uloženie zmien do databázy
            _context.SaveChanges();

            return "Nový zákazník bol úspešne vytvorený.";
        }

    }
}

