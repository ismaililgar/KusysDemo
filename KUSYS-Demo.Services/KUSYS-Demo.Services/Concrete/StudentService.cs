using AutoMapper;
using KUSYS_Demo.DataAccess.Contexts.Abstract;
using KUSYS_Demo.DataAccess.Contexts.Concrete;
using KUSYS_Demo.DataAccess.Dtos;
using KUSYS_Demo.DataAccess.Entitites;
using KUSYS_Demo.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace KUSYS_Demo.Services.Concrete
{
    public class StudentService : IStudentService
    {
        IKusysDbContext _kusysDbContext;
        IMapper _mapper;
        public StudentService(IKusysDbContext kusysDbContext, IMapper mapper)
        {
            _kusysDbContext = kusysDbContext;
            _mapper = mapper;
        }
        public async Task AddAsync(AddStudentDto entity)
        {
            entity.Courses = entity.Courses?.Where(c => c.Checked).ToList();
            List<Course> courses = new();
            foreach (var course in entity.Courses)
            {
                courses.Add(_kusysDbContext.Courses.FirstOrDefault(x => x.CourseId == course.CourseId));
            }
            entity.Courses = courses;
            var student = _mapper.Map<Student>(entity);
            await _kusysDbContext.Students.AddAsync(student);
            await _kusysDbContext.Save();
            //var student = _mapper.Map<Student>(entity);
            //await _kusysDbContext.Students.AddAsync(student);
            //await _kusysDbContext.Save();
        }
        public async Task<UpdateStudentDto> ViewStudent(int id)
        {
            Student? student = await _kusysDbContext.Students.FindAsync(id);
            student.Courses = await _kusysDbContext.Courses.ToListAsync();
            return _mapper.Map<UpdateStudentDto>(student);

        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _kusysDbContext.Students.Include(x => x.Courses).ToListAsync();
        }
        public async Task UpdateViewedStudent(UpdateStudentDto entity)
        {
            Student? student = _mapper.Map<Student>(entity);
            student.Courses = null;
            List<Course>? activeCourses = entity.Courses?.Where(x => x.Checked).ToList();
            List<Course>? passiveCourses = entity.Courses?.Where(x => x.Checked).ToList();
            student.Courses = _kusysDbContext.Courses.ToList().IntersectBy(activeCourses.Select(x => x.CourseId), x => x.CourseId).ToList();
            _kusysDbContext.Students.Update(student);
            await _kusysDbContext.Save();
        }
        public async Task Remove(RemoveStudentDto entity)
        {
            Student? student = _kusysDbContext.Students.Find(entity.StudentId);
            if (student != null)
            {
                _kusysDbContext.Students.Remove(student);
                await _kusysDbContext.Save();
            }
        }
    }
}
