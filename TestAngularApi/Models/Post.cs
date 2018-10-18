using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAngularApi.Models
{
    public class Post
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string status { get; set; }
    }
}
