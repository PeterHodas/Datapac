using Datapac_uloha.Data;
using Datapac_uloha.Models;

namespace Datapac_uloha.Service
{
	public class NoticeService
	{

        private readonly ApplicationDbContext _context;

        public NoticeService(ApplicationDbContext context)
		{
            _context = context;
        }

        public String CreateNotice(int zakaznik_id, int kniha_id, DateTime vratena, String stav)
        {

            // Vytvorenie nového záznamu
            var newNotice = new Notice
            {
                zakaznik_id = zakaznik_id,
                kniha_id = kniha_id,
                pozicana = DateTime.Now,
                vratena = vratena,
                stav = stav
            };

            // Pridanie nového záznamu do kontextu
            _context.vypozicka.Add(newNotice);

            // Uloženie zmien do databázy
            _context.SaveChanges();

            return "Nová zápožička bola úspešne vytvorená.";
        }


        public async Task<bool> UpdateNotice(int id)
        {
            try
            {
                var orginalNotice = await _context.vypozicka.FindAsync(id);

                if (orginalNotice == null)
                {
                    return false; 
                }

                orginalNotice.stav = "je vratena";

                _context.vypozicka.Update(orginalNotice);
                await _context.SaveChangesAsync();

                return true; // Aktualizácia úspešná
            }
            catch (Exception)
            {
                return false; // Nastala chyba pri aktualizácii 
            }
        }
    }
}

