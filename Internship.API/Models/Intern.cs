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
        /// <summary>
        /// Id of the mentor
        /// </summary>
        [BsonElement("mentor_id")]
        public string MentorId { get; set; }
        /// <summary>
        /// Technologies used by the intern
        /// </summary>
        [BsonElement("technologies")]
        public string[] Technologies { get; set; }
        /// <summary>
        /// Technology that Intern Start
        /// </summary>
        [BsonElement("starting_technology")]
        public string StartingTechnology { get; set; }
        /// <summary>
        /// Final Technology of the intern
        /// </summary>
        [BsonElement("final_technology")]
        public string FinalTechnology { get; set; }
        /// <summary>
        /// Intern's english level at the beginning
        /// </summary>
        [BsonElement("initial_english_level")]
        public int InitialEnglishLevel { get; set; }
        /// <summary>
        /// Intern's english level at the end
        /// </summary>
        [BsonElement("final_english_level")]
        public int FinalEnglishLevel { get; set; }
        /// <summary>
        /// If the Intern was hired in the internship period (true or false)
        /// </summary>
        [BsonElement("hired")]
        public bool Hired { get; set; }
        /// <summary>
        /// Sprint where the intern was hired
        /// </summary>
        [BsonElement("hired_sprint_id")]
        public int HiredSprintId { get; set; }
        /// <summary>
        /// Location of the company that Intern works
        /// </summary>
        [BsonElement("location")]
        public string Location { get; set; }
        /// <summary>
        /// Name of the administrative division in which the intern works
        /// </summary>
        [BsonElement("4th_source_org")]
        public string FourthSourceOrg { get; set; }
        /// <summary>
        /// Client for the Intern work
        /// </summary>
        [BsonElement("client")]
        public string Client { get; set; }
        /// <summary>
        /// Project the intern is working on
        /// </summary>
        [BsonElement("project")]
        public string Project { get; set; }
        /// <summary>
        /// Name of the Intership team
        /// </summary>
        [BsonElement("team")]
        public string Team { get; set; }
        /// <summary>
        /// Team leader's name
        /// </summary>
        [BsonElement("lead")]
        public string Lead { get; set; }
        /// <summary>
        /// Name of the Resource Manager
        /// </summary>
        [BsonElement("resource_manager")]
        public string ResourceManager { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        [BsonElement("comments")]
        public string Comments { get; set; }
    }
}
