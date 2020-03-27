/*using Xunit;
using Microsoft.AspNetCore.Mvc;
using Internship.API.Controllers;
using Internship.API.Models;
using Internship.API.Services.Interfaces;
using System;
using Moq;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services;

namespace Internship.API.Tests
{
    public class InternCreateEndpointTests : ControllerBase
    {
        /// <summary>
        /// Unit test of the Controller to create users. -It is checked that it is not null. - It is checked that the mail is the same one that was sent
        /// </summary>
        [Fact]
        public void Controller_Add_ValidData_Return_OkResult()
        {
            //============= Test to controller ==========================
            var service = new Mock<IUserService>();
            service.Setup(s => s.Create(It.IsAny<User>())).Returns((User user) => { return user; });

            //Arrange  
            var controller = new UsersController(service.Object);
            var user = new User()
            {
                FirstName = "Lucia",
                LastName = "Gomez",
                Email = "lucia@hotmail.com",
                StartDate = DateTime.Parse("2020-03-01T00:00:00Z"),
                Status = "active",
                Role = "intern"
            };

            //Act  
            var data = controller.Create(user);

            //Assert  
            Assert.IsType<ActionResult<User>>(data);
            Assert.NotNull(data);
            Assert.True(data.Value.Email.Equals("lucia@hotmail.com"));
        }
        /// <summary>
        /// Unit test of the Service to create users. -It is checked that it is not null. - It is checked that the mail is the same one that was sent
        /// </summary>
        [Fact]
        public void Service_Add_ValidData_Return_OkResult()
        {
            //============= Test to service ===========================
            var service = new Mock<IUserRepository>();
            service.Setup(s => s.Create(It.IsAny<User>())).Returns((User user) => { return user; });

            //Arrange  
            var controller = new UserService(service.Object);
            var user = new User()
            {
                FirstName = "Lucia",
                LastName = "Gomez",
                Email = "lucia@hotmail.com",
                StartDate = DateTime.Parse("2020-03-01T00:00:00Z"),
                Status = "active",
                Role = "intern"
            };

            //Act  
            var data = controller.Create(user);

            //Assert  
            Assert.NotNull(data);
            Assert.True(data.Email.Equals("lucia@hotmail.com"));
        }
    }
}*/
