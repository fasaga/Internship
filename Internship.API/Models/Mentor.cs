using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Internship.API.Models
{
    public class Mentor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string MentorId { get; set; }

        /// <summary>
        /// First name of the Mentor
        /// </summary>
        [BsonElement("first_name")]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name of the Mentor
        /// </summary>
        [BsonElement("last_name")]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Email of the Mentor
        /// </summary>
        [BsonElement("email")]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Phone of the Mentor
        /// </summary>
        [BsonElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The date when the Mentor joined the company 
        /// </summary>
        [BsonElement("start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date when the Mentor left the company
        /// </summary>
        [BsonElement("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Technology used by the Mentor
        /// </summary>
        [BsonElement("active_technology")]
        public string ActiveTechnology { get; set; }

        /// <summary>
        /// Status of the Mentor (active or inactive)
        /// </summary>
        [BsonElement("status")]
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// Role of the user (admin,intern,mentor)
        /// </summary>
        [JsonIgnore]
        [BsonElement("role")]
        public string Role { get; set; }

        /// <summary>
        /// List of interns assigned to the mentor
        /// </summary>
        public List<String> Interns { get; set; }
    }
}
