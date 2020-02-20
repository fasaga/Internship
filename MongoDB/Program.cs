using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace MongoDBCsharpPrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            //MongoUrl url = new MongoUrl("mongodb://localhost");
            MongoClient mc = new MongoClient("mongodb://localhost");
            MongoServer mongo = mc.GetServer();
            var bbdds = mongo.GetDatabaseNames();
            foreach (string bbdd in bbdds)
            {
                Console.ReadLine();
            }
        }
    }
}
