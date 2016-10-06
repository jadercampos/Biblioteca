using System.Collections.Generic;
using System.Linq;
using WebApiAngularJS.Domain.Entities;
using WebApiAngularJS.Domain.Interfaces;

namespace WebApiAngularJS.Repositories.EF
{
    public class EditoraRepository : RepositoryBase<Editora>, IEditoraRepository
    {
        public IEnumerable<Editora> GetByName(string name)
        {
            return Context.Editoras.Where(e => e.Nome.Contains(name)).ToList();
        }
    }
}
