using KUSYS_Demo.DataAccess.Entitites;

namespace KUSYS_Demo.WebApp.Models
{
    public class ListStudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
