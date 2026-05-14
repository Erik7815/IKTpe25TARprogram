using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class OfficeAssignment
    {
        //kui soovite konkreetselt välja tuua, ey InstructorId on nii OfficeAssignment
        //peamine võti kui ka võõrvõyi, siis saate kasutada [key] ja [foreignkey] atribuute:
        [Key]
        public int InstructorId { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }


    }
}
