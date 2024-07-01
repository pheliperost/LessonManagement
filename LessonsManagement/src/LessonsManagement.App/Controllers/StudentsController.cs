using AutoMapper;
using LessonsManagement.App.Extensions;
using LessonsManagement.App.ViewModels;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.App.Controllers
{

    [Authorize]
    [Route("students")]
    public class StudentsController : BaseController
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;


        public StudentsController(IStudentRepository studentRepository,
                                  IStudentService studentService,
                                  INotifyer notifyer,
                                  IMapper mapper) : base(notifyer)
        {
            _StudentRepository = studentRepository;
            _studentService = studentService;
            _mapper = mapper;
        }

        [Route("list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<StudentViewModel>>(await _StudentRepository.GetAll()));
        }

        [Route("details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var studentViewModel = await GetStudentAndLessons(id);

            if (studentViewModel == null)
            {
                return NotFound();
            }

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "Add")]
        [Route("new-student")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Student", "Add")]
        [Route("new-student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid) return View(studentViewModel);

            var student = _mapper.Map<Student>(studentViewModel);
            await _studentService.Add(student);

            if (!ValidOperation()) return View(studentViewModel);

            return RedirectToAction("Index");

        }

        [ClaimsAuthorize("Student", "Edit")]
        [Route("edit-student/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var studentViewModel = await GetStudentAndLessons(id);

            if (studentViewModel == null)
            {
                return NotFound();
            }
            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "Edit")]
        [Route("edit-student/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StudentViewModel studentViewModel)
        {
            if (id != studentViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(studentViewModel);

            var student = _mapper.Map<Student>(studentViewModel);
            await _studentService.Update(student);

            if (!ValidOperation()) return View(studentViewModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Student", "Delete")]
        [Route("delete-student/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var studentViewModel = await GetStudentAndLessons(id);

            if (studentViewModel == null)
            {
                return NotFound();
            }

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "Delete")]
        [Route("delete-student/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentViewModel = GetStudentAndLessons(id);
            if (studentViewModel == null) return NotFound();

            await _studentService.Delete(id);

            if (!ValidOperation()) return View(studentViewModel.Result);

            TempData["Success"] = "Register deleted!";

            return RedirectToAction("Index");
        }

        private async Task<StudentViewModel> GetStudentAndLessons(Guid id)
        {
            return _mapper.Map<StudentViewModel>(await _StudentRepository.GetLessonsByStudent(id));
        }
    }
}
