using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Interfaces;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace burgershack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BurgersController : ControllerBase, ICodeWorksRestfulController<Burger>
    {
        private readonly BurgersService _bs;

        public BurgersController(BurgersService bs)
        {
            _bs = bs;
        }


        [HttpPost]
        public ActionResult<Burger> Create([FromBody] Burger newBurger)
        {
            try
            {
                Burger burger = (Burger)_bs.Create(newBurger);
                return Ok(newBurger);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public ActionResult<Burger> GetOne(int id)
        {
            try
            {
                Burger found = _bs.GetOne(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public ActionResult<IEnumerable<Burger>> Get()
        {
            try
            {
                IEnumerable<Burger> burgers = _bs.Get();
                return Ok(burgers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Burger> Update(int id, [FromBody] Burger update)
        {
            try
            {
                update.Id = id;
                Burger updated = _bs.Update(update);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public ActionResult<Burger> Delete(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public ActionResult<Burger> Update(Burger data)
        {
            throw new NotImplementedException();
        }
    }
}
