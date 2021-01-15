using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookReselling.BusinessLayer.Interfaces;
using OnlineBookReselling.BusinessLayer.ViewModels;
using OnlineBookReselling.Entities;

namespace OnlineBookReselling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// creating referance variable of IBookResellingServices and injecting in Controller
        /// </summary>
        private readonly IBookResellingServices _bookServices;
        public BookController(IBookResellingServices bookResellingServices)
        {
            _bookServices = bookResellingServices;
        }
        /// <summary>
        /// Get all Book from MongoDb collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBook()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get book Details byy BookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BookById/{bookId}")]
        public async Task<IActionResult> BookById(string bookId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// get book type by BookType Id
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BookTypeById/{bookTypeId}")]
        public async Task<IActionResult> BookTypeById(string bookTypeId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find a book by Book Name and Book Author
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindBook/{name}")]
        public async Task<IEnumerable<Book>> FindBook(string name)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUserViewModel model)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get User Details by UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserDetails/{UserId}")]
        public async Task<IActionResult> UserDetailsById(string UserId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place a book Order, befor placing order verify user
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BookOrder/{bookId}/{email}/{password}")]
        public async Task<IActionResult> PlaceBookOrder(string bookId, string email, string password)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Book Type List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("BookTypeList")]
        public IEnumerable<BookType> BookTypeList()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Order Infromation based on User Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrderInformation/{email}")]
        public async Task<IEnumerable<Order>> AllOrderInformation(string email)
        {
            //Do code Here
            throw new NotImplementedException();
        }
    }
}
