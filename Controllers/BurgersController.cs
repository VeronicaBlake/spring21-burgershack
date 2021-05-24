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

        [HttpGet]
        public ActionResult<IEnumerable<Burger>> GetAll()
        {
            try
            {
                IEnumerable<Burger> burgers = _bs.GetAll();
                return Ok(burgers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

        public ActionResult<Burger> GetById(int id)
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
            try
            {
                throw new NotImplementedException();
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

        ActionResult<IEnumerable<Burger>> ICodeWorksRestfulController<Burger>.Get()
        {
            throw new NotImplementedException();
        }

        ActionResult<Burger> ICodeWorksRestfulController<Burger>.GetOne(int id)
        {
            throw new NotImplementedException();
        }

        ActionResult<Burger> ICodeWorksRestfulController<Burger>.Create(Burger data)
        {
            throw new NotImplementedException();
        }

        ActionResult<Burger> ICodeWorksRestfulController<Burger>.Update(Burger data)
        {
            throw new NotImplementedException();
        }

        ActionResult<Burger> ICodeWorksRestfulController<Burger>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
