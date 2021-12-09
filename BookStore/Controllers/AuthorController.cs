using BookStore.Domain;
using BookStore.Filters;
using BookStore.Repositories;
using BookStore.Repositories.Contracts;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("autores")]
    //[LogActionFilter]
    public class AuthorController : Controller
    {
        private IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            var autores = _repository.Get();
            return View(autores);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (_repository.Create(autor))
                return RedirectToAction("Index");

            return View(autor);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var autor = _repository.Get(id);
            return View(autor);
        }

        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (_repository.Update(autor))
                return RedirectToAction("Index");

            return View(autor);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var autor = _repository.Get(id);
            return View(autor);
        }

        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}