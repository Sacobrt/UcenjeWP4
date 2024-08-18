
namespace UcenjeCS.LjetniRad.SocialMediaAPP.Model
{
    internal class Follower
    {
        public User? UserID { get; set; }
        public User? FollowerUserID { get; set; }
        public DateTime? FollowedAt { get; set; }
    }
}
