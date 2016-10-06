using System.Collections.Generic;
using WebApiAngularJS.Domain.Entities;

namespace WebApiAngularJS.Domain.Interfaces
{
    public interface ILivroRepository : IRepositoryBase<Livro>
    {
        IEnumerable<Livro> GetByName(string name);
    }
}
