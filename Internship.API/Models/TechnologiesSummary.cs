using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TechnologiesSummaryModel.Models
{
    public class TechnologiesSummary
    {
        public string Starting { get; set; }
        public string Final { get; set; }
        public string[] All { get; set; }
    }
}
