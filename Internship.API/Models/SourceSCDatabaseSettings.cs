using System;

namespace Intership.API.Models
{
    public class SourceSCDatabaseSettings : ISourceSCDatabaseSettings
    {
        public string InternsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISourceSCDatabaseSettings
    {
        string InternsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
