using System.ComponentModel.DataAnnotations.Schema;

namespace Revas.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? Photofile { get; set; }
    }
}
