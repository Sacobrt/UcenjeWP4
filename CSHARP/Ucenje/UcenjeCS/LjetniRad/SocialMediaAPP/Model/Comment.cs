
namespace UcenjeCS.LjetniRad.SocialMediaAPP.Model
{
    internal class Comment : Entitet
    {
        public User? User { get; set; }
        public Post? Post { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
