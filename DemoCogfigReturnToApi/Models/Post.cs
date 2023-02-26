using System.Collections.Generic;

namespace DemoCogfigReturnToApi.Models
{
    public class Post
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public Post() {
            BlogPosts = new List<BlogPost>();
        }
    }
}
