using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.DataAccess.Entitites
{
    public partial class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
