namespace MvcTask.Web.Areas.Common.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Areas.Common.Models;
    using MvcTask.Web.Models;

    public class GameController : Controller
    {
        private readonly ICommentAppService commentAppService;

        private readonly IGameAppService gameAppService;

        private readonly IPublisherAppService publisherAppService;

        public GameController(
            IGameAppService gameAppService,
            ICommentAppService commentAppService,
            IPublisherAppService publisherAppService)
        {
            this.gameAppService = gameAppService;
            this.commentAppService = commentAppService;
            this.publisherAppService = publisherAppService;
        }

        public ActionResult Index()
        {
            return this.View(Mapper.Map<IEnumerable<GameViewModel>>(this.gameAppService.Get()));
        }

        public ActionResult Details(string key)
        {
            return this.View(Mapper.Map<GameViewModel>(this.gameAppService.GetByKey(key)));
        }

        public ActionResult Create()
        {
            var publishers = this.publisherAppService.Get();
            var selectList =
                publishers.Select(
                    publisher => new SelectListItem
                                     {
                                         //Selected = (publisher.Id == publishers.First().Id),
                                         Text = publisher.CompanyName,
                                         Value = publisher.Id.ToString()
                                     });

            ViewBag.Publishers = selectList;
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(GameCreateViewModel game)
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

        public ActionResult Comments(string gameKey)
        {
            return this.Json(
                Mapper.Map<IEnumerable<CommentDto>>(this.commentAppService.GetByGameKey(gameKey)),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NewComment(string gameKey, CommentViewModel comment)
        {
            this.commentAppService.Create(Mapper.Map<CommentViewModel, CommentDto>(comment));
            return this.RedirectToAction("Comments", new { gameKey });
        }
    }
}