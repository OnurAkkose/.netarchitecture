using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using MyProjects.Library.DataAccessLayer;
using MyProjects.Library.ServiceContracts;
using MyProjects.Library.Surrogates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjects.Library.BusinessLogic
{
    public class LibraryService : ILİbraryService
    {
        public IEnumerable<LibrarySurrogate> Get()
        {
            using (UnitOfWork uow = new UnitOfWork(DataLayer))
            {
                var books = uow.Query<Book>().Select(x => new LibrarySurrogate
                {
                    BookName = x.BookName,
                    AuthorName = x.AuthorName,
                    PagesCount = x.PagesCount

                }).ToList();
                return books;
            }
            
        }

        public async Task<IEnumerable<LibrarySurrogate>> GetAsync()
        {
            using (UnitOfWork uow = new UnitOfWork(DataLayer))
            {
                var books = await uow.Query<Book>().Select(x => new LibrarySurrogate
                {
                    BookName = x.BookName,
                    AuthorName = x.AuthorName,
                    PagesCount = x.PagesCount

                }).ToListAsync();
                return books;
            }
            

        }

    
       

        private static IDataLayer _dataLayer = null;

        private IDataLayer DataLayer
        {
            get
            {
                if (_dataLayer == null)                
                {
                    XpoDefault.Session = new Session();
                    XPDictionary dictionary = new ReflectionDictionary();
                    dictionary.GetDataStoreSchema(typeof(Book).Assembly);
                    _dataLayer = new ThreadSafeDataLayer(dictionary, GetConnectionProvider());
                
                }

                return _dataLayer;
            }
        }

        private static IDataStore GetConnectionProvider()
        {
            IDisposable[] disposableList;
            return MySqlConnectionProvider.CreateProviderFromString(
                "Server=127.0.0.1;User ID=root;Password=Maria.2897;Database=Library;Persist Security Info= true;Charset=utf8",
            AutoCreateOption.DatabaseAndSchema,
                out disposableList
                );
        }

        public Book get_Id(int id)
        {
            using (UnitOfWork uow = new UnitOfWork(DataLayer))
            {
                // var p = uow.GetObjectByKey<Book>(id);
                var p = uow.GetObjectByKey<Book>(id);
                return p;
            }
            

        }

        public Book GetBookByName(string name)
        {
            using (UnitOfWork uow = new UnitOfWork(DataLayer))
            {
                return null;
            }
        }

        public Book CreateNewBook()
        {
            using (UnitOfWork uow = new UnitOfWork(DataLayer))
            {
                // Create a new object within a Unit of Work
                Book p = new Book(uow);
                p.BookName = "CRUD";
                p.AuthorName = "Onur Akköse";
                p.PagesCount = 1000;

                // Save all the changes made
                uow.CommitChanges();
                return p;
            }
            
        }
    }
}
