using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviAlgos
{
    public class RaviClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public RaviClass(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            FullName = FirstName + " " + LastName;
        }
    }

    public class RaviArray
    {
        public void ArrayTests()
        {
            int[,] grades = new int[,] { { 1, 82, 74, 89, 100 }, { 2, 93, 96, 85, 86 }, { 3, 83, 72, 95, 89 }, { 4, 91, 98, 79, 88 } };

            foreach (var y in grades)
            {
                Console.WriteLine(y);
                
            }
        }
    }
}
