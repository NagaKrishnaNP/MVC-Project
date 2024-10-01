using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
