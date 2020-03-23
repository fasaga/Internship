using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Internship.API.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// First name of the User
        /// </summary>
        [BsonElement("first_name")]
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of the User
        /// </summary>
        [BsonElement("last_name")]
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Email of the User
        /// </summary>
        [BsonElement("email")]
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Phone of the User
        /// </summary>
        [BsonElement("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// The date when the user joined the company 
        /// </summary>
        [BsonElement("start_date")]
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The date when the user left the company
        /// </summary>
        [BsonElement("end_date")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Technology used by the user
        /// </summary>
        [BsonElement("active_technology")]
        public string ActiveTechnology { get; set; }
        /// <summary>
        /// Status of the user (active or inactive)
        /// </summary>
        [BsonElement("status")]
        [Required]
        public string Status { get; set; }
        /// <summary>
        /// role of the user (admin,intern,mentor)
        /// </summary>
        [BsonElement("role")]
        public string Role { get; set; }

    }
}
