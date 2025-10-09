using System.ComponentModel.DataAnnotations;

namespace MAPP.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        public bool IsDeleted { get; set; } = false;
        public bool Enabled { get; set; } = true;
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        public string Creator { get; set; } = "System";
        public DateTime? ModifyDate { get; set; }
        public string? Modifier { get; set; }
        public string Crc { get; set; } = "";
    }
}