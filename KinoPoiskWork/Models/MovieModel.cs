using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinoPoiskWork.Models;

public class MovieModel
{
    [Key]
    public int Id { get; set; }
    [Required, ForeignKey("Info")]
    public int InfoId {  get; set; }
    public Info info { get; set; }

    public class Info
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string released { get; set; }
        [Required]
        public string actors { get; set; }
        [Required]
        public string poster { get; set; }
        [Required]
        public string runtime { get; set; }
        [Required]
        public string language { get; set; }
    }
}