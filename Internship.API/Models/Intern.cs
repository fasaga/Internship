using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Internship.API.Models
{
    public class Intern
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("mentor_id")]
        public string MentorId { get; set; }
        [BsonElement("technologies")]
        public string[] Technologies { get; set; }
        [BsonElement("starting_technology")]
        public string StartingTechnology { get; set; }
        [BsonElement("final_technology")]
        public string FinalTechnology { get; set; }
        [BsonElement("initial_english_level")]
        public int InitialEnglishLevel { get; set; }
        [BsonElement("final_english_level")]
        public int FinalEnglishLevel { get; set; }
        [BsonElement("hired")]
        public bool Hired { get; set; }
        [BsonElement("hired_sprint_id")]
        public int HiredSprintId { get; set; }
        [BsonElement("location")]
        public string Location { get; set; }
        [BsonElement("4th_source_org")]
        public string FourthSourceOrg { get; set; }
        [BsonElement("client")]
        public string Client { get; set; }
        [BsonElement("project")]
        public string Project { get; set; }
        [BsonElement("team")]
        public string Team { get; set; }
        [BsonElement("lead")]
        public string Lead { get; set; }
        [BsonElement("resource_manager")]
        public string ResourceManager { get; set; }
        [BsonElement("comments")]
        public string Comments { get; set; }
        [BsonElement("role")]
        public string Role { get; set; }
    }
}
