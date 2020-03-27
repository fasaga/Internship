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
    public class GetInternByIdEndpointTests : ControllerBase
    {

        [Fact]
        public void GetInternByIdEndpoint()
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
            var postId = "5e659f85481f2c08e41d5a0a";

            //Act  
            var data = controller.GetInternById(postId);

            //Assert  
            Assert.IsType<ActionResult<InternDTO>>(data);
            Assert.True(data.Value.UserId == postId);
            Assert.True(data.Value.FirstName == "test");
        }

        

    }
}