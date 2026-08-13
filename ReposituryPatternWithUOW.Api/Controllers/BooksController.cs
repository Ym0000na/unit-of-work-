using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReposituryPatternWithUOW.Core;
using ReposituryPatternWithUOW.Core.Consts;
using ReposituryPatternWithUOW.Core.Interfaces;
using ReposituryPatternWithUOW.Core.Mappings; // for the extension methods
using ReposituryPatternWithUOW.Core.Models;
using ReposituryPatternWithUOW.Dtos;          // for the DTO types themselves
using ReposituryPatternWithUOW.EF;

namespace ReposituryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var books = _unitOfWork.Books.GetAll();
            var dtos = (from b in books
                        select b.ToDto()).ToList();
            return Ok(dtos);
        }

        [HttpGet("BookAuthorView-dto")]
        public IActionResult GetBooksWithAuthor_UsingDto()
        {
            var books = _unitOfWork.Books.GetAll();
            var authors = _unitOfWork.Authors.GetAll();

            var result = books.ToBookAuthorViewDtoList(authors);
            return Ok(result);
        }

        [HttpGet("BookAuthorView-NoDto")]
        public IActionResult GetBooksWithAuthor_Manual()
        {
            var books = _unitOfWork.Books.GetAll();
            var authors = _unitOfWork.Authors.GetAll();

            var result = from b in books
                         join a in authors on b.AuthorId equals a.Id
                         select new
                         {
                             Title = b.Title,
                             AuthorName = a.Name
                         };

            return Ok(result.ToList());
        }

        [HttpGet("GetAll-automapper")]
        public IActionResult GetAll_UsingAutoMapper()
        {
            var books = _unitOfWork.Books.GetAll();
            var result = _mapper.Map<List<BookDto>>(books);
            return Ok(result);
        }

        [HttpGet("BookAuthorView-automapper")]
        public IActionResult GetBooksWithAuthor_UsingAutoMapper()
        {
            var books = _unitOfWork.Books.GetAll(); 
            var result = _mapper.Map<List<BookAuthorViewDto>>(books);
            return Ok(result);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "new book", new[] { "Author" }));
        }


        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains( "new book"), new[] { "Author" }));
        }


        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains( "new book"), null, null, b => b.Id, OrderBy.Descending));
        }


        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Test 4", AuthorId = 1 });
            _unitOfWork.Complete(); // have to call this method to save changes to the database in unit of work pattern
            return Ok(book);
        }


    }
}
        



