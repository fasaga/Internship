using Internship.API.Controllers;
using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Internship.API.InternsGetAllEndpoint

{
    public class InternsGetAllEndpoint : ControllerBase
    {
        [Fact]  //============= Test to controller ==========================
        public void Task_GetAlInterns_Controller()
        {
            //Arrange 
            var service = new Mock<IInternService>();
            service.Setup(s => s.GetAll()).Returns(new List<Intern>());
            var controller = new InternsController(service.Object);
            //Act  
            var data = controller.GetAll();
            //Assert  
            Assert.IsType<List<Intern>>(data);
        }
        [Fact]  //============= Test to Service ==========================
        public void Task_GetAllInterns_Services()
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
}
