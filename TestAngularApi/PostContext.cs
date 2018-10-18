using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAngularApi.Models;

namespace TestAngularApi
{
    public class PostContext : IPostContext
    {
        private readonly IMongoDatabase _db;

        public PostContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Post> Posts => _db.GetCollection<Post>("Posts");
    }
}
