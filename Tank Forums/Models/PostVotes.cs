using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank_Forums.Models
{
    public class PostVotes
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public ForumPost forumPost { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]
        public IdentityUser user { get; set; }

        public string voteStyle; //like or dislike

    }
}
