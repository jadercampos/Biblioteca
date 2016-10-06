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
    public class LivroController : ApiController
    {
        private ILivroRepository repositorio;

        public LivroController()
        {
            repositorio = new LivroRepository();
        }
        [HttpGet]
        public IEnumerable<Livro> ListarTodos()
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
        public HttpResponseMessage Incluir(Livro Livro)
        {
            if (Livro == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new LivroRepository())
            {
                repositorio.Add(Livro);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPut]
        public HttpResponseMessage Alterar(Livro Livro)
        {
            if (Livro == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new LivroRepository())
            {
                repositorio.Update(Livro);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage Excluir(Livro Livro)
        {
            if (Livro == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new LivroRepository())
            {
                repositorio.Delete(Livro);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (repositorio = new LivroRepository())
            {
                repositorio.Delete(id);
                repositorio.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
