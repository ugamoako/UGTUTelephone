using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UGTUTelephone.Controllers
{
    public class TreeVwController : Controller
    {
        // GET: TreeVw
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Simple()
        {
            using (KadrRealTestEntities  dc = new KadrRealTestEntities())
            {
               var all= dc.DeptEmploes.ToList();
               return View(all);
            }
      
        }
      
        }
}