using OnlineBookReselling.BusinessLayer.Interfaces;
using OnlineBookReselling.BusinessLayer.Services.Repository;
using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookReselling.BusinessLayer.Services
{
    public class AdminBookResellingServices : IAdminBookResellingServices
    {
        /// <summary>
        /// Creating Referancce variable of IAdminBookResellingRepository and injecting Referance into constructor
        /// </summary>
        private readonly IAdminBookResellingRepository _adminRepository;
        public AdminBookResellingServices(IAdminBookResellingRepository adminBookResellingRepository)
        {
            _adminRepository = adminBookResellingRepository;
        }
        /// <summary>
        /// Add New book In MongoDb collection by calling repository method
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<Book> AddNewBook(Book book)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add New book type In MongoDb collection by calling repository method
        /// </summary>
        /// <param name="bookType"></param>
        /// <returns></returns>
        public async Task<BookType> AddNewBookType(BookType bookType)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all application user
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> AllApplicationUser()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> AllUserOrder()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete a book by BookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBook(string bookId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete a book Type by BookType Id
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBookType(string bookTypeId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Book Type by BookType Id
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        public async Task<BookType> GetBookTypeById(string bookTypeId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing book by id an dobject
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<Book> UpdateBook(string bookId, Book book)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing book Type by id an dobject
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <param name="bookType"></param>
        /// <returns></returns>
        public async Task<BookType> UpdateBookType(string bookTypeId, BookType bookType)
        {
            //Do code Here
            throw new NotImplementedException();
        }
    }
}
