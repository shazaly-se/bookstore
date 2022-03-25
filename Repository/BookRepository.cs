using AutoMapper;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
          var records= await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookById(int bookId)
        {
            // var records = await _context.Books.Where(x=>x.Id==bookId).Select(x => new BookModel()
            // {
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            // }).FirstOrDefaultAsync();
            //return records;
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBook(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateBook(int bookId,BookModel bookModel)
        {
           // var book =await _context.Books.FindAsync(bookId);
           //  if(book != null)
           // {
           //     book.Title = bookModel.Title;
           //     book.Description = bookModel.Description;
           //     await _context.SaveChangesAsync();
           // }

            var book = new Books()
            {
                Id=bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var book = new Books()
            {
                Id = bookId
            };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
           
        }

    }
}
