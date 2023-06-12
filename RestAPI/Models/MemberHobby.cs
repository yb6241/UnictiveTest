using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace RestAPI.Models
{
    public class MemberHobby
    {
        [Key]
        public int Id { get; set; }

        public string JenisHobby { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
    }
}
