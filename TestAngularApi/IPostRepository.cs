using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAngularApi
{
    public interface IPostRepository
    {
        Task<IEnumerable<Models.Post>> GetAllPosts();
        Task<Models.Post> GetPost(string name);
        Task Create(Models.Post post);
        Task<bool> Update(Models.Post post);
        Task<bool> Delete(string name);
    }
}
