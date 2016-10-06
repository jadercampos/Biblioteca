using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAngularJS.Domain.Entities;
using WebApiAngularJS.Domain.Interfaces;
using WebApiAngularJS.Repositories.EF;

namespace WebApiAngularJS.UX.WebAPI.Controllers.API
{
    public class EditoraController : ApiController
    {
        private IEditoraRepository repositorio;

        public EditoraController()
        {
            repositorio = new EditoraRepository();
        }
        [HttpGet]
        public IEnumerable<Editora> ListarTodos()
        {
            return repositorio.GetList();
        }
        [HttpGet]
        public HttpResponseMessage RetornarPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, repositorio.Get(id));
        }
        [HttpPost]
        public HttpResponseMessage Incluir(Editora Editora)
        {
            if (Editora == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new EditoraRepository())
            {
                Editora.DtInc = DateTime.Now;
                repositorio.Add(Editora);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPut]
        public HttpResponseMessage Alterar(Editora Editora)
        {
            if (Editora == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new EditoraRepository())
            {
                Editora.DtInc = DateTime.Now;
                repositorio.Update(Editora);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage Excluir(Editora Editora)
        {
            if (Editora == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new EditoraRepository())
            {
                repositorio.Delete(Editora);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new EditoraRepository())
            {
                repositorio.Delete(id);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
