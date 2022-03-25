using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
