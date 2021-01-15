using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookReselling.BusinessLayer.Services.Repository
{
    public interface IBookResellingRepository
    {
        Task<IEnumerable<Book>> GetAllBook();
        Task<Book> GetBookDetailsById(string bookId);
        Task<Book> GetBookByBookType(string bookTypeId);
        Task<IEnumerable<Book>> FindBook(string name);
        Task<ApplicationUser> RegisterUser(ApplicationUser user);
        Task<ApplicationUser> GetUserDetailsById(string UserId);
        Task<ApplicationUser> VerifyUser(string email, string password);
        Task<Book> BookOrder(string bookId, ApplicationUser user);
        IList<BookType> BookTypeList();
        Task<IEnumerable<Order>> OrderInformation(string email);
    }
}
