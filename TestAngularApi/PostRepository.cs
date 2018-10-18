using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAngularApi.Models;

namespace TestAngularApi
{
    public class PostRepository : IPostRepository
    {
        private readonly IPostContext _context;

        public PostRepository(IPostContext context)
        {
            _context = context;
        }

        public async Task Create(Post post)
        {
            await _context.Posts.InsertOneAsync(post);
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Models.Post> filter = Builders<Models.Post>.Filter.Eq(p => p.Name, name);

            DeleteResult deleteResult = await _context
                                        .Posts
                                        .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _context
                           .Posts
                           .Find(_ => true)
                           .ToListAsync();
        }

        public Task<Post> GetPost(string name)
        {
            FilterDefinition<Models.Post> filter = Builders<Models.Post>
                                                    .Filter.Eq(p => p.Name, name);

            return _context
                    .Posts
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Post post)
        {
            ReplaceOneResult updateResult = await _context
                                            .Posts
                                            .ReplaceOneAsync(
                                                    filter: p => p.Id == post.Id,
                                                    replacement: post);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
