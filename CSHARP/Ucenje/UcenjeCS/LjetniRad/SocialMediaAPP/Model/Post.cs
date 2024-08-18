
namespace UcenjeCS.LjetniRad.SocialMediaAPP.Model
{
    internal class Post : Entitet
    {
        public User? User { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
