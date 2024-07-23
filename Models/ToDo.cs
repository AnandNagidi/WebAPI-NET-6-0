namespace ToDo_API.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Duration { get; set; }

    }
}
