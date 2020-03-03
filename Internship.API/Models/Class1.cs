using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace InternApiModel.Models
{
    public class InternrModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("Intern")]
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MentorId { get; set; }
        public string TechnologiesSummary { get; set; }
        public int InitialEnglishLevel { get; set; }
        public int FinalEnglishLevel { get; set; }
        public boolean Hired { get; set; }
        public int HiredSprintId { get; set; }
        public string Location { get; set; }
        public string fourthSourceOrg { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Team { get; set; }
        public string Lead { get; set; }
        public string ResourceManager { get; set; }
        public string Comment { get; set; }
}

public class TechnologiesSummary
{
    public string starting { get; set; }
    public string final { get; set; }

}
}