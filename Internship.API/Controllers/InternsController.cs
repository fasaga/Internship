using Internship.API.Models;
using Internship.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Internship.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly IInternService _internService;
        private readonly IUserService _userService;
        private readonly IMentorService _mentorService;

        public InternsController(IInternService internService, IUserService userService, IMentorService mentorService)
        {
            _internService = internService;
            _userService = userService;
            _mentorService = mentorService;
        }

        /// <summary>
        /// Creates a new Intern in the application for an existing User.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/interns
        ///     {
        ///         "userId": "5e7a721921487c6b60743623",
        ///         "firstName": "humberto",
        ///         "lastName": "Del asdsd",
        ///         "email": "asdasd@hotmail.com",
        ///         "phone": "312-99-5487",
        ///         "startDate": "0001-01-01T00:00:00Z",
        ///         "endDate": "0001-01-01T00:00:00Z",
        ///         "activeTechnology": "net",
        ///         "status": "active",
        ///         "role": "intern",
        ///         "mentorId": "5e7a76db5fe004666c5e9702",
        ///         "comments": "Comments",
        ///         "technologies": ["net", "java"]
        ///     }
        ///     
        /// Sample error:
        ///     
        ///     {
        ///         "code": 400,
        ///         "description": "Validation failed",
        ///         "message": "The UserId field is required."
        ///     }
        /// </remarks>
        /// <param name="intern">Object of type Intern, contains all intern's information to be registered.</param>
        /// <returns>The created intern.</returns>
        /// <response code="200">Returns the created intern.</response>
        /// <response code="400">If the intern did not pass validation/ any other error</response>  
        [HttpPost]
        public ActionResult<InternDTO> Create(InternDTO intern)
        {
            try
            {
                SpecialCharacters specialCharacters = new SpecialCharacters();
                var FirstNameCheck = specialCharacters.CheckSpecialCharacters(intern.FirstName, "CharsSpecial");
                var LastNameCheck = specialCharacters.CheckSpecialCharacters(intern.LastName, "CharsSpecial");
                var EmailCheck = specialCharacters.CheckSpecialCharacters(intern.Email, "CharsEmail");
                var PhoneCheck = specialCharacters.CheckSpecialCharacters(intern.Phone, "CharsPhone");
                var StartDateCheck = specialCharacters.CheckFomatDate(intern.StartDate);
                var EndDateCheck = specialCharacters.CheckFomatDate(intern.EndDate);
                var StatusCheck = specialCharacters.CheckSpecialCharacters(intern.Status, "CharsSpecial");
                var RoleCheck = specialCharacters.CheckSpecialCharacters(intern.Role, "CharsSpecial");
                var ProjectCheck = specialCharacters.CheckSpecialCharacters(intern.Project, "CharsSpecial");
                var TeamCheck = specialCharacters.CheckSpecialCharacters(intern.Team, "CharsSpecial");
                var LeadCheck = specialCharacters.CheckSpecialCharacters(intern.Lead, "CharsSpecial");
                var resourceManagerCheck = specialCharacters.CheckSpecialCharacters(intern.ResourceManager, "CharsSpecial");

                if (FirstNameCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", FirstNameCheck));
                else if (LastNameCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", LastNameCheck));
                else if (EmailCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", EmailCheck));
                else if (PhoneCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", PhoneCheck));
                else if (StartDateCheck != true)
                    return BadRequest(new ApiError(400, "Invalid date format", intern.StartDate + ": Check the documentation about the date. Format: mm/dd/yyyy"));
                else if (intern.EndDate != null && EndDateCheck != true)
                    return BadRequest(new ApiError(400, "Invalid date format", intern.EndDate + ": Check the documentation about the date. Format: mm/dd/yyyy"));
                else if (StatusCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", StatusCheck));
                else if (RoleCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", RoleCheck));
                else if (ProjectCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", ProjectCheck));
                else if (TeamCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", TeamCheck));
                else if (LeadCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", LeadCheck));
                else if (resourceManagerCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", resourceManagerCheck));

                //validations section
                ///change to lowercase
                intern.Status = intern.Status.ToLower();
                intern.Role = intern.Role.ToLower();
                ///Valid only active or inactive
                if (intern.Status != "active" && intern.Status != "inactive")
                {
                    return BadRequest(new ApiError(400, "the status must be active or inactive"));

                }
                //verify that the Userid is not the same as the Mentorid
                if (intern.MentorId == intern.UserId)
                    return BadRequest(new ApiError(400, "Mentor id cannot be equals to User id", "Mentor id value cannot be the same as User id"));
                //Verify that the userid exists in the database
                UserDTO user = _userService.GetById(intern.UserId);
                if (user == null)
                    return NotFound(new ApiError(404, "User not found or already exist, $Verify the information"));
                if (user.Role != "intern")
                    return NotFound(new ApiError(404, "User is not an intern, Verify the information"));
                //Verify that the mentor exists in the database
                if (intern.MentorId != null && intern.MentorId != "")
                {
                    MentorDTO mentor = _mentorService.GetByMentorId(intern.MentorId);
                    if (mentor == null)
                        return NotFound(new ApiError(404, "Mentor not found", "Mentor does not exist"));
                }
                //call create method
                var newIntern = _internService.Create(intern);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created,newIntern);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }
        /// <summary>
        /// Get Intern by specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns a Intern
        /// </returns>
        [HttpGet("{id:length(24)}")]
        public ActionResult<InternDTO> GetInternById(string id)
        {
            try
            {
                var intern = _internService.GetInternById(id);
                if (intern == null)
                {
                    return NotFound(new ApiError(404, "User not found", $"Id: {id}"));

                }
                else
                {
                    return intern;
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }

        }
        /// <summary>
        /// Update a Intern in the application for an existing User.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/interns
        ///     {
        ///         "userId": "5e7a721921487c6b60743623",
        ///         "firstName": "humberto",
        ///         "lastName": "Del asdsd",
        ///         "email": "asdasd@hotmail.com",
        ///         "phone": "312-99-5487",
        ///         "startDate": "0001-01-01T00:00:00Z",
        ///         "endDate": "0001-01-01T00:00:00Z",
        ///         "activeTechnology": "net",
        ///         "status": "active",
        ///         "role": "intern",
        ///         "mentorId": "5e7a76db5fe004666c5e9702",
        ///         "comments": "Comments",
        ///         "technologies": ["net", "java"]
        ///     }
        ///     
        /// Sample error:
        ///     
        ///     {
        ///         "code": 400,
        ///         "description": "Validation failed",
        ///         "message": "The UserId field is required."
        ///     }
        /// </remarks>
        /// <param name="id">Interns id</param>
        /// <param name="internIn">Object of type Intern, Contains all intern's information to be update.</param>
        /// <returns>The updated intern.</returns>
        /// <response code="200">Returns the update intern.</response>
        /// <response code="400">If the intern did not pass validation/ any other error</response>  
        [HttpPut("{id:length(24)}")]
        public ActionResult<InternDTO> Update(string id, InternDTO internIn)
        {
            try
            {
                SpecialCharacters specialCharacters = new SpecialCharacters();
                var FirstNameCheck = specialCharacters.CheckSpecialCharacters(internIn.FirstName, "CharsSpecial");
                var LastNameCheck = specialCharacters.CheckSpecialCharacters(internIn.LastName, "CharsSpecial");
                var EmailCheck = specialCharacters.CheckSpecialCharacters(internIn.Email, "CharsEmail");
                var PhoneCheck = specialCharacters.CheckSpecialCharacters(internIn.Phone, "CharsPhone");
                var StartDateCheck = specialCharacters.CheckFomatDate(internIn.StartDate);
                var EndDateCheck = specialCharacters.CheckFomatDate(internIn.EndDate);
                var StatusCheck = specialCharacters.CheckSpecialCharacters(internIn.Status, "CharsSpecial");
                var RoleCheck = specialCharacters.CheckSpecialCharacters(internIn.Role, "CharsSpecial");
                var ProjectCheck = specialCharacters.CheckSpecialCharacters(internIn.Project, "CharsSpecial");
                var TeamCheck = specialCharacters.CheckSpecialCharacters(internIn.Team, "CharsSpecial");
                var LeadCheck = specialCharacters.CheckSpecialCharacters(internIn.Lead, "CharsSpecial");
                var resourceManagerCheck = specialCharacters.CheckSpecialCharacters(internIn.ResourceManager, "CharsSpecial");

                if (FirstNameCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", FirstNameCheck));
                else if (LastNameCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", LastNameCheck));
                else if (EmailCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", EmailCheck));
                else if (PhoneCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", PhoneCheck));
                else if (StartDateCheck != true)
                    return BadRequest(new ApiError(400, "Invalid date format", internIn.StartDate + ": Check the documentation about the date. Format: mm/dd/yyyy"));
                else if (internIn.EndDate != null && EndDateCheck != true)
                    return BadRequest(new ApiError(400, "Invalid date format", internIn.EndDate + ": Check the documentation about the date. Format: mm/dd/yyyy"));
                else if (StatusCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", StatusCheck));
                else if (RoleCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", RoleCheck));
                else if (ProjectCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", ProjectCheck));
                else if (TeamCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", TeamCheck));
                else if (LeadCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", LeadCheck));
                else if (resourceManagerCheck != "true")
                    return BadRequest(new ApiError(400, "Invalid characters", resourceManagerCheck));

                //validations section
                //validations section
                ///change to lowercase
                internIn.Status = internIn.Status.ToLower();
                internIn.Role = internIn.Role.ToLower();
                ///Valid only active or inactive
                if (internIn.Status != "active" && internIn.Status != "inactive")
                {
                    return BadRequest(new ApiError(400, "the status must be active or inactive"));

                }
                //verify that the Userid is not the same as the Mentorid
                if (internIn.MentorId == internIn.UserId)
                    return BadRequest(new ApiError(400, "Mentor id cannot be equals to User id", "Mentor id value cannot be the same as User id"));
                //Verify that the userid exists in the database
                UserDTO user = _userService.GetById(internIn.UserId);
                if (user == null)
                    return NotFound(new ApiError(404, "User not found, $Verify the information"));
                if (user.Role != "intern")
                    return NotFound(new ApiError(404, "User is not an intern, Verify the information"));
                //Verify that the mentor exists in the database
                if (internIn.MentorId != null && internIn.MentorId != "")
                {
                    MentorDTO mentor = _mentorService.GetByMentorId(internIn.MentorId);
                    if (mentor == null)
                        return NotFound(new ApiError(404, "Mentor not found", "Mentor does not exist"));
                }
                if (internIn.StartDate >= internIn.EndDate)

                    return BadRequest(new ApiError(400, "The end date must be greater than the start date"));

                if (internIn.EndDate > internIn.StartDate.AddMonths(6))
                    return BadRequest(new ApiError(400, "The EndDate Must not exceed 6 months"));


                if (internIn.EndDate == null)
                    internIn.EndDate = internIn.StartDate.AddMonths(6);



                _internService.Update(id, internIn);
                return _internService.GetInternById(id);

            }
            catch (Exception e)
            {
                return BadRequest(new ApiError(400, "Request failed", e.Message));
            }
        }
        /// <summary>
        /// Get all active interns registered
        /// </summary>
        /// <returns>
        /// a list of all the interns(only active interns) registered in the application 
        /// </returns>
        [HttpGet]
        public List<InternDTO> GetAll()
        {
            return _internService.GetAll();
        }
        /// <summary>
        /// Remove intern data and their related user from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Delete a Intern and their user
        /// return NoContent
        /// </returns>
        /// <response code="204">Returns no content.</response>
        /// <response code="400">Cannot delete this User</response>   
        [HttpDelete("{id:length(24)}")]
        public ActionResult<InternDTO> Delete(string id) {
         
            var intern =  _internService.GetInternById(id);

            if (intern==null)
            {
                return NotFound(new ApiError(404, "Intern not found", $"Id: {id}"));

            }
            ///Delete Intern information
            _internService.Remove(id);
            ///Remove the information of the intern in the user table 
            _userService.Remove(id);
            return NoContent();

        }

    }

}