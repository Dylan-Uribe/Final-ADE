using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediManagement
{
    public class Jedi
    {
        public string Name { get; set; }
        public string Species {  get; set; }
        public int BirthYear { get; set; }
        public List<string> LightsaberColors { get; set; }
        public List<string> Rankings { get; set; }
        public List<string> Masters { get; set; }

        public Jedi (string name, string species, int birthYear, List<string> lightsaberColors, List<string> rankings, List<string> masters) 
        {
            Name = name;
            Species = species;
            BirthYear = birthYear;
            LightsaberColors = lightsaberColors;
            Rankings = rankings;
            Masters = masters;
        }

        public override string ToString()
        {
            return $"{Name}, {Species}, {BirthYear}, {string.Join(", ", LightsaberColors)}, {string.Join(", ", Rankings)}, {string.Join(", ", Masters)}";
        }
    }
}
