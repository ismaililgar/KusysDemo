using AutoMapper;
using KUSYS_Demo.DataAccess.Dtos;
using KUSYS_Demo.DataAccess.Entitites;
using KUSYS_Demo.WebApp.Models;

namespace KUSYS_Demo.WebApp.AutoMapper
{
    public class KusysProfile : Profile
    {
        //Mapping Dto's and ViewModels for CRUD operations
        public KusysProfile()
        {

            CreateMap<AddStudentDto, Student>();

            CreateMap<AddStudentViewModel, AddStudentDto>();

            CreateMap<UpdateStudentDto, UpdateStudentViewModel>();

            CreateMap<UpdateStudentDto, Student>();

            CreateMap<UpdateStudentViewModel, RemoveStudentDto>();

            CreateMap<UpdateStudentViewModel, UpdateStudentDto>();

            CreateMap<Student, UpdateStudentDto>();
        }
    }
}
