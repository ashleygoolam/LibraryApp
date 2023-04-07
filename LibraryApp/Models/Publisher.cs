namespace LibraryApp.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public string? PublisherLogo { get; set; }
        public string? PublisherDescription { get; set; }

        //Relationships
        public List<Book>? Books { get; set; }
    }
}
