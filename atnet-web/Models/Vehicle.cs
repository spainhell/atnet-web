using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace atnet_web.Models
{
    public class Vehicle
    {
        [Required]
        [Display(Name = "Název vozidla")]
        public string Nazev { get; set; }
        [Display(Name = "VIN kód")]
        //[StringLength(17, ErrorMessage = "VIN kód musí mít 17 znaků.")]
        [RegularExpression("\\S{17}", ErrorMessage = "VIN kód musí mít 17 znaků.")]
        public string VinKod { get; set; }
        [Display(Name = "Rok výroby")]
        [Range(1900, 2019, ErrorMessage = "Rok výroby musí být mezi 1900 a 2019.")]
        public int RokVyroby { get; set; }
        [Display(Name = "Pořizovací cena")]
        public decimal? PorizovaciCena { get; set; }
        [Display(Name = "Stáří vozdila")]
        public int Stari { get; set; }

        public void SpocitejStari()
        {
            Stari = DateTime.Today.Year - RokVyroby;
        }
    }
}
