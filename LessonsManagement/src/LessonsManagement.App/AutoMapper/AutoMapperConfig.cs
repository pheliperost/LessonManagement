using AutoMapper;
using LessonsManagement.App.ViewModels;
using LessonsManagement.Business.Models;

namespace LessonsManagement.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<EventType, EventTypeViewModel>().ReverseMap();
            CreateMap<Lesson, LessonViewModel>().ReverseMap();
            CreateMap<FileImported, FileImportedViewModel>().ReverseMap();
            CreateMap<LessonImported, LessonImportedViewModel>().ReverseMap();

        }
    }
}
