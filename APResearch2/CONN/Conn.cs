using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APResearch2.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Authentication;

namespace APResearch2
{
    public class Conn
    {
        private string userName = "jerytest";
        private string host = "jerytest.documents.azure.com";
        private string password = "";

        private string dbName = "OOODesignDataBase";
        private string collectionName = "OOO_CustomerInfo";

        public Conn()
        {
        }

        public List<Customer> GetAllTasks()
        {
            try
            {
                var collection = GetTasksCollection();
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (MongoConnectionException)
            {
                return new List<Customer>();
            }
        }

        private IMongoCollection<Customer> GetTasksCollection()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, 10255);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            MongoClient client = new MongoClient(settings);
            var database = client.GetDatabase(dbName);
            var todoTaskCollection = database.GetCollection<Customer>(collectionName);
            return todoTaskCollection;
        }
    }
}