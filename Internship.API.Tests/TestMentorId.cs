using Internship.API.Controllers;
using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Internship.API.Tests
{
    public class UsuarioGetByIdEndpointTests : ControllerBase
    {
        [Fact]
        public void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            //============= Test to controller ==========================
            var service = new Mock<IMentorService>();
            service.Setup(s => s.GetListInterns(It.IsAny<string>())).Returns((string id) =>
            {
                return new Models.Mentor()
                {
                    MentorId = id,
                    FirstName = "test",
                    LastName = "last test"
                };
            });



            var controller = new MentorsController(service.Object);
            var postId = "5e62d9aef1ce012050c3b5be";
            //Act  
            var data = controller.GetListInterns(postId);

            //Assert  
            Assert.IsType<ActionResult<Mentor>>(data);
            Assert.True(data.Value.MentorId == postId);
            Assert.True(data.Value.FirstName == "test");
        }
        [Fact]
        public void Task_GetPostById_Return_NotFoundResult()
        {
            var service = new Mock<IMentorService>();
            //Arrange  
            var controller = new MentorsController(service.Object);
            var postId = "5e62d9aef1ce012050c3b5be";



            //Act  
            var data = controller.GetListInterns(postId);



            //Assert  
            Assert.IsType<ActionResult<Mentor>>(data);
            Assert.Null(data.Value);
        }

    }
}
