using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        public DateTime Startdate { get; set; }

        //? tähendab, et see väli võib olla nulll, st see ei ole kohustuslik
        public int? InstructorId { get; set; }

        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
