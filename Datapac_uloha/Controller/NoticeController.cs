using Microsoft.AspNetCore.Mvc;
using Datapac_uloha.Service;

namespace Datapac_uloha.Controller
{
    [Route("api")]
    [ApiController]
    public class NoticeController : ControllerBase
	{

		private readonly NoticeService _noticeService;

		public NoticeController(NoticeService noticeService)
		{
			_noticeService = noticeService;
		}

        /********************** Vytvorenie zapozicky **********************/

        [HttpPost]
        [Route("CreateNotice/{zak_id}/{kniha_id}/{vratena}/{stav}")]
        public IActionResult CreateNotice(int zak_id, int kniha_id, DateTime vratena, String stav)
        {
            Console.WriteLine("Som tu");
            _noticeService.CreateNotice(zak_id, kniha_id, vratena, stav);
            return Ok("Nová zápožička bola úspešne vytvorená.");
        }

        /********************** Aktualizacia zapozicky na vratenu **********************/

        [HttpPut]
        [Route("UpdateNotice/{id}")]
        public async Task<IActionResult> UpdateNotice(int id)
        {
            bool result = await _noticeService.UpdateNotice(id);

            if (!result)
            {
                return NotFound(); // Notice s daným ID sa nepodarilo nájsť
            }

            return Ok("Kniha bola vrátená"); // Aktualizácia  bola úspešná
        }

    }
}

