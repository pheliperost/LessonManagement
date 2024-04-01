using AutoMapper;
using LessonsManagement.App.ViewModels;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.App.Controllers
{
    public class LessonsImportedController : Controller
    {
        private readonly ILessonImportedRepository _LessonImportedRepository;
        private readonly ILessonImportedService _LessonImportedService;
        private readonly IMapper _mapper;

        public LessonsImportedController(ILessonImportedRepository lessonImportedRepository,
                                         ILessonImportedService lessonImportedService,
                                         IMapper mapper)
        {
            _LessonImportedRepository = lessonImportedRepository;
            _LessonImportedService = lessonImportedService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<LessonImportedViewModel>>(await _LessonImportedRepository.GetStudenAndEventTypetInLesson()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var lessonViewModel = await _LessonImportedRepository.GetById(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonImportedViewModel lessonImportedViewModel)
        {
            await _LessonImportedService.Add(_mapper.Map<LessonImported>(lessonImportedViewModel));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileImportedViewModel = await _LessonImportedRepository.GetById(id);
            if (fileImportedViewModel == null)
            {
                return NotFound();
            }
            return View(fileImportedViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LessonImportedViewModel lessonImportedViewModel)
        {
            if (id != lessonImportedViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(lessonImportedViewModel);

            var lesson = _mapper.Map<LessonImported>(lessonImportedViewModel);
            await _LessonImportedRepository.Update(lesson);

            //if (!ValidOperation()) return View(fileImportedViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            FileImportedViewModel fileImportedViewModel = _mapper.Map<FileImportedViewModel>(await _LessonImportedRepository.GetById(id));
            return View(fileImportedViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            return RedirectToAction(nameof(Index));
        }

        private bool LessonImportedViewModelExists(Guid id)
        {
            return false;
        }
    }
}
