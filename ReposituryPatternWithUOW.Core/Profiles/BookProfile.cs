using AutoMapper;
using ReposituryPatternWithUOW.Core.Models;
using ReposituryPatternWithUOW.Dtos;
using System;
using System.Collections.Generic;
using System.Text;


namespace ReposituryPatternWithUOW.Core.Profiles
{
    public class BookProfile : Profile
    {

        public BookProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
