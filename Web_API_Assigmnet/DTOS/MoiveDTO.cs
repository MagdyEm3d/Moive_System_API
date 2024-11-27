using System.ComponentModel.DataAnnotations;

namespace Web_API_Assigmnet.DTOS
{
    public class MoiveDTO
    {
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter ReleaseYear")]
        public DateTime ReleaseYear { get; set; }

        public List<DirectorDTO> DirectorDTOs { get; set; }
        public CategoryDTO CategoryDTO { get; set; }
    }
}
