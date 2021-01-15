using Moq;
using OnlineBookReselling.BusinessLayer.Interfaces;
using OnlineBookReselling.BusinessLayer.Services;
using OnlineBookReselling.BusinessLayer.Services.Repository;
using OnlineBookReselling.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineBookReselling.Test.TestCases
{
    public class ExceptionalTest
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
        public ExceptionalTest()
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
        static ExceptionalTest()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// This Method is used for test Add Valid Appointment is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_AddBook()
        {
            //Arrange
            bool res = false;
            _book = null;
            //Act
            adminService.Setup(repo => repo.AddNewBook(_book)).ReturnsAsync(_book = null);
            var result = await _adminResellingServices.AddNewBook(_book);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_AddBook=" + res + "\n");
            return res;
        }
        /// <summary>
        /// This Method is used for test Add Valid Application User is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_User()
        {
            //Arrange
            bool res = false;
            _user = null;
            //Act
            bookServices.Setup(repo => repo.RegisterUser(_user)).ReturnsAsync(_user = null);
            var result = await _bookResellingServices.RegisterUser(_user);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_User=" + res + "\n");
            return res;
        }
        /// <summary>
        /// This Method is used for test Add Valid BookType is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_AddBookType()
        {
            //Arrange
            bool res = false;
            _bookType = null;
            //Act
            adminService.Setup(repo => repo.AddNewBookType(_bookType)).ReturnsAsync(_bookType = null);
            var result = await _adminResellingServices.AddNewBookType(_bookType);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_AddBookType=" + res + "\n");
            return res;
        }
    }
}
