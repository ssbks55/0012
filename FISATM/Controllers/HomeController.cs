using FISATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FISATM.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// demo : 123456789
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(AtmCardModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CardDetail _atmCardDetails = model.GetCardDetail(model.CardNumber);
                    if (_atmCardDetails != null && _atmCardDetails.IsActivated)
                    {
                        TempData["Name"] = model.CardNumber;
                        return RedirectToAction("Dashboard", "Dashboard");
                    }
                    else if (_atmCardDetails != null && !_atmCardDetails.IsActivated)
                    {
                        //first time registration
                        //to do...
                    }
                    else
                    {
                        return View();
                    }

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}