using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Providers
{
    public static class DbProvider
    {
        private static MongoClient _mongoClient;
        private static IMongoDatabase _database;
        public static IMongoCollection<T> getCollectionInstance<T>(string collectionName) 
        {
            if (_mongoClient == null || _database==null)
            {
                _mongoClient = new MongoClient(AppSettingsProvider.DbConnectionString);
                _database = _mongoClient.GetDatabase(AppSettingsProvider.DbName);
            }


            return _database.GetCollection<T>(collectionName);
        }

    }
}
