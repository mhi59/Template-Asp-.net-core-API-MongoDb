using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAngularApi
{
   public interface IPostContext
    {
        IMongoCollection<Models.Post> Posts { get; }
    }
}
