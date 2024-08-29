using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_27_08_1_
{
    internal class Trains
    {
        public int id { get; set; }

        public int WagonCount { get; set; }

        public int EmployeeCount { get; set; }

        public string BossSurname { get; set; }

        public double Milleage { get; set; }

        public string TrainType { get; set; }

        public override string ToString()
        {
            return $"{id}\n{BossSurname}\n{TrainType}" ; 
        }

    }
}

