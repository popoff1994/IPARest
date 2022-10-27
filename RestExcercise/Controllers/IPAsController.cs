using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestExcercise.Managers;
using RestExcercise.Models;
using System.Security.Claims;

namespace RestExcercise.Controllers
{
    [Route("api/[Controller]")]
    // The controller is available on ..../api/ipas
    [ApiController]
    public class IPAsController : ControllerBase
    {
        private readonly IPAsManager _manager = new IPAsManager();


        // Get: api/<IPAsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Route("Name/{substring}")]
        //[Route("Proof/{id}")]
        [HttpGet]
        [EnableCors("allowALL")]
        public  IEnumerable<IPA> Get([FromQuery] string? ipaName, double proof)
        {
            return _manager.GetAll(ipaName, proof);
        }

        // Get: api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<IPA> Get(int id)
        {
            IPA ipa = _manager.GetById(id);
            if (ipa == null) return NotFound("No such class, id: " +""+ id);
            return Ok(ipa);

        }

        // POST: api/<IPAsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<IPA> Post([FromBody] IPA value)
        {
            IPA ipa = _manager.Add(value);
            return Ok(ipa);
        }

        // PUT: api/<IPAsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<IPA> Put(int id, [FromBody] IPA value)
        {
            IPA ipa = _manager.Update(id, value);
            if (ipa == null) return NotFound("There is no IPA on Id!"+" "+ id);
            return Ok(value);
        }

        // DELETE api/<IPAsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<IPA> Delete(int id)
        {
            IPA ipa = _manager.Delete(id);
            if (ipa == null) return NotFound("There is no IPA on Id" + " " + id);
            return Ok(ipa);
        }      
    }
}
