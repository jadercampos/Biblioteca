using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiAngularJS.Domain.Enums;

namespace WebApiAngularJS.UX.WebAPI.Controllers.API
{
    public class CapaController : ApiController
    {
        [HttpGet]
        public IEnumerable<Capa> ListarTodos()
        {
            return EnumHelper.GetList<Capa>();
        }
        [HttpGet]
        public IEnumerable<String> ListarNomes()
        {
            return EnumHelper.GetStringList<Capa>();
        }
    }
}
