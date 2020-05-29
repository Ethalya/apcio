using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLab7.Models
{
    public class Students
    {
        public int? Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Album { get; set; }
        [Required]
        public string Plec { get; set; }
    }
}
