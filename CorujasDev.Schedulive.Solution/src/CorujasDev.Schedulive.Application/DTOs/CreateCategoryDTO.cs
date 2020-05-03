using System.ComponentModel.DataAnnotations;

namespace CorujasDev.Schedulive.Application.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
