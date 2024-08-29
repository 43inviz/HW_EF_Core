using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_27_08_Menu
{
    internal class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }   
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Weight}"; 
        }
    }
}
