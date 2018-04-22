using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using megasena.Models;
using megasena.Regras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace megasena.Controllers
{
    [Route("api/megasena")]
    public class JogoController : Controller
    {
        GeradorJogos gerador = new GeradorJogos();
        
        /// <summary>
        /// POST com os parametros para gerar os jogos da mega sena.
        /// </summary>
        /// <remarks>
        /// /// Exemplo de POST:
        ///
        ///     POST http://localhost:5000/api/megasena
        ///    
        ///     {
        ///         "quantidadeJogos": 1,
        ///         "quantidadeNumeros": 6
        ///     }
        /// 
        /// </remarks>
        /// <param name="Jogo"> 
        /// objeto Jogo contento: 
        ///         {
        ///             valor mínimo 1 e sem valor máximo.
        ///             "quantidadeJogos": 1,
        ///             valor mínimo 6 e valor máximo 15.
        ///             "quantidadeNumeros": 10
        ///         }  
        /// </param>
        /// <returns>json com proiedade success com  valor true/false e propriedade jogos com uma lista dos jgos com parametros enviados.</returns>
        /// <response code="200">json com a propriedade success com true e a lista com os jogos gerados.</response>
        /// <response code="400">json informando success com false e erro nos dados enviados / erro inesperado da aplicação.</response>
        [HttpPost]
        [AllowAnonymous]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult Post([FromBody]JogoDomain Jogo)
        {
            if(!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {success = false, responseText = "Os campos inseridos são invalidos."});
            }
            
            try 
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(JsonConvert.SerializeObject(new { success = true, jogos = gerador.GerandoJogos(Jogo)}));
            } 
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new {success = false, responseText = "erro inesperado. " + ex.Message});
            }
        }

    }
}
