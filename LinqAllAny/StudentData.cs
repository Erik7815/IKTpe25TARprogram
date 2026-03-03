using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAllAny
{
    class StudentData
    {
        public static readonly List<Student> students = new List<Student>()
        {
            new Student() {StudentId = 1, Name = "John", Age = 13, StandartID = 1},
            new Student() {StudentId = 2, Name = "Moin", Age = 18, StandartID = 2},
            new Student() {StudentId = 3, Name = "BILL", Age = 21, StandartID = 3},
            new Student() {StudentId = 4, Name = "Ram", Age = 20, StandartID = 4},
            new Student() {StudentId = 5, Name = "Ron", Age = 15, StandartID = 5}
        };
    }
}
