using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.DataAccess.Entitites
{
    public partial class Course
    {
        [Key]
        public string CourseId { get; set; }
        public string CourseName { get;set; }
        public List<Student>? Students { get; set; }
        public bool Checked { get; set; }
    }
}
