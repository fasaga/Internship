using Internship.API.Controllers;
using Internship.API.Models;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Internship.API.MentorsGetEndPointTest
{
    public class MentorsGetEndPointTest : ControllerBase
    {
        [Fact]
        public async void Task_GetMentors_Controller()
        {
            var service = new Mock<IMentorService>();
            service.Setup(s => s.Get()).Returns(new List<Mentor>());


            var controller = new MentorsController(service.Object);


            //Act  
            var data = controller.Get();

            //Assert  
            Assert.IsType<List<Mentor>>(data);
        }
        [Fact]
        public async void Task_GetMentors_Services()
        {
            var service = new Mock<IMentorRepository>();
            service.Setup(s => s.Get()).Returns(new List<Mentor>());


            var controller = new MentorService(service.Object);


            //Act  
            var data = controller.Get();

            //Assert  
            Assert.IsType<List<Mentor>>(data);
        }




    }
}
