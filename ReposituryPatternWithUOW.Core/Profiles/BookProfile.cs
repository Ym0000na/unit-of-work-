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
            CreateMap<Author, BookAuthorViewDto>();
            CreateMap<Book, BookAuthorViewDto>();
            //CreateMap<Book, BookAuthorViewDto>()
            //         .ForMember(dest => dest.AuthorName,
            //                    opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : null));

        }
    }
}
