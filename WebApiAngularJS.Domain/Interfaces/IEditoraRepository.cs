using System.Collections.Generic;
using WebApiAngularJS.Domain.Entities;

namespace WebApiAngularJS.Domain.Interfaces
{
    public interface IEditoraRepository : IRepositoryBase<Editora>
    {
        IEnumerable<Editora> GetByName(string name);
    }
}
