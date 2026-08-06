using ReposituryPatternWithUOW.Core.Interfaces;
using ReposituryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReposituryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepositury<Author> Authors { get; }

        //IBaseRepositury<Book> Books { get; }
        IBooksRepo Books { get; }

        int Complete();




    }
}
