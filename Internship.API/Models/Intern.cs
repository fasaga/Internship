using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

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
        [BsonElement("Technologies_Summary")]
        public TechnologiesSummary TechnologiesSummary { get; set; }
        [BsonElement("Initial_EnglishLevel")]
        public int InitialEnglishLevel { get; set; }
        [BsonElement("Final_EnglishLevel")]
        public int FinalEnglishLevel { get; set; }
        [BsonElement("Hired")]
        public bool Hired { get; set; }
        [BsonElement("Hired_Sprint")]
        public int HiredSprintId { get; set; }
        [BsonElement("Location")]
        public string Location { get; set; }
        [BsonElement("FourthSourceOrg")]
        public string FourthSourceOrg { get; set; }
        [BsonElement("client")]
        public string Client { get; set; }
        [BsonElement("project")]
        public string Project { get; set; }
        [BsonElement("team")]
        public string Team { get; set; }
        [BsonElement("lead")]
        public string Lead { get; set; }
        [BsonElement("resourcemanager")]
        public string ResourceManager { get; set; }
        [BsonElement("comment")]
        public string Comment { get; set; }
    }
}
