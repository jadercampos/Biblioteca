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
    }
}
