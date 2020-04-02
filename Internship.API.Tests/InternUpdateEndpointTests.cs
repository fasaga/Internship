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

namespace Internship.API.InternUpdateEndpointTests
{
    public class InternUpdateEndpointTests : ControllerBase
    {
        [Fact]
        public void Controller_Update_ValidData_Return_OkResult()
        {
            //Arrange  

            //============= Test to controller ==========================
            var service = new Mock<IInternService>();
            service.Setup(s => s.GetInternById(It.IsAny<string>())).Returns((string id) => {
                return new Models.InternDTO()
                {
                    UserId = id,
                    FirstName = "test",
                    LastName = "last test"
                };
            });

            var controller = new InternsController(service.Object);
            var postId = "5e7bfb205ff5682df8c6e3d7";
            var post = new InternDTO();
            post.UserId = postId;
            post.FirstName = "test";
            post.LastName = "last test";
            //Act  
            var data = controller.Update(postId, post);

            //Assert  
            Assert.IsType<ActionResult<InternDTO>>(data);
            Assert.True(data.Value.UserId == postId);
            Assert.True(data.Value.FirstName == "test");
        }
    }
}
