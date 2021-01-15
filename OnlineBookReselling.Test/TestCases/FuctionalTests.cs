using Moq;
using OnlineBookReselling.BusinessLayer.Interfaces;
using OnlineBookReselling.BusinessLayer.Services;
using OnlineBookReselling.BusinessLayer.Services.Repository;
using OnlineBookReselling.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace OnlineBookReselling.Test.TestCases
{
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance of all Service Interfaces and Mocking All Repository
        /// </summary>
        private readonly IAdminBookResellingServices _adminResellingServices;
        private readonly IBookResellingServices _bookResellingServices;
        public readonly Mock<IAdminBookResellingRepository> adminService = new Mock<IAdminBookResellingRepository>();
        public readonly Mock<IBookResellingRepository> bookServices = new Mock<IBookResellingRepository>();
        private ApplicationUser _user;
        private Book _book;
        private BookType _bookType;
        private Order _order;
        public FuctionalTests()
        {
            _adminResellingServices = new AdminBookResellingServices(adminService.Object);
            _bookResellingServices = new BookResellingServices(bookServices.Object);
            _user = new ApplicationUser
            {
                UserId = "5ff462f59c249e27020bffba",
                Name = "Uma Kumar",
                Email = "umakumarsingh@gmail.com",
                MobileNumber = 9865253568,
                PinCode = 820003,
                HouseNo_Building_Name = "9/11",
                Road_area = "Road_area",
                City = "Gaya",
                State = "Bihar"
            };
            _book = new Book
            {
                BookId = "5ff462f59c249e27020bffba",
                BookName = ".Net Core",
                Description = "Learn .net Core",
                Author = "TIm Cook",
                BookTypeId = "5ff462f59c249e27020bffba",
                PublisherId = "5ff462f59c249e27020bffba",
                PublishedOn = DateTime.Now,
                UnitPrice = 458,
                Remark = "Useful for .net core Developer"
            };
            _bookType = new BookType
            {
                BookTypeId = "5ff462f59c249e27020bffba",
                TypeofBook = "Programming",
                Url = "~/",
                OpenInNewWindow = false,
                Description = "Menu Bar"
            };
            _order = new Order
            {
                OrderId = "5ff462f59c249e27020bffba",
                UserId = "5ff462f59c249e27020bffba",
                UserEmail = "uma@gmail.com",
                BookId = "5ff462f59c249e27020bffba",
                BookName = ".Net Core",
                Amount = 784
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Using this test case method try to get all book and all bokk by bookType Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetAllBook()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.GetAllBook());
            var result = await _bookResellingServices.GetAllBook();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetAllBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Book by book Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBookDetailsById()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.GetBookDetailsById(_book.BookId)).ReturnsAsync(_book);
            var result = await _bookResellingServices.GetBookDetailsById(_book.BookId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetBookDetailsById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Book Type by book type Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBookTypesById()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.GetBookByBookType(_book.BookTypeId)).ReturnsAsync(_book);
            var result = await _bookResellingServices.GetBookByBookType(_book.BookTypeId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetBookTypesById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get book by Name, Author, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindBook_By_Name_Author()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.FindBook(_book.BookName));
            var result = await _bookResellingServices.FindBook(_book.BookName);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_FindBook_By_Name_Author=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Register a user return async return _user object of user
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Take_RegisterUser()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.RegisterUser(_user)).ReturnsAsync(_user);
            var result = await _bookResellingServices.RegisterUser(_user);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Take_RegisterUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Applicaton User by User Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetUserDetailsById()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.GetUserDetailsById(_user.UserId)).ReturnsAsync(_user);
            var result = await _bookResellingServices.GetUserDetailsById(_user.UserId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetUserDetailsById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Verify Applicaton User by Email Id amd Password, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_VerifyUserDetails()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.VerifyUser(_user.Email, _user.Password)).ReturnsAsync(_user);
            var result = await _bookResellingServices.VerifyUser(_user.Email, _user.Password);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_VerifyUserDetails=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Book a order of book return async return _book object of worki fine.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Take_BookOrder()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.BookOrder(_book.BookId, _user)).ReturnsAsync(_book);
            var result = await _bookResellingServices.BookOrder(_book.BookId, _user);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Take_BookOrder=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test case method try to get all book list.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_BookTypeList()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.BookTypeList());
            var result = _bookResellingServices.BookTypeList();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_BookTypeList=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get User order information by User EmilId, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetUser_OrderInformation()
        {
            //Arrange
            var res = false;
            //Action
            bookServices.Setup(repos => repos.OrderInformation(_user.Email));
            var result = await _bookResellingServices.OrderInformation(_user.Email);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetUser_OrderInformation=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test case method try to get all User Order
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllUserOrder()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllUserOrder());
            var result = await _adminResellingServices.AllUserOrder();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_AllUserOrder=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test case method try to get all registred Application User
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllApplicationUser()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllApplicationUser());
            var result = await _adminResellingServices.AllApplicationUser();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_AllApplicationUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Add new book and return _book object if true test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_AddNewBook()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AddNewBook(_book)).ReturnsAsync(_book);
            var result = await _adminResellingServices.AddNewBook(_book);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Take_AddNewBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Book by Book Id and _bookUpdate Collection
        /// if get updated then test Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateBook()
        {
            //Arrange
            bool res = false;
            var _bookUpdate = new Book
            {
                BookId = "5ff462f59c249e27020bffba",
                BookName = ".Net Core",
                Description = "Learn .net Core",
                Author = "TIm Cook",
                BookTypeId = "5ff462f59c249e27020bffba",
                PublisherId = "5ff462f59c249e27020bffba",
                PublishedOn = DateTime.Now,
                UnitPrice = 458,
                Remark = "Useful for .net core Developer"
            };
            //Act
            adminService.Setup(repo => repo.UpdateBook(_bookUpdate.BookId, _bookUpdate)).ReturnsAsync(_bookUpdate);
            var result = await _adminResellingServices.UpdateBook(_bookUpdate.BookId, _bookUpdate);
            if (result == _bookUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete Book by Book Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteBook()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteBook(_book.BookId)).ReturnsAsync(true);
            var resultDelete = await _adminResellingServices.DeleteBook(_book.BookId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Add new book type and return _booktype object if true test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_AddNewBookType()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AddNewBookType(_bookType)).ReturnsAsync(_bookType);
            var result = await _adminResellingServices.AddNewBookType(_bookType);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_AddNewBookType=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing BookType by Booktype Id and _booktypeUpdate Collection
        /// if get updated then test Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateBookType()
        {
            //Arrange
            bool res = false;
            var _booktypeUpdate = new BookType
            {
                BookTypeId = "5ff462f59c249e27020bffba",
                TypeofBook = "Programming",
                Url = "~/",
                OpenInNewWindow = false,
                Description = "Menu Bar"
            };
            //Act
            adminService.Setup(repo => repo.UpdateBookType(_booktypeUpdate.BookTypeId, _booktypeUpdate)).ReturnsAsync(_booktypeUpdate);
            var result = await _adminResellingServices.UpdateBookType(_booktypeUpdate.BookTypeId, _booktypeUpdate);
            if (result == _booktypeUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateBookType=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Book type by booktype Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBookTypeById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.GetBookTypeById(_bookType.BookTypeId)).ReturnsAsync(_bookType);
            var result = await _adminResellingServices.GetBookTypeById(_bookType.BookTypeId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetBookTypeById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete Book Type by Booktype Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteBookType()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteBookType(_bookType.BookTypeId)).ReturnsAsync(true);
            var resultDelete = await _adminResellingServices.DeleteBookType(_bookType.BookTypeId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteBookType=" + res + "\n");
            return res;
        }
    }
}
