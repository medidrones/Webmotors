using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Webmotors.Application.Requests;
using Webmotors.Application.Responses;
using Webmotors.Domain.Interfaces.Services;

namespace WebMotors.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private IAdService _service;

        public AdsController(IAdService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Produces("application/JSON")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post(AdRequest request)
        {
            var ad = _service.Add(request);

            return CreatedAtAction(nameof(Get), new { id = ad.ID }, ad);
        }

        [HttpGet]
        [Produces("application/JSON")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<AdResponse>> Get()
        {
            var ads = _service.Get();

            if (ads.Count() < 1)
            {
                return NotFound();
            }

            return Ok(ads);
        }

        [HttpGet("{id}")]
        [Produces("application/JSON")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<AdResponse> Get(int id)
        {
            var ad = _service.Get(id);

            if (ad == null)
            {
                return NotFound();
            }

            return Ok(ad);
        }

        [HttpPut("{id}")]
        [Produces("application/JSON")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public ActionResult Put(int id, AdRequest request)
        {
            var ad = _service.Update(id, request);

            return AcceptedAtAction(nameof(Get), new { id = ad.ID }, ad);
        }

        [HttpDelete("{id}")]
        [Produces("application/JSON")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<AdResponse> Delete(int id)
        {
            var ad = _service.Get(id);

            if (ad == null)
            {
                return NotFound();
            }

            _service.Remove(id);

            return Ok();
        }
    }
}
