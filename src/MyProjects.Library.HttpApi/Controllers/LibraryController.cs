using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using MyProjects.Library.DataAccessLayer;
using MyProjects.Library.ServiceContracts;
using MyProjects.Library.Surrogates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjects.Library.HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase, ILİbraryService
    {
        private ILİbraryService _libraryService;
       
        

        public LibraryController(ILİbraryService lİbraryService)
        {
            _libraryService = lİbraryService;
            
        }

        [HttpGet]
        [Route("create")]
        public Book CreateNewBook()
        {
            return _libraryService.CreateNewBook();
        }

        [HttpGet]
        public IEnumerable<LibrarySurrogate> Get()
        {
            return (_libraryService.Get());
        }

        [HttpGet]
        [Route("async")]
        public Task<IEnumerable<LibrarySurrogate>> GetAsync()
        {
            return _libraryService.GetAsync();

           
        }

        [HttpGet]
        [Route("getbyname/{name}")]
        public Book GetBookByName(string name)
        {
            return _libraryService.GetBookByName(name);
        }

        [HttpGet("getbyid/{id}")]
        public Book get_Id(int id)
        {
             return _libraryService.get_Id(id);
        }
    }
}
