using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TechnologiesSummaryModel.Models
{
    public class TechnologiesSummary
    {
        public string starting { get; set; }
        public string final { get; set; }

    }
}
