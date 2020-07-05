using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPSKimlik.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceReference1;

namespace KPSKimlik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPSController : ControllerBase
    {
        [HttpGet]
        [Route("kimlikdogrula")]
        public async Task<IActionResult> Get(string tcKimlikNo,string ad,string soyad,string dogumYili)    // GET isteği çalışıyor
        {
            KPSPublicSoapClient servis = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var sonuc = await servis.TCKimlikNoDogrulaAsync(long.Parse(tcKimlikNo), ad, soyad, int.Parse(dogumYili));
            return Ok(JsonConvert.SerializeObject(sonuc.Body.TCKimlikNoDogrulaResult));
        }

        [HttpPost]
        [Route("kimlikdogrula")]
        public async Task<IActionResult> Post([FromBody]Vatandas vatandas)       // POST bad requeste düşüyor
        {
            KPSPublicSoapClient servis = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var sonuc = await servis.TCKimlikNoDogrulaAsync(vatandas.TCKimlikNo, vatandas.Ad, vatandas.Soyad, vatandas.DogumYili);
            return Ok(JsonConvert.SerializeObject(sonuc.Body.TCKimlikNoDogrulaResult));
        }
    }
}