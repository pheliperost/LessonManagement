using AutoMapper;
using LessonsManagement.App.ViewModels;
using LessonsManagement.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly ILessonRepository _LessonRepository;
        private readonly IMapper _mapper;


        public HomeController(ILessonRepository lessonRepository,
                                 IStudentRepository studentRepository,
                                 INotifyer notifyer,
                                 IMapper mapper) : base(notifyer)
        {
            _LessonRepository = lessonRepository;
            _StudentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {

            return View(_mapper.Map<IEnumerable<LessonViewModel>>(await _LessonRepository.GetLessonWithDetailsOrdernedByDate()));
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
