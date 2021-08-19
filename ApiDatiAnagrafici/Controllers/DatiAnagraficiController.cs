using ApiDatiAnagrafici.Messages;
using DatiAnagrafici.Controllers;
using DatiAnagrafici.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDatiAnagrafici.Controllers
{
    public class DatiController : BaseApiController
    {
        private readonly IDatiAnagraficiService _Dati;
        public DatiController(IDatiAnagraficiService Dati)
        {
            _Dati = Dati;
        }


        [HttpPost]
        public async Task<IActionResult> AddDati([FromBody] AddDatiRequest request)
        {
            var response = await _Dati.AddDatiAsync(request);

            return new ObjectResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDati([FromQuery] GetAllDatiRequest request)
        {
            var response = await _Dati.GetAllDatiAsync(request);

            return new ObjectResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetDatiById([FromQuery] GetDatiByIdRequest request)
        {
            var response = await _Dati.GetDatiByIdAsync(request);

            return new ObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditDati([FromBody] EditDatiRequest request)
        {
            var response = await _Dati.EditDatiAsync(request);

            return new ObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDati([FromBody] RemoveDatiRequest request)
        {
            var response = await _Dati.RemoveDatiAsync(request);

            return new ObjectResult(response);
        }

    }
}
