using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Models
{
    public class InternDTO
    {
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// First Name of the User
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of the User
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email of the User
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone of the User
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// The date when the user joined the company 
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The date when the user left the company
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Technology used by the user
        /// </summary>
        public string ActiveTechnology { get; set; }
        /// <summary>
        /// Status of the user (active or inactive)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// role of the user (admin,intern,mentor)
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Id of the mentor
        /// </summary>
        public string MentorId { get; set; }
        /// <summary>
        /// Technologies used by the intern
        /// </summary>
        public string[] Technologies { get; set; }
        /// <summary>
        /// Technology that Intern Start
        /// </summary>
        public string StartingTechnology { get; set; }
        /// <summary>
        /// Final Technology of the intern
        /// </summary>
        public string FinalTechnology { get; set; }
        /// <summary>
        /// Intern's english level at the beginning
        /// </summary>
        public int InitialEnglishLevel { get; set; }
        /// <summary>
        /// Intern's english level at the end
        /// </summary>
        public int FinalEnglishLevel { get; set; }
        /// <summary>
        /// If the Intern was hired in the internship period (true or false)
        /// </summary>
        public bool Hired { get; set; }
        /// <summary>
        /// Sprint where the intern was hired
        /// </summary>
        public int HiredSprintId { get; set; }
        /// <summary>
        /// Location of the company that Intern works
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Name of the administrative division in which the intern works
        /// </summary>
        public string FourthSourceOrg { get; set; }
        /// <summary>
        /// Client for the Intern work
        /// </summary>
        public string Client { get; set; }
        /// <summary>
        /// Project the intern is working on
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// Name of the Intership team
        /// </summary>
        public string Team { get; set; }
        /// <summary>
        /// Team leader's name
        /// </summary>
        public string Lead { get; set; }
        /// <summary>
        /// Name of the Resource Manager
        /// </summary>
        public string ResourceManager { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Mentor´s info of the Intern
        /// </summary>
        public MentorDTO Mentor { get; set; }

        internal void LoadUserInfo(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Phone = user.Phone;
            StartDate = user.StartDate;
            EndDate = user.EndDate;
            ActiveTechnology = user.ActiveTechnology;
            Status = user.Status;
            Role = user.Role;
        }

        internal void LoadMentorInfo(User mentor)
        {
            Mentor = new MentorDTO()
            {
                UserId = mentor.UserId,
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Email = mentor.Email,
                Phone = mentor.Phone,
                StartDate = mentor.StartDate,
                EndDate = mentor.EndDate,
                ActiveTechnology = mentor.ActiveTechnology,
                Status = mentor.Status,
                Role = mentor.Role
            };
        }
    }
}
