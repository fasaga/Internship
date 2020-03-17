using Internship.API.Controllers;
using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Internship.API.UsuarioGetByIdEndpointTest
{
    public class UsuarioGetByIdEndpointTests : ControllerBase
    {

        [Fact]
        public void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            //============= Test to controller ==========================
            var service = new Mock<IUserService>();
            service.Setup(s => s.GetById(It.IsAny<string>())).Returns((string id) => {
                return new Models.User()
                {
                    UserId = id,
                    FirstName = "test",
                    LastName = "last test"
                };
            });

            var controller = new UsersController(service.Object);
            var postId = "5e659f85481f2c08e41d5a0a";

            //Act  
            var data = controller.GetById(postId);

            //Assert  
            Assert.IsType<ActionResult<User>>(data);
            Assert.True(data.Value.UserId == postId);
            Assert.True(data.Value.FirstName == "test");
        }

        [Fact]
        public void Task_GetPostById_Return_NotFoundResult()
        {
            var service = new Mock<IUserService>();
            //Arrange  
            var controller = new UsersController(service.Object);
            var postId = "5e659f85481f2c08e41d5a1a";

            //Act  
            var data = controller.GetById(postId);

            //Assert  
            Assert.IsType<ActionResult<User>>(data);
            Assert.Null(data.Value);
        }

        [Fact]
        public void Task_GetPostById_Return_BadRequestResult()
        {
            var service = new Mock<IUserService>();
            //Arrange  
            var controller = new UsersController(service.Object);
            string postId = null;

            //Act  
            var data = controller.GetById(postId);

            //Assert  
            Assert.IsType<ActionResult<User>>(data);
            Assert.Null(data.Value);
        }

    }
}