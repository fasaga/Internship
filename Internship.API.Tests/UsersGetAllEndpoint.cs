/*using Internship.API.Controllers;
using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Internship.API.UsersGetAllEndpoint

{
    public class UsersGetAllEndpoint : ControllerBase
    {
        [Fact]  //============= Test to controller ==========================
        public void Task_GetAllUsers_Controller()
        {
            //Arrange 
            var service = new Mock<IUserService>();
            service.Setup(s => s.GetAll()).Returns(new List<User>());
            var controller = new UsersController(service.Object);
            //Act  
            var data = controller.GetAll();
            //Assert  
            Assert.IsType<List<User>>(data);
        }
        [Fact]  //============= Test to Service ==========================
        public void Task_GetAllUsers_Services()
        {
            //Arrange 
            var service = new Mock<IUserRepository>();
            service.Setup(s => s.GetAll()).Returns(new List<User>());
            var controller = new UserService(service.Object);
            //Act  
            var data = controller.GetAll();
            //Assert  
            Assert.IsType<List<User>>(data);
        }




    }
}*/
