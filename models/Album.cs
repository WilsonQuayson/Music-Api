using System.ComponentModel.DataAnnotations;

namespace ProjectApi.models
{
    public class Album
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release Year is required.")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Release Year must be a 4-digit number.")]
        public string ReleaseYear { get; set; } = string.Empty;

        [Required(ErrorMessage = "Image is required.")]
        [Url(ErrorMessage = "Image must be a valid URL.")]
        public string Image { get; set; } = string.Empty;
    }
}
