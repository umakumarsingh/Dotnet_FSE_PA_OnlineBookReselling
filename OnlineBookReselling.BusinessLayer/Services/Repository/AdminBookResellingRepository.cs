using MongoDB.Bson;
using MongoDB.Driver;
using OnlineBookReselling.DataLayer;
using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookReselling.BusinessLayer.Services.Repository
{
    public class AdminBookResellingRepository : IAdminBookResellingRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<ApplicationUser> _applicationUser;
        private IMongoCollection<Book> _book;
        private IMongoCollection<BookType> _bookType;
        private IMongoCollection<Order> _order;
        public AdminBookResellingRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _applicationUser = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
            _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
            _bookType = _mongoContext.GetCollection<BookType>(typeof(BookType).Name);
            _order = _mongoContext.GetCollection<Order>(typeof(Order).Name);
        }
        /// <summary>
        /// Add new Book to MongoDb collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<Book> AddNewBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(typeof(Book).Name + "Object is Null");
                }
                _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
                await _book.InsertOneAsync(book);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return book;
        }
        /// <summary>
        /// Add new Book Type In MongoDb Collection
        /// </summary>
        /// <param name="bookType"></param>
        /// <returns></returns>
        public async Task<BookType> AddNewBookType(BookType bookType)
        {
            try
            {
                if(bookType == null)
                {
                    throw new ArgumentNullException(typeof(BookType).Name + "Object is Null");
                }
                _bookType = _mongoContext.GetCollection<BookType>(typeof(BookType).Name);
                await _bookType.InsertOneAsync(bookType);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return bookType;
        }
        /// <summary>
        /// Get list of all application User
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> AllApplicationUser()
        {
            try
            {
                var list = _mongoContext.GetCollection<ApplicationUser>("ApplicationUser")
                .Find(Builders<ApplicationUser>.Filter.Empty, null)
                .SortByDescending(e => e.UserId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all user order
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> AllUserOrder()
        {
            try
            {
                var list = _mongoContext.GetCollection<Order>("Order")
                .Find(Builders<Order>.Filter.Empty, null)
                .SortByDescending(e => e.UserId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete an existing Book by BookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBook(string bookId)
        {
            try
            {
                var objectId = new ObjectId(bookId);
                FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("BookId", objectId);
                var result = await _book.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete a n existing bookType by BookType Id
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBookType(string bookTypeId)
        {
            try
            {
                var objectId = new ObjectId(bookTypeId);
                FilterDefinition<BookType> filter = Builders<BookType>.Filter.Eq("BookTypeId", objectId);
                var result = await _bookType.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get BookType by Id
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        public async Task<BookType> GetBookTypeById(string bookTypeId)
        {
            try
            {
                var objectId = new ObjectId(bookTypeId);
                FilterDefinition<BookType> filter = Builders<BookType>.Filter.Eq("BookTypeId", objectId);
                _bookType = _mongoContext.GetCollection<BookType>(typeof(BookType).Name);
                return await _bookType.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<Book> UpdateBook(string bookId, Book book)
        {
            if (book == null && bookId == null)
            {
                throw new ArgumentNullException(typeof(Book).Name + "Object or may be BookId is Null");
            }
            var update = await _book.FindOneAndUpdateAsync(Builders<Book>.
                Filter.Eq("BookId", book.BookId), Builders<Book>.
                Update.Set("BookName", book.BookName).Set("Description", book.Description).Set("Author", book.Author)
                .Set("BookTypeId", book.BookTypeId).Set("PublisherId", book.PublisherId)
                .Set("PublishedOn", book.PublishedOn).Set("UnitPrice", book.UnitPrice).Set("Remark", book.Remark));
            return update;
        }
        /// <summary>
        /// Update an existing book type
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <param name="bookType"></param>
        /// <returns></returns>
        public async Task<BookType> UpdateBookType(string bookTypeId, BookType bookType)
        {
            if (bookType == null && bookTypeId == null)
            {
                throw new ArgumentNullException(typeof(BookType).Name + "Object or may be BookTypeId is Null");
            }
            var update = await _bookType.FindOneAndUpdateAsync(Builders<BookType>.
                Filter.Eq("BookTypeId", bookType.BookTypeId), Builders<BookType>.
                Update.Set("TypeofBook", bookType.TypeofBook).Set("Url", bookType.Url).Set("OpenInNewWindow", bookType.OpenInNewWindow)
                .Set("Description", bookType.Description));
            return update;
        }
    }
}
