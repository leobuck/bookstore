﻿using BookStore.Domain;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("teste")]
    [Route("{action=Dados}")]
    public class TesteController : Controller
    {
        public ViewResult Dados()
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "Leo",
            };

            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categoria"] = "Produtos de Informática";
            TempData["Categoria"] = "Produtos de Escritório";
            Session["Categoria"] = "Produtos de Imóveis";

            return View(autor);
        }

        public string Index(int Id)
        {
            return "Index do " + Id.ToString();
        }

        public JsonResult UmaAction(int? id, string nome)
        {
            var autor = new Autor
            {
                Id = 0,
                Nome = nome,
            };

            return Json(autor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Autor")]
        public JsonResult ActionDois(Autor autor)
        {
            return Json(autor);
        }

        [Route("minharota/{id:int}")]
        public string MinhaAction(int id)
        {
            return "OK! Cheguei na rota!";
        }

        [Route("~/rotaignorada/{id:int}")]
        public string MinhaAction2(int? id)
        {
            return "OK! Cheguei na rota ignorada!";
        }
    }
}