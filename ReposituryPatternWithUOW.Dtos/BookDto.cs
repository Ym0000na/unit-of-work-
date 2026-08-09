using System;
using System.Collections.Generic;
using System.Text;

namespace ReposituryPatternWithUOW.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}
