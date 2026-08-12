using ReposituryPatternWithUOW.Core.Models;
using ReposituryPatternWithUOW.Dtos;

namespace ReposituryPatternWithUOW.Core.Mappings
{
    public static class BookMappings
    {
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId
            };
        }

        public static Book ToEntity(this CreateBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId
            };
        }


        public static List<BookAuthorViewDto> ToBookAuthorViewDtoList(
        this IEnumerable<Book> books, IEnumerable<Author> authors)
        {
            return (from b in books
                    join a in authors on b.AuthorId equals a.Id
                    select new BookAuthorViewDto
                    {
                        Title = b.Title,
                        AuthorName = a.Name
                    }).ToList();
        }

    }
}