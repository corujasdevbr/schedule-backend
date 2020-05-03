using CorujasDev.Schedulive.Core.DomainObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace CorujasDev.Schedulive.Application.DTOs
{
    public class LiveDTO : Entity
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get;  set; }

        [Required(ErrorMessage = "Thumbnail is required")]
        public string Thumbnail { get;  set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get;  set; }

        [Required(ErrorMessage = "Place is required")]
        public string Place { get;  set; }

        [Required(ErrorMessage = "DateTime is required")]
        public DateTime DateTime { get;  set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public Guid CategoryId { get;  set; }

        public CategoryDTO Category { get;  set; }
    }
}
