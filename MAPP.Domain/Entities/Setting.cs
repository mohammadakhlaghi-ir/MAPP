using System.ComponentModel.DataAnnotations;

namespace MAPP.Domain.Entities
{
    public class Setting
    {
        [Key]
        public byte ID { get; set; }
        public int LanguageID { get; set; }
        public string Crc { get; set; } = "";
        public DateTime ModifyDate { get; set; } = DateTime.Now;

        #region navigations
        public Language Language { get; set; } = null!;
        #endregion
    }
}
