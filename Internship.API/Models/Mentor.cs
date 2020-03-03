using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Internship.API.Models
{
    public class Mentor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public int MentorId { get; set; }

        [Required]
        public string first_name { get; set; } 

        [Required]
        public string last_name { get; set; }

        [Required]
        public string email { get; set; }
        public string phone { get; set; }

        [Required]
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string active_technology { get; set; }

        [Required]
        public string status { get; set; }
        public List<String> interns { get; set; }
    }
}
