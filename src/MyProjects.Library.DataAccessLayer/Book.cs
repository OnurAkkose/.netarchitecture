using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjects.Library.DataAccessLayer
{
    [Persistent("book")]
    public class Book : XPCustomObject
    {
        int id;
        string bookname;
        string authorname;
        int pagescount;

        public Book(Session session) : base(session) 
        {

        }

        [Persistent("id"), Key(true)]
        public int Id 
        {
            get => Id;
            set => SetPropertyValue(nameof(Id), ref id, value);
        }

        [Size(55)]
        public string BookName
        {
            get => BookName;
            set => SetPropertyValue(nameof(BookName), ref bookname, value);
        }

        [Size(55)]
        public string AuthorName
        {
            get => AuthorName;
            set => SetPropertyValue(nameof(AuthorName), ref authorname, value);
        }

        public int PagesCount
        {
            get => PagesCount;
            set => SetPropertyValue(nameof(PagesCount), ref pagescount, value);
        }



    }
}
