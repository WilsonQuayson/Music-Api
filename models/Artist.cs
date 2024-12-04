using System.ComponentModel.DataAnnotations;

namespace ProjectApi.models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bio is required.")]
        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string Bio { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debut Year is required.")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Debut Year must be a 4-digit number.")]
        public string DebutYear { get; set; } = string.Empty;

        [Required(ErrorMessage = "Image is required.")]
        [Url(ErrorMessage = "Image must be a valid URL.")]
        public string Image { get; set; } = string.Empty;
    }
}
