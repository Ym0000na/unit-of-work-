using ReposituryPatternWithUOW.Core.Interfaces;
using ReposituryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReposituryPatternWithUOW.EF.Repositories
{
    public class BooksRepo : BaseRepositury<Book>, IBooksRepo
    {

        private readonly ApplicationDBContext _context;

        public BooksRepo(ApplicationDBContext context) : base(context)
        {
        }



        public IEnumerable<Book> SpicialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
