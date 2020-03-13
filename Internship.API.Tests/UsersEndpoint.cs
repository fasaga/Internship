using Xunit;
using System;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Internship.API.Models;
using Internship.API.Controllers;
using Internship.API.Services.Interfaces;

namespace Internship.API.Tests
{
    public class UsersEndpoint
    {
        [Fact]
        public void Controller_Add_ValidData_ReturnOkResult()
        {
            //============= TesT controller ==========================
            var service = new Mock<IUserService>();
            service.Setup(s => s.Create(It.IsAny<User>())).Returns((User user) => { return user; });

            //Arrange  
            var controller = new UsersController(service.Object);
            var user = new User()
            //New User
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
        
    }
}
    
