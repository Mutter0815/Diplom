
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
      [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Длина может быть от 1 до 1000")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;



    }
}
