using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.Models
{
    public class Moive
    {
        public int MoiveId { get; set; }
        [Required(ErrorMessage ="Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter ReleaseYear")]
        public DateTime ReleaseYear { get; set; }

        public List<Director> Directors { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
