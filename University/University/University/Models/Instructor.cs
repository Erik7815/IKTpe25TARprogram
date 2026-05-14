using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        [Column("First Name")]
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
       // ICollection on üldine kogutüüp, mis võimaldab hoida mitu objekti
       //See on kasulik kui soovite hoida näiteks mitu kursust, mida õpetajat õpetab
       //Icollection võimaldab teil lisada eemaldaada ja hallata neid objekte kogu kogus.

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        //miks siin ei kasuta Icollection, vaid lihtsalt OfficeAssignment
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
