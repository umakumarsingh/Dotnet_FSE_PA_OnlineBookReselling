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
    public class AdminBookController : ControllerBase
    {
        /// <summary>
        /// Creating Referance variable of IAdminBookResellingServices and IBookResellingServices.
        /// Injecting in Controller Constructor
        /// </summary>
        private readonly IAdminBookResellingServices _adminBookServices;
        private readonly IBookResellingServices _bookServices;
        public AdminBookController(IAdminBookResellingServices adminBookResellingServices, IBookResellingServices bookResellingServices)
        {
            _adminBookServices = adminBookResellingServices;
            _bookServices = bookResellingServices;
        }
        /// <summary>
        /// Get All User Order Infromation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Order>> AllUserOrder()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all registred User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Alluser")]
        public async Task<IEnumerable<ApplicationUser>> AllApplicationUser()
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new Book to MongoDb Collecton
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookViewModel model)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatebook/{BookId}")]
        public async Task<IActionResult> Updatebook(string BookId, [FromBody] Book book)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove a book form MongoDb collection
        /// </summary>
        /// <param name="BookId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removebook/{BookId}")]
        public async Task<IActionResult> Removebook(string BookId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new book Type/Category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBookType")]
        public async Task<IActionResult> AddBookType([FromBody] BookTypeViewModel model)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update a bookType
        /// </summary>
        /// <param name="BooktypeId"></param>
        /// <param name="booktype"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatebooktype/{BookId}")]
        public async Task<IActionResult> UpdateBookType(string BooktypeId, [FromBody] BookType booktype)
        {
            //Do code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove book type/category from MongoDb Collection
        /// </summary>
        /// <param name="BooktypeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removebooktype/{BooktypeId}")]
        public async Task<IActionResult> Removebooktype(string BooktypeId)
        {
            //Do code Here
            throw new NotImplementedException();
        }
    }
}
