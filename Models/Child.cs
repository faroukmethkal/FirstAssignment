using System.Collections.Generic;

namespace Assignment_1.Models
{
    public class Child : Person
    {
        public List<Interest> Interests { get; set; }
        public List<Pet> Pets { get; set; }
    }
}