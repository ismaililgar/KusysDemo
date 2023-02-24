using KUSYS_Demo.DataAccess.Dtos;
using KUSYS_Demo.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Services.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllAsync();
        public Task AddAsync(AddStudentDto entity);
        public Task Remove(RemoveStudentDto entity);
        public Task<UpdateStudentDto> ViewStudent(int id);
        public Task UpdateViewedStudent(UpdateStudentDto entity);
    }
}
