﻿using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Internship.API.Models
{
    public class Mentor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Mentor")]

        public int Id { get; set; }

        [Required]
        public string FistName { get; set; } 

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ActiveTechnology { get; set; }

        [Required]
        public string Status { get; set; }
        public string Interns { get; set; }
    }
}
