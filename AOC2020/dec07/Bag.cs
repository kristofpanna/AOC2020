using System.Collections.Generic;

namespace AOC2020.dec07
{
    public class Bag
    {
        public string Color { get; set; }
        public List<(int, Bag)> Content { get; set; } = new List<(int, Bag)>();
        public HashSet<Bag> CanBeCarriedIn { get; set; } = new HashSet<Bag>();

        public Bag(string color)
        {
            Color = color;
        }
    }
}
