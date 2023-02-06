using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class FruitDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Can't be null/empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Can't be null/empty")]
        public long Type { get; set; }
        [Required(ErrorMessage = "Can't be null/empty")]
        [StringLength(maximumLength:int.MaxValue,ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 25)]
        public string Description { get; set; }
    }
}
