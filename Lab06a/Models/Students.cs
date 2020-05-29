using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06a.Models
{
    public class Students
    {
        public int ? Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Album { get; set; }
        public string Plec { get; set; }

        public static implicit operator string(Students v)
        {
            throw new NotImplementedException();
        }
    }
}
