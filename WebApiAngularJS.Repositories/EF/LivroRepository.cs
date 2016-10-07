using System.Collections.Generic;
using System.Linq;
using WebApiAngularJS.Domain.Entities;
using WebApiAngularJS.Domain.Interfaces;

namespace WebApiAngularJS.Repositories.EF
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public IEnumerable<Livro> GetByName(string name)
        {
            return Context.Livros.Where(e => e.Nome.Contains(name)).ToList();
        }
        public new void Add(Livro livro) {
            EditoraRepository edit = new EditoraRepository();
            livro.Editora = Context.Editoras.Where(e => e.Id.Equals(livro.Editora.Id)).SingleOrDefault();
            base.Add(livro);
        }
        public new void Update(Livro livro)
        {
            EditoraRepository edit = new EditoraRepository();
            livro.Editora = Context.Editoras.Where(e => e.Id.Equals(livro.Editora.Id)).SingleOrDefault();
            base.Update(livro);
        }
    }
}
