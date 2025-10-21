using System.ComponentModel.DataAnnotations;

namespace ShadowApp.Domain.Entities
{
    public class Log
    {
        [Key]
        public ulong ID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Crc { get; set; } = "";
    }
}
