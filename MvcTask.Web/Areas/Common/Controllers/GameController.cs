namespace MvcTask.Web.Areas.Common.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Models;

    public class GameController : Controller
    {
        private readonly IGameAppService gameAppService;

        public GameController(IGameAppService gameAppService)
        {
            this.gameAppService = gameAppService;
        }

        public ActionResult Index()
        {
            return this.Json(Mapper.Map<IEnumerable<GameDto>>(this.gameAppService.Get()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(long id)
        {
            return this.Json(Mapper.Map<GameViewModel>(this.gameAppService.Get(id)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(GameViewModel game)
        {
            if (this.ModelState.IsValid)
            {
                this.gameAppService.Create(Mapper.Map<GameDto>(game));
                this.TempData["ResultMsg"] = "The game was added successfully!";
                return this.RedirectToAction("Index");
            }
            this.TempData["ResultMsg"] = "Some fields of game is not valid!";
            return this.View(game);
        }

        public ActionResult Edit(long id)
        {
            return this.View(Mapper.Map<GameViewModel>(this.gameAppService.Get(id)));
        }

        [HttpPost]
        public ActionResult Edit(GameViewModel game)
        {
            if (this.ModelState.IsValid)
            {
                this.gameAppService.Update(Mapper.Map<GameDto>(game));
                this.TempData["ResultMsg"] = "The game was updated successfully!";
                return this.RedirectToAction("Index");
            }
            this.TempData["ResultMsg"] = "Some fields of game is not valid!";
            return this.View(game);
        }

        public ActionResult Delete(long id)
        {
            return this.View(Mapper.Map<GameViewModel>(this.gameAppService.Get(id)));
        }

        [HttpPost]
        public ActionResult Delete(GameViewModel game)
        {
            if (this.ModelState.IsValid)
            {
                this.gameAppService.Delete(game.Id);
                this.TempData["ResultMsg"] = "The game was updated successfully!";
                return this.RedirectToAction("Index");
            }
            this.TempData["ResultMsg"] = "Some fields of game is not valid!";
            return this.View(game);
        }

        public ActionResult Download(string key)
        {
            return this.File(new byte[0], ".txt");
        }
    }
}