namespace SFF_API.Models
{
    public class Trivia
    {
        public int Id { get; set; }
        public string Text { get; set; }


        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
