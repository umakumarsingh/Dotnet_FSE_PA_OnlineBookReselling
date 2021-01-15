using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookReselling.BusinessLayer.Services.Repository
{
    public interface IAdminBookResellingRepository
    {
        Task<IEnumerable<Order>> AllUserOrder();
        Task<IEnumerable<ApplicationUser>> AllApplicationUser();
        Task<Book> AddNewBook(Book book);
        Task<Book> UpdateBook(string bookId, Book book);
        Task<bool> DeleteBook(string bookId);
        Task<BookType> AddNewBookType(BookType bookType);
        Task<BookType> UpdateBookType(string bookTypeId, BookType bookType);
        Task<BookType> GetBookTypeById(string bookTypeId);
        Task<bool> DeleteBookType(string bookTypeId);
    }
}
