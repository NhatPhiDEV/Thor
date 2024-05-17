using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Thor.Entities
{
    public class Course
    {
        [Key]
        [DisplayName("Mã khóa học")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên khóa học")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Mô tả")]
        public string Description { get; set; } = string.Empty;
    }
}
