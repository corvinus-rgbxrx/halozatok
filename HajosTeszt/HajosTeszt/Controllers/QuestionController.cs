using HajosTeszt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HajosTeszt.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpGet]
        [Route("questions/count")]
        public int M1()
        {
            HajostesztContext context = new HajostesztContext();
            int kérdésekszáma = context.Questions.Count();
            return kérdésekszáma;
        }
        [HttpGet]
        [Route("questions/{sorszám}")]
        public ActionResult M2(int sorszám;int x);
        {
        HajostesztContext context = new HajostesztContext();
        var kérdés = {from x in context.Questions
                      where x.QuestionID ==sorszám
                      select x}.FistOrDefault();

        if (kérdés==null) return BadRequest("nincs ilyen kérdés");
	    return new JsonResult(kérdés);
    }

    }
}
