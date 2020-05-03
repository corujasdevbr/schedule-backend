using CorujasDev.Schedulive.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace CorujasDev.Schedulive.Application.DTOs
{
    public class CategoryDTO : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
