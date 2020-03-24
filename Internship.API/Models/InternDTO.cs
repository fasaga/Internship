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
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// The date when the user left the company
        /// </summary>
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
        public string MentorId { get; set; }
        public string[] Technologies { get; set; }
        public string StartingTechnology { get; set; }
        public string FinalTechnology { get; set; }
        public int InitialEnglishLevel { get; set; }
        public int FinalEnglishLevel { get; set; }
        public bool Hired { get; set; }
        public int HiredSprintId { get; set; }
        public string Location { get; set; }
        public string FourthSourceOrg { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Team { get; set; }
        public string Lead { get; set; }
        public string ResourceManager { get; set; }
        public string Comments { get; set; }

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
    }
}
