namespace MvcTask.Web.Areas.Common.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MvcTask.Application.AppServices.Abstract;

    public class GamesController : Controller
    {
        private readonly IGameAppService _gameAppService;

        public GamesController(IGameAppService gameAppService)
        {
            this._gameAppService = gameAppService;
        }

        [OutputCache(Duration = 60)]
        public ActionResult GamesCount()
        {
            return this.View("_GameCount", this._gameAppService.Get().Count());
        }
    }
}