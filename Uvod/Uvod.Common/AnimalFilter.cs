using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uvod.Common
{
    public class AnimalFilter
    {
        public string NameQuery { get; set; }
        public string SpeciesQuery { get; set; }
        public int AgeMax { get; set; }
        public int AgeMin { get; set; }
        public DateTime? DateOfBirthMax { get; set; }
        public DateTime? DateOfBirthMin { get;set; }
        public string Owner { get; set; }
    }
}
