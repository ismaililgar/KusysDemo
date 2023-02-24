using KUSYS_Demo.DataAccess.Entitites;
using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.WebApp.Models
{
    public class AddStudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
