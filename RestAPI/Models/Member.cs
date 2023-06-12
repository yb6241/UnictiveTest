using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nama { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        public List<MemberHobby> Hobby { get; set; } = new List<MemberHobby>();

    }
}
