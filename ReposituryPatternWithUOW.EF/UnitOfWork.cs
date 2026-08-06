using ReposituryPatternWithUOW.Core;
using ReposituryPatternWithUOW.Core.Interfaces;
using ReposituryPatternWithUOW.Core.Models;
using ReposituryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReposituryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public IBaseRepositury<Author> Authors {  get; private set; }

        //public IBaseRepositury<Book> Books {  get; private set; }

        public IBooksRepo Books {  get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;

            Authors = new BaseRepositury<Author>(_context);
            //Books = new BaseRepositury<Book>(_context);
            Books = new BooksRepo(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
