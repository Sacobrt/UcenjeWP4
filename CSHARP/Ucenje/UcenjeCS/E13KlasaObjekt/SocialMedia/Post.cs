
namespace UcenjeCS.E13KlasaObjekt.SocialMedia
{
    internal class Post
    {
        public int? ID { get; set; }
        public User? User { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
