using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDwithAuthentication_MVC_EF.Models
{
    [Table("Employee")]
    public class Employee
    {
        //[ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime? Dob { get; set; }
        public int? Salary { get; set; }
        [DisplayFormat(DataFormatString ="{0:0.###}")]
        public float? TaxRate { get; set; }
        [ForeignKey("User")]
        [Required]
        public string userid { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

}