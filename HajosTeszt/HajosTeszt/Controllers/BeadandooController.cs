using HajosTeszt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HajosTeszt.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class BeadandooController : ControllerBase
    {
        [HttpGet]
        [Route("szallodamunkavallalo/count")]
        public int A1()
        {
            RGBXRXContext context = new RGBXRXContext();
            int munkavallalokszama = context.SzallodaMunkavallalos.Count();
            return munkavallalokszama;
        }

        [HttpGet]
        [Route("szallodamunkavallalo/all")]
        public IEnumerable<SzallodaMunkavallalo> Get()
        {
            RGBXRXContext context = new RGBXRXContext();
            return context.SzallodaMunkavallalos.ToList();
        }


        [HttpGet("szallodamunkavallalo/{id}")]
        public SzallodaMunkavallalo Get(int id)
        {
            RGBXRXContext context = new RGBXRXContext();
            var r = (from x in context.SzallodaMunkavallalos
                     where x.MunkasId == id
                     select x).FirstOrDefault();
            return r;
        }

        [HttpDelete("szallodamunkavallalo/del/{id}")]
        public void Delete(int id)
        {
            RGBXRXContext context = new RGBXRXContext();
            var delr = (from x in context.SzallodaMunkavallalos
                        where x.MunkasId == id
                        select x).FirstOrDefault();
            context.Remove(delr);
            context.SaveChanges();
        }



    }
}
