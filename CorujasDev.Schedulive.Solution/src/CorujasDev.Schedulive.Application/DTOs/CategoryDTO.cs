using CorujasDev.Schedulive.Core.DomainObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorujasDev.Schedulive.Application.DTOs
{
    public class CategoryDTO : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public List<LiveDTO> Lives { get; set; }
    }
}
