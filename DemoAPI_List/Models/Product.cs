using System.ComponentModel.DataAnnotations;

namespace DemoAPI_List.Models
{
    public class Product
    {
        [Key]
        public Guid? Id { get; set; }
       // [Required(ErrorMessage ="Enter Name")] 
        
        public string? NameProduct { get; set; }

//[Required(ErrorMessage = "Enter Description")]
        public string? Description { get; set; }
     //   [Required(ErrorMessage = "Enter Quantity")]
     //   [RegularExpression("^[0-9]+$", ErrorMessage = "Chỉ cho phép nhập số.")]
        public int? Quantity { get; set; }
//[Required(ErrorMessage = "Enter Quantity")]
//[RegularExpression("^[0-9]+$", ErrorMessage = "Chỉ cho phép nhập số.")]
        public double? Price { get; set; }
    }
}
