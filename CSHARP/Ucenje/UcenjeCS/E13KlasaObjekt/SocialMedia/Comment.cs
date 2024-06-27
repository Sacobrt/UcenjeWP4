
namespace UcenjeCS.E13KlasaObjekt.SocialMedia
{
    internal class Comment
    {
        public int? ID { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
