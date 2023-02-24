using AutoMapper;
using KUSYS_Demo.DataAccess.Contexts.Concrete;
using KUSYS_Demo.DataAccess.Dtos;
using KUSYS_Demo.DataAccess.Entitites;
using KUSYS_Demo.Services.Abstract;
using KUSYS_Demo.Services.Concrete;
using KUSYS_Demo.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly KusysDbContext _kusyDbContext;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(KusysDbContext kusysDbContext, IStudentService studentService, IMapper mapper)
        {
            _kusyDbContext = kusysDbContext;
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetAllAsync());
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Course> courses = new List<Course>();
            courses.AddRange(_kusyDbContext.Courses.ToList());
            return View(new AddStudentViewModel() { Courses = courses });
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel studentViewModel)
        {
            await _studentService.AddAsync(_mapper.Map<AddStudentDto>(studentViewModel));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            UpdateStudentDto student = await _studentService.ViewStudent(id);
            if (student != null)
            {
                return await Task.Run(() => View("View", _mapper.Map<UpdateStudentViewModel>(student)));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateStudentViewModel updateStudentViewModel)
        {
            await _studentService.UpdateViewedStudent(_mapper.Map<UpdateStudentDto>(updateStudentViewModel));
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStudentViewModel model)
        {
            await _studentService.Remove(_mapper.Map<RemoveStudentDto>(model));
            return RedirectToAction("Index");
        }
    }
}
