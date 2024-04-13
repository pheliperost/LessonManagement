using AutoMapper;
using LessonsManagement.App.Extensions;
using LessonsManagement.App.ViewModels;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.App.Controllers
{
    [Authorize]
    public class LessonsController : BaseController
    {
        private readonly IEventTypeRepository _EventTypeRepository;
        private readonly IStudentRepository _StudentRepository;
        private readonly ILessonRepository _LessonRepository;
        private readonly ILessonsService _LessonService;
        private readonly IMapper _mapper;


        public LessonsController(IEventTypeRepository eventTypeRepository,
                                 ILessonRepository lessonRepository,
                                 IStudentRepository studentRepository,
                                 ILessonsService lessonsService,
                                 INotifyer notifyer,
                                 IMapper mapper) : base(notifyer)
        {
            _EventTypeRepository = eventTypeRepository;
            _LessonRepository = lessonRepository;
            _LessonService = lessonsService;
            _StudentRepository = studentRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("list-lessons")]
        public async Task<IActionResult> Index(string searchString)
        {
            if(searchString == null) 
            return View(_mapper.Map<IEnumerable<LessonViewModel>>(await _LessonRepository.GetStudenAndEventTypetInLesson()));

            var result = await LessonFilter(searchString);
            return View(_mapper.Map<IEnumerable<LessonViewModel>>(result));
        }

        private async Task<IEnumerable<Lesson>> LessonFilter(string search)
        {
            var result = await _LessonRepository.GetLessonFilter(search);
            return result;
        }

        [AllowAnonymous]
        [Route("details-lessons/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var lessonViewModel = await GetLessonWithStudentAndEventType(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }

        [ClaimsAuthorize("Lessons", "Add")]
        [Route("new-lesson")]
        public async Task<IActionResult> Create()
        {
            return View(await PopulateStudentAndEventType());
        }

        private async Task<LessonViewModel> PopulateStudentAndEventType()
        {
            var lessonViewModel = await PopulateStudentsAndEventTypes(new LessonViewModel());
            lessonViewModel.ExecutionDate = DateTime.Now;
            return lessonViewModel;
        }

        [ClaimsAuthorize("Lessons", "Add")]
        [Route("new-lesson")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel lessonViewModel)
        {
            if (!ModelState.IsValid) return View(lessonViewModel);

            var lesson = _mapper.Map<Lesson>(lessonViewModel);
            await _LessonService.Add(lesson);

            if (!ValidOperation()) return View(await PopulateStudentAndEventType());

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Lessons", "Edit")]
        [Route("edit-lesson/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var lessonViewModel = _mapper.Map<LessonViewModel>(await _LessonRepository.GetById(id));
            lessonViewModel.Students = _mapper.Map<IEnumerable<StudentViewModel>>(await _StudentRepository.GetAll());
            lessonViewModel.EventTypes = _mapper.Map<IEnumerable<EventTypeViewModel>>(await _EventTypeRepository.GetAll());


            if (lessonViewModel == null)
            {
                return NotFound();
            }
            return View(lessonViewModel);
        }

        [ClaimsAuthorize("Lessons", "Edit")]
        [Route("edit-lesson/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LessonViewModel lessonViewModel)
        {
            if (id != lessonViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(lessonViewModel);

            var lesson = _mapper.Map<Lesson>(lessonViewModel);
            await _LessonService.Update(lesson);

            if (!ValidOperation()) return View(lessonViewModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Lessons", "Delete")]
        [Route("delete-lesson/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lessonViewModel = await GetLessonWithStudentAndEventType(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }

        [ClaimsAuthorize("Lessons", "Delete")]
        [Route("delete-lesson/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lessonViewModel = await GetLesson(id);
            if (lessonViewModel == null) return NotFound();

            await _LessonService.Delete(id);

            if (!ValidOperation()) return View(lessonViewModel);

            TempData["Success"] = "Register deleted!";

            return RedirectToAction("Index");
        }

        private async Task<LessonViewModel> GetLesson(Guid id)
        {
            var lessonViewModel = _mapper.Map<LessonViewModel>(await _LessonRepository.GetLesson(id));
            return lessonViewModel;
        }

        private async Task<LessonViewModel> GetLessonWithStudentAndEventType(Guid id)
        {
            var lessonViewModel = _mapper.Map<LessonViewModel>(await _LessonRepository.GetById(id));
            lessonViewModel.Students = _mapper.Map<IEnumerable<StudentViewModel>>(await _StudentRepository.GetAll());
            lessonViewModel.Student = _mapper.Map<StudentViewModel>(await _StudentRepository.GetById(lessonViewModel.StudentId == null ? Guid.Empty : new Guid(lessonViewModel.StudentId.ToString())));
            lessonViewModel.EventTypes = _mapper.Map<IEnumerable<EventTypeViewModel>>(await _EventTypeRepository.GetAll());
            lessonViewModel.EventType = _mapper.Map<EventTypeViewModel>(await _EventTypeRepository.GetById(lessonViewModel.EventTypeId));

            return lessonViewModel;

        }

        private async Task<LessonViewModel> PopulateStudentsAndEventTypes(LessonViewModel lesson)
        {
            lesson.Students = _mapper.Map<IEnumerable<StudentViewModel>>(await _StudentRepository.GetAll());
            lesson.EventTypes = _mapper.Map<IEnumerable<EventTypeViewModel>>(await _EventTypeRepository.GetAll());
            return lesson;
        }

    }
}
