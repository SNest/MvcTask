using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace MvcTask.Web.Areas.Common.Controllers
{
    using MvcTask.Application.AppServices.Abstract;
    using MvcTask.Web.Areas.Common.Models;

    using NLog;

    public class BusketController : Controller
    {
         private IGameAppService gameAppService;
        private readonly ILogger logger;

        public BusketController(ILogger logger, IGameAppService gameAppService)
        {
            this.logger = logger;
            this.gameAppService = gameAppService;
        }

        public ActionResult Details(OrderViewModel basket)
        {
            return View(basket);
        }


        //public ActionResult Buy(string gameKey, OrderViewModel basket)
        //{
        //    GameDTO game = new GameDTO();
        //    try
        //    {
        //        game = gameService.Get(gameKey);
        //        if (game == null) throw new ValidationException("game is null", "");
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Debug(e.Message);
        //        return RedirectToAction("List", "Games");
        //    }
        //    if (basket.OrderDetails == null)
        //    {
        //        basket.OrderDetails = new List<OrderDetailsViewModel>();
        //    }
        //    if (basket.OrderDetails.FirstOrDefault(x => x.ProductId == game.Id) == null)
        //    {
                
        //        var orderDetails = new OrderDetailsViewModel()
        //        {
        //            ProductId = game.Id,
        //            ProductName = game.Name,
        //            Price = game.Price,
        //            Discount = 0,
        //            Quantity = 1
        //        };
        //        basket.OrderDetails.Add(orderDetails);
        //    }
        //    else
        //    {
        //        basket.OrderDetails.FirstOrDefault(x => x.ProductId == game.Id).Quantity++;
        //    }
            
        //    return RedirectToAction("Details");
        //}

    }
    
}
