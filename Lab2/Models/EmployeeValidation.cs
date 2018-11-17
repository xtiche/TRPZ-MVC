using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;


namespace Lab2.Models
{
    [MetadataType(typeof(EmployeeMetaDate))]
    public partial class Employee
    {
        [Bind(Exclude = "IdEmployee")]
        public class EmployeeMetaDate
        {
            [ScaffoldColumn(false)]
            public int IdEmployee { get; set; }

            [DisplayName("Name")]
            [Required(ErrorMessage = "Employee name is required.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Name { get; set; }

            [DisplayName("Age")]
            [Required(ErrorMessage = "Employee age is required.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [Range(18,70, ErrorMessage = "Employee age should be in range 18-70 years.")]
            
            public string Age { get; set; }
        }
    }
}