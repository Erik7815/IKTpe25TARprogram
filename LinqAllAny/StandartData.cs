using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAllAny
{
    class StandartData
    {
        public static readonly List<Standart> standarts = new List<Standart>()
        {
            new Standart() {StandartID = 1, Name = "Standard 1"},
            new Standart() {StandartID = 2, Name = "Standard 2"},
            new Standart() {StandartID = 3, Name = "Standard 3"},
        };
    }
}
