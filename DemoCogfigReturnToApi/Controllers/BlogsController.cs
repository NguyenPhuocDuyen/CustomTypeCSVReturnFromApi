using DemoCogfigReturnToApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCogfigReturnToApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var post = new List<Post>();
            var blogPosts = new List<BlogPost>();

            blogPosts.Add(new BlogPost
            {
                Title = "Content negatation in .net core",
                Price = 12,
                Published = true,
                DateCreate = DateTime.Now
            });

            post.Add(new Post 
            { 
                Name = "Post", 
                BlogPosts = blogPosts, 
                Description = "Post 1" 
            });

            return Ok(post);
        }
    }
}
