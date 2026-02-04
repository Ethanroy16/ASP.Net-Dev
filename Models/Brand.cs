using System.ComponentModel.DataAnnotations;


namespace MyProject_L00181476.Models
{
    public class Brand
    {
        // Primary key required for EF and for the view links
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string BrandName { get; set; }

        [StringLength(15)]
        public string? Country { get; set; }

        public int? FoundedYear { get; set; }

    }
}
