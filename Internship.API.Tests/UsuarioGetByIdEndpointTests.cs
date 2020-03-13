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
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            //============= Test to controller ==========================
            var service = new Mock<IUserService>();
            service.Setup(s => s.Create(It.IsAny<User>())).Returns((User user) => { return user; });

            var controller = new UsersController(service.Object);
            var postId = "2";

            //Act  
            var data = controller.GetById(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new PostController(repository);
            var postId = "3";

            //Act  
            var data = UsersController.GetById(postId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UsersController(service.Object);
            int? postId = null;

            //Act  
            var data = await controller.GetById(postId);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_MatchResult()
        {
            //Arrange  
            var controller = new UsersController(service.Object);
            int? postId = "1";

            //Act  
            var data = await controller.GetById(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

            Assert.Equal("Test Title 1", post.Title);
            Assert.Equal("Test Description 1", post.Description);
        }
    }




    }
