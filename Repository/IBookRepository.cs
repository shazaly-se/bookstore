using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
  public  interface IBookRepository
    {
       Task<List<BookModel>> GetAllBookAsync();
       Task<BookModel> GetBookById(int bookId);
        Task<int> AddBook(BookModel bookModel);
        Task UpdateBook(int bookId, BookModel bookModel);
        Task DeleteBook(int bookId);
    }
}
