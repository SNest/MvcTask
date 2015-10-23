namespace MvcTask.Web.Areas.Common.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Web.Models;

    public class PublisherController : Controller
    {
        private readonly IPublisherAppService gameAppService;

        public PublisherController(IPublisherAppService gameAppService)
        {
            this.gameAppService = gameAppService;
        }

        
        [HttpGet]
        public ActionResult Details(string companyName)
        {

            return this.View(Mapper.Map<PublisherViewModel>(this.gameAppService.GetByCompanyName(companyName)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        
        [HttpPost]
        public ActionResult Create(PublisherViewModel publisher)
        {
            if (this.ModelState.IsValid)
            {
                this.gameAppService.Create(Mapper.Map<PublisherDto>(publisher));
                this.TempData["ResultMsg"] = "The publisher was added successfully!";
                return this.RedirectToAction("Details","Publisher", new { companyName = publisher.CompanyName});
            }
            this.TempData["ResultMsg"] = "Some fields of game is not valid!";
            return this.View(publisher);
        }
    }
}
