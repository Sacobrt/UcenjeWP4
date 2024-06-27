
namespace UcenjeCS.E13KlasaObjekt.SocialMedia
{
    internal class Follower
    {
        public User? UserID { get; set; }
        public User? FollowerUserID { get; set; }
        public DateTime? FollowedAt { get; set; }
    }
}
