using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Internship.API.Models
{
    public class Intern
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MentorId { get; set; }
        public TechnologiesSummary TechnologiesSummary { get; set; }
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
        public string Comment { get; set; }
    }
}
