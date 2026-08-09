using System;
using System.Collections.Generic;
using System.Text;

namespace ReposituryPatternWithUOW.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}
