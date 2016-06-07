using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UGTUTelephone.Controllers
{
    public class HomeController : Controller
    {
        KadrRealTestEntities dc = new KadrRealTestEntities();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllLocation()
        {
            using (KadrRealTestEntities dc = new KadrRealTestEntities())
            {
                dc.Configuration.ProxyCreationEnabled = false;
                var v = dc.Locations.OrderBy(a => a.Title).ToList();
                return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //3. GetMarkerInfo - for fetch location details from database for show marker in the map
        public JsonResult GetMarkerInfo(int locationID)
        {
            using (KadrRealTestEntities dc = new KadrRealTestEntities())
            {
                dc.Configuration.ProxyCreationEnabled = false;
                Location l = null;
                l = dc.Locations.Where(a => a.LocationID.Equals(locationID)).FirstOrDefault();
                return new JsonResult { Data = l, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(Login u)
        {

            if (ModelState.IsValid)
            {
                using (KadrRealTestEntities dc = new KadrRealTestEntities())
                {
                    var v = dc.Logins.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();

                    if (v != null)
                    {
                        ViewBag.message = "Welcome";
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["logedUserFullName"] = v.FullName.ToString();
                        Session["Privilige"] = v.Privilige;
                        return RedirectToAction("Index", "DeptEmploes");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login details are wrong.");
                    }


                    //return RedirectToAction("About");
                }
            }
            return View(u);
        }
        public ActionResult Afterlogin()
        {
            if (Session["LogedUserID"] != null)
            {
                string q = null;
                Session["Privilige"] = q;
                return RedirectToAction("Simple", "TreeVw"); ;
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
     
        public ActionResult About()
        {
            //CorpusAddress[] Data;
           
                //ViewBag.Message = "Your application description page.";
              
       
                //return View(dc.Locations.OrderBy(a =>a.Title).ToList());
            return View();
           
            
        }
        public JsonResult GetDataPoints()
        {
            using (KadrRealTestEntities dc = new KadrRealTestEntities())
            {
                //dc.Configuration.ProxyCreationEnabled = false;
                //ViewBag.Message = "Your application description page.";
                //var Da = dc.Locations.OrderBy(a => a.Title).ToList();
                var model = dc.Locations.OrderBy(a => a.Title).ToList();
                //return View();
                return Json(new { AddressResult = model });                //return new JsonResult { Data = Da, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public ActionResult GetAddress(string msg, string msg2)
        {
           Session["name"]=msg2;
            ViewBag.Message = msg;
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewLyubomir()
        {
            return View("_Lyubomir");
        }
        [HttpPost]
        public ActionResult Lyubomir()
        {
            return RedirectToAction("Index");
        }
    }
}