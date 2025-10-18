using System.ComponentModel.DataAnnotations;

namespace MAPP.Domain.Entities
{
    public class Setting
    {
        [Key]
        public byte ID { get; set; }
        public string Language { get; set; } = "en";
        public string Crc { get; set; } = "";
        public DateTime ModifyDate { get; set; } = DateTime.Now;
    }
}
