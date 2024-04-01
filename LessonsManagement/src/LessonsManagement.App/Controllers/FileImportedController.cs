using AutoMapper;
using LessonsManagement.App.ViewModels;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace LessonsManagement.App.Controllers
{
    [Authorize]
    public class FileImportedController : BaseController
    {
        private readonly IFileImportedRepository _FileImportedRepository;
        private readonly IFileImportedService _FileImportedService;
        private readonly ILessonImportedRepository _LessonImportedRepository;
        private readonly IMapper _mapper;

        public FileImportedController(IFileImportedRepository fileImportedRepository,
                                      IFileImportedService fileImportedService,
                                      ILessonImportedRepository lessonImportedRepository,
                                      INotifyer notifyer,
                                      IMapper mapper) : base(notifyer)
        {
            _FileImportedRepository = fileImportedRepository;
            _FileImportedService = fileImportedService;
            _LessonImportedRepository = lessonImportedRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FileImportedViewModel>>(await _FileImportedRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var fileImportedViewModel = _mapper.Map<FileImportedViewModel>(await _FileImportedRepository.GetById(id));

            if (fileImportedViewModel == null)
            {
                return NotFound();
            }

            return View(fileImportedViewModel);
        }

        public async Task<IActionResult> Conciliation(Guid id)
        {
            var conciliation = await _FileImportedService.Conciliation(id);

            return View(conciliation);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FileImportedViewModel fileImportedViewModel)
        {
            if (!ModelState.IsValid) return View(fileImportedViewModel);

            var filePrefix = Guid.NewGuid() + "_";
            if (!await FileUpload(fileImportedViewModel.FileUpload, filePrefix))
            {
                return View(fileImportedViewModel);
            }

            fileImportedViewModel.FilePath = ReturnLocalFilePath(filePrefix + fileImportedViewModel.FileUpload.FileName);
            await _FileImportedService.Add(_mapper.Map<FileImported>(fileImportedViewModel));

            if (!ValidOperation()) return View(fileImportedViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileImportedViewModel = await _FileImportedRepository.GetById(id);
            if (fileImportedViewModel == null)
            {
                return NotFound();
            }
            return View(fileImportedViewModel);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            FileImportedViewModel fileImportedViewModel = _mapper.Map<FileImportedViewModel>(await _FileImportedRepository.GetById(id));
            return View(fileImportedViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {


            await _FileImportedService.Delete(id);

            //  if (!ValidOperation()) return View(lessonViewModel);

            TempData["Success"] = "Register deleted!";

            return RedirectToAction("Index");
        }

        private async Task<bool> FileUpload(IFormFile fileUpload, string imgPrefixo)
        {
            if(fileUpload == null)
            {
                ModelState.AddModelError(string.Empty, "You must select a file to upload.");
                return false;
            }

            if (fileUpload.Length <= 0) return false;

            var path = ReturnLocalFilePath(imgPrefixo + fileUpload.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await fileUpload.CopyToAsync(stream);
            }

            return true;
        }

        public string ReturnLocalFilePath(string FileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", FileName);
        }
    }
}
