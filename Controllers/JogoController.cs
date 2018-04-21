using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using megasena.Models;
using megasena.Regras;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace megasena.Controllers
{
    [Route("api/[controller]")]
    public class JogoController : Controller
    {
        GeradorJogos gerador = new GeradorJogos();
        
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]JogoDomain Jogo)
        {
            try 
            {
                if(!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new {sucess = false, responseText = ""});
                }
            
                return Json(JsonConvert.SerializeObject(new { sucess = true, jogos = gerador.GerandoJogos(Jogo) }));
            } 
            catch(Exception ex)
            {
                
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {sucess = false, responseText = "erro inesperado. " + ex.Message});
            }
            
        }

    }
}
