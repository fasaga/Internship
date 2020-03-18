﻿using System;
using System.Collections.Generic;
using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Internship.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorsController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }
        [HttpGet]
        public List<Mentor> Get()
        {
            return _mentorService.Get();
        }



        [HttpGet("{mentorId:length(24)}")]
         public ActionResult<Mentor> GetListInterns(String mentorId)
         {
             var mentor = _mentorService.GetListInterns(mentorId);

             if (mentor == null)
             {
                 return NotFound();
             }

             return mentor;
         }
    }
}
