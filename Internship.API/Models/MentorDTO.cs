using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Models
{
    public class MentorDTO
    {
        /// <summary>
        /// Unique user id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// First name of the User
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of the User
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Email of the User
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Phone of the User
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// The date when the user joined the company 
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
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
        [Required]
        public string Status { get; set; }
        /// <summary>
        /// role of the user (admin,intern,mentor)
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// List of interns assigned to the mentor
        /// </summary>
        public List<InternDTO> Interns { get; set; }
    }
}
