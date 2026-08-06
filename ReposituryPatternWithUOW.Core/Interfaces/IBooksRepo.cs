using ReposituryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReposituryPatternWithUOW.Core.Interfaces
{
    public interface IBooksRepo : IBaseRepositury<Book>
    {
        IEnumerable<Book> SpicialMethod();
    }
}
