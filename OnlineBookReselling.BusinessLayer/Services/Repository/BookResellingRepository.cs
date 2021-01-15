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
    public class BookResellingRepository : IBookResellingRepository
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
        public BookResellingRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _applicationUser = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
            _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
            _bookType = _mongoContext.GetCollection<BookType>(typeof(BookType).Name);
            _order = _mongoContext.GetCollection<Order>(typeof(Order).Name);
        }
        /// <summary>
        /// Order a book by providing bookid and user info
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Book> BookOrder(string bookId, ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                var objectId = new ObjectId(bookId);
                FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("BookId", objectId);
                _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
                var bookbyId =  await _book.FindAsync(filter).Result.FirstOrDefaultAsync();
                if (bookbyId != null)
                {
                    var bookOrder = new Order()
                    {
                        UserId = user.UserId,
                        UserEmail = user.Email,
                        BookId = bookId,
                        BookName = bookbyId.BookName,
                        Amount = bookbyId.UnitPrice
                    };
                    _order = _mongoContext.GetCollection<Order>(typeof(Order).Name);
                    await _order.InsertOneAsync(bookOrder);
                }
                return bookbyId;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get a list of BookType
        /// </summary>
        /// <returns></returns>
        public IList<BookType> BookTypeList()
        {
            try
            {
                var list = _mongoContext.GetCollection<BookType>("BookType")
                .Find(Builders<BookType>.Filter.Empty, null)
                .SortByDescending(e => e.TypeofBook);
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Book>> FindBook(string name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Book>();
                var findName = filterBuilder.Eq(s => s.BookName, name);
                var findAuthor = filterBuilder.Eq(s => s.Author, name.ToString());
                _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
                var result = await _book.FindAsync(findName | findAuthor).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get All Book from MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> GetAllBook()
        {
            try
            {
                var list = _mongoContext.GetCollection<Book>("Book")
                .Find(Builders<Book>.Filter.Empty, null)
                .SortByDescending(e => e.BookId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get book by booktype
        /// </summary>
        /// <param name="bookTypeId"></param>
        /// <returns></returns>
        public async Task<Book> GetBookByBookType(string bookTypeId)
        {
            try
            {
                var objectId = new ObjectId(bookTypeId);
                FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("bookTypeId", objectId);
                _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
                return await _book.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get book details by Book Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<Book> GetBookDetailsById(string bookId)
        {
            try
            {
                var objectId = new ObjectId(bookId);
                FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("bookId", objectId);
                _book = _mongoContext.GetCollection<Book>(typeof(Book).Name);
                return await _book.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get User Details by User Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUserDetailsById(string UserId)
        {
            try
            {
                var objectId = new ObjectId(UserId);
                FilterDefinition<ApplicationUser> filter = Builders<ApplicationUser>.Filter.Eq("UserId", objectId);
                _applicationUser = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                return await _applicationUser.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Book Usr order infromation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> OrderInformation(string email)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Order>();
                var orderInfo = filterBuilder.Eq(s => s.UserEmail, email);
                _order = _mongoContext.GetCollection<Order>(typeof(Order).Name);
                var result = await _order.FindAsync(orderInfo).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Register a new user for this application. and for purchase and give any order
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                _applicationUser = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                await _applicationUser.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return user;
        }

        public async Task<ApplicationUser> VerifyUser(string email, string password)
        {
            try
            {
                var emailId = Builders<ApplicationUser>.Filter.Eq("Email", email);
                var pass = Builders<ApplicationUser>.Filter.Eq("Password", password);
                var filterCriteria = Builders<ApplicationUser>.Filter.And(emailId, pass);
                var userFind = await _applicationUser.FindAsync(filterCriteria);
                return userFind.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
