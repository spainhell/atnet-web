using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace atnet_web.Models
{
    public class Address
    {
        [Required]
        [Display(Name = "Jméno / název")]
        public string Name { get; set; }

        [Display(Name = "Ulice")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Město")]
        public string City { get; set; }

        [Display(Name = "PSČ")]
        [RegularExpression("\\d{3} \\d{2}", ErrorMessage = "PSČ ve formátu 'XXX XX'")]
        public string ZipCode { get; set; }
    }
}
