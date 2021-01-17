using MyProjects.Library.DataAccessLayer;
using MyProjects.Library.Surrogates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjects.Library.ServiceContracts
{
    public interface ILİbraryService
    {
        IEnumerable<LibrarySurrogate> Get();

        Task<IEnumerable<LibrarySurrogate>> GetAsync();

        Book get_Id(int id);

        Book GetBookByName(string name);

        Book CreateNewBook();

              

    }
}
