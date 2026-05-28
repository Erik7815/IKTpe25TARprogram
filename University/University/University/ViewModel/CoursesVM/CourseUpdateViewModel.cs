using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.ViewModel.CoursesVM;

namespace University.ViewModel.CourseVM
{
    public class CourseUpdateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public CourseDepartmentIndexViewModel Department { get; set; }
    }
}