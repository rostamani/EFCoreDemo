using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Application.Contracts.Product
{
    public class CreateProduct
    {

        [MaxLength(250)]
        [Required(ErrorMessage = "Please enter name !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter price !")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Please select a category !")]
        public int CategoryId { get; set; }
    }
}
