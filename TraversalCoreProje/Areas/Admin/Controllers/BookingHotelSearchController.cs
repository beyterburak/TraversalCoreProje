using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/properties/list?offset=0&arrival_date=2023-09-06&departure_date=2023-09-10&guest_qty=1&dest_ids=-1456928&room_qty=1&search_type=city&children_qty=2&children_age=5&search_id=none&price_filter_currencycode=USD&order_by=popularity&languagecode=tr&travel_purpose=leisure"),
                Headers =
    {
        { "X-RapidAPI-Key", "5b7c667fe5mshd8ffbac32316ff8p173756jsn24ddfa888f33" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
                return View(values.result);
            }
            
        }

        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://apidojo-booking-v1.p.rapidapi.com/locations/auto-complete?text={p}&languagecode=en-us"),
                Headers =
    {
        { "X-RapidAPI-Key", "5b7c667fe5mshd8ffbac32316ff8p173756jsn24ddfa888f33" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();
            }
            
        }
    }
}
