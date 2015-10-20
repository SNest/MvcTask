namespace MvcTask.Web.Areas.Common.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Models;

    public class CommentController : Controller
    {
        private readonly ICommentAppService commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            this.commentAppService = commentAppService;
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