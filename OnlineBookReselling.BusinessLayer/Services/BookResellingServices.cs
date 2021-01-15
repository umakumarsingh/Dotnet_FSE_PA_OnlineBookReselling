using OnlineBookReselling.BusinessLayer.Interfaces;
using OnlineBookReselling.BusinessLayer.Services.Repository;
using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookReselling.BusinessLayer.Services
{
    public class BookResellingServices : IBookResellingServices
    {
        /// <summary>
        /// Creating Referancce variable of IBookResellingRepository and injecting Referance into constructor
        /// </summary>
        private readonly IBookResellingRepository _brRepository;
        public BookResellingServices(IBookResellingRepository bookResellingRepository)
        {
            _brRepository = bookResellingRepository;
        }
        /// <summary>
        /// Place a book Order after validating a user is registred or not.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Book> BookOrder(string bookId, ApplicationUser user)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Book Type List
        /// </summary>
        /// <returns></returns>
        public IList<BookType> BookTypeList()
        {
            //Do code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> FindBook(string name)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all book
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> GetAllBook()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Book by Book Type
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        public async Task<Book> GetBookByBookType(string bookTypeId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get book Detais by Book Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<Book> GetBookDetailsById(string bookId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get user details by User Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUserDetailsById(string UserId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get User order infromation 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> OrderInformation(string email)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Verify an user for place order
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> VerifyUser(string email, string password)
        {
            //Do code Here
            throw new NotImplementedException();
        }
    }
}
