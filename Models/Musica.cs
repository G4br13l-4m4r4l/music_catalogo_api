using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    [Table("musica_table")]
    public class Musica
    {

        [Key]
        public int MusicaId { get; set; }

        [Required]
        [StringLength(25)]
        public string? MusicaName { get; set; }
        [Required]
        [StringLength(30)]
        public string? Album  { get; set; }

        public int SingerId { get; set;}
        public Singer? singer { get; set;}
    }
}
