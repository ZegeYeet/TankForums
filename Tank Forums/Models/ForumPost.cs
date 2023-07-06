

namespace Tank_Forums.Models
{
    public class ForumPost
    {

        public int Id { get; set; }
        public string className { get; set; }
        public string authorName { get; set; }
        public byte[] classIcon { get; set; }


        public DateTime postDate { get; set; }
        public string postTitle { get; set; }
        public string postBody { get; set; }

        public int postLikes { get; set; }
        public int postDislikes { get; set; }

        public ForumPost()
        {
              
        }

    }
}
