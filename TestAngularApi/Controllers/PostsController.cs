using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAngularApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _postRepository.GetAllPosts());
        }

        // GET: api/Posts/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var post = await _postRepository.GetPost(name);

            if (post == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(post);
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Post post)
        {
            await _postRepository.Create(post);
            return new OkObjectResult(post);
        }

        // PUT: api/Posts/tele
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Models.Post post)
        {
            var postFromDb = await _postRepository.GetPost(name);

            if (postFromDb == null)
            {
                return new NotFoundResult();
            }

            post.Id = postFromDb.Id;
            await _postRepository.Update(post);

            return new OkObjectResult(post);
        }

        // DELETE: api/ApiWithActions/tele
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var postFromDb = await _postRepository.GetPost(name);

            if (postFromDb == null)
                return new NotFoundResult();
            await _postRepository.Delete(name);

            return new OkResult();
        }
    }
}
