using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tank_Forums.Models
{
    public class PostVotes
    {
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public ForumPost forumPost { get; set; }

        [Key]
        public string userName { get; set; }

        public string voteStyle { get; set; } //like or dislike

    }
}
