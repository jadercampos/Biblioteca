using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiAngularJS.Domain.Enums;

namespace WebApiAngularJS.UX.WebAPI.Controllers.API
{
    public class IdiomaController : ApiController
    {
        [HttpGet]
        public IEnumerable<Idioma> ListarTodos()
        {
            return EnumHelper.GetList<Idioma>();
        }
        [HttpGet]
        public IEnumerable<String> ListarNomes()
        {
            return EnumHelper.GetStringList<Idioma>();
        }
    }
}