namespace ShadowApp.Application.DTOs
{
    public class LogDto
    {
        public ulong ID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DateTime { get; set; }
    }
    public class AddLogDto
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
