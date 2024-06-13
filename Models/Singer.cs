using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{
    [Table("singer_table")]
    public class Singer
    {
        public Singer()
        {
            Musicas = new Collection<Musica>();
        }

        [Key]
        public int SingerId { get; set; }
        [Required]
        [StringLength(50)]
        public string? SingerName { get; set; }
        [JsonIgnore]
        public ICollection<Musica> Musicas { get; set; }
    }
}
