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
    public class EventTypeController : BaseController
    {
        private readonly IEventTypeRepository _EventTypeRepository;
        private readonly IEventTypeService _EventTypeService;
        private readonly IMapper _mapper;


        public EventTypeController(IEventTypeRepository eventTypeRepository,
                                   IEventTypeService eventTypeService,
                                   INotifyer notifyer,
                                   IMapper mapper) : base(notifyer)
        {
            _EventTypeRepository = eventTypeRepository;
            _EventTypeService = eventTypeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("list-event-type")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EventTypeViewModel>>(await _EventTypeRepository.GetAll()));
        }

        [AllowAnonymous]
        [Route("details-event-type/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var eventTypeViewModel = _mapper.Map<EventTypeViewModel>(await _EventTypeRepository.GetById(id));

            if (eventTypeViewModel == null)
            {
                return NotFound();
            }

            return View(eventTypeViewModel);
        }

        [ClaimsAuthorize("EventType", "Add")]
        [Route("new-event-type")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("EventType", "Add")]
        [Route("new-event-type")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventTypeViewModel eventTypeViewModel)
        {
            if (!ModelState.IsValid) return View(eventTypeViewModel);

            var eventType = _mapper.Map<EventType>(eventTypeViewModel);
            await _EventTypeService.Add(eventType);

            if (!ValidOperation()) return View(eventTypeViewModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("EventType", "Edit")]
        [Route("edit-event-type/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var eventTypeViewModel = _mapper.Map<EventTypeViewModel>(await _EventTypeRepository.GetById(id));


            if (eventTypeViewModel == null)
            {
                return NotFound();
            }
            return View(eventTypeViewModel);
        }

        [ClaimsAuthorize("EventType", "Edit")]
        [Route("edit-event-type/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EventTypeViewModel eventTypeViewModel)
        {
            if (id != eventTypeViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(eventTypeViewModel);

            var eventyType = _mapper.Map<EventType>(eventTypeViewModel);
            await _EventTypeService.Update(eventyType);

            if (!ValidOperation()) return View(eventTypeViewModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("EventType", "Delete")]
        [Route("delete-event-type/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var eventTypeViewModel = _mapper.Map<EventTypeViewModel>(await _EventTypeRepository.GetById(id));

            if (eventTypeViewModel == null)
            {
                return NotFound();
            }

            return View(eventTypeViewModel);
        }

        [ClaimsAuthorize("EventType", "Delete")]
        [Route("delete-event-type/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventTypeViewModel = _mapper.Map<EventTypeViewModel>(await _EventTypeRepository.GetById(id));
            if (eventTypeViewModel == null) return NotFound();

            await _EventTypeService.Delete(id);

            if (!ValidOperation()) return View(eventTypeViewModel);

            TempData["Success"] = "Register deleted!";

            return RedirectToAction("Index");
        }
    }
}
