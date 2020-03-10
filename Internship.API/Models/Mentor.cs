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

        [BsonElement("first_name")]
        [Required]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        [Required]
        public string LastName { get; set; }

        [BsonElement("email")]
        [Required]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [BsonElement("end_date")]
        public DateTime EndDate { get; set; }

        [BsonElement("active_technology")]
        public string ActiveTechnology { get; set; }

        [BsonElement("status")]
        [Required]
        public string Status { get; set; }

        [JsonIgnore]
        [BsonElement("role")]
        public string Role { get; set; }
        public List<String> Interns { get; set; }
    }
}
