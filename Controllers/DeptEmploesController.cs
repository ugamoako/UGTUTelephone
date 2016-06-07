using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGTUTelephone;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Office.Interop.Excel;
//using System.Xml.Linq;
using ClosedXML.Excel;

namespace UGTUTelephone.Controllers
{
    public class DeptEmploesController : Controller
    {
        private KadrRealTestEntities db = new KadrRealTestEntities();

        // GET: DeptEmploes
        public void ExpertXml()
        {
            //using (KadrRealTestEntities dc = new KadrRealTestEntities())
            //{
                var moo = db.DeptEmploes.Where(a => a.idManagerDepartment == null).ToList();
            VisitNodes(moo.OrderByDescending(a => a.Rank).ThenByDescending(a => a.IsManager).ThenBy(a => a.pg).ThenBy(a => a.DepartmentName).ThenBy(a => a.Employee), 0, (DeptEmplo x, int level) => {
            
                
            });
           // XElement root = new XElement("root");

            //}
        }
      
        public ActionResult Excel(int IsChecked)
        {
            //Application app = new Microsoft.Office.Interop.Excel.Application();
            var app = new XLWorkbook();
            //app.Worksheets.Add("My_Test");
            //app.StandardFont = "Times New Roman";
            //app.StandardFontSize = 11;
            
            var w = app.Worksheets.Add("My_Test");
            w.Style.Font.FontName = "Times New Roman";
            w.Style.Font.FontSize = 11;
            w.Style.Alignment.WrapText = true;
            w.Columns().AdjustToContents();
            w.Rows().AdjustToContents();
            w.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            w.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            w.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            w.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            w.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            w.Range("A1:K1").Row(1).Merge();
            // w.Range(w.Cells[1, 1], w.Cells[6, 1]).Merge();
            w.Cell("A1").Value = "СПРАВОЧНИК ТЕЛЕФОНОВ"; w.Cell("A1").Style.Font.Bold = true; w.Cell("A1").Style.Font.FontSize = 18; //w.Cells("A1").Style.Font.FontName = "Times New Roman";
            w.Row(1).Height = 30;
            //w.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            w.Range("A2:K2").Row(1).Merge();
            w.Cell("A2").Value = "Ухтинского государственного технического университета"; w.Cell("A2").Style.Font.Bold = true; w.Cell("A2").Style.Font.FontSize = 14; //w.Cells[3, 1].Font.Name = "Times New Roman";
          

            w.Range("A3:K3").Row(1).Merge(); w.Cell("A3").Value = DateTime.Now.ToLongDateString(); w.Cell("A3").Style.Font.Bold = true;
           
            w.Range("A4:C6").Merge(); w.Cell("A4").Value = "ФИО"; w.Cell("A4").Style.Font.Bold = true; w.Cell("A4").Style.Font.FontSize = 11;
            w.Range("D4:F6").Merge(); w.Cell("D4").Value = "Должность"; w.Cell("D4").Style.Font.Bold = true; w.Cell("D4").Style.Font.FontSize = 11;
            w.Range("G4:J4").Row(1).Merge(); w.Cell("G4").Value = "№ телефона"; w.Cell("G4").Style.Font.Bold = true; w.Cell("G4").Style.Font.FontSize = 11;
            w.Range("G5:G6").Column(1).Merge(); w.Cell("G5").Value = "АТС DЕFINITY"; w.Cell("G5").Style.Font.Bold = true; w.Cell("G5").Style.Font.FontSize = 10;
            w.Range("H5:H6").Column(1).Merge(); w.Cell("H5").Value = "городской"; w.Cell("H5").Style.Font.Bold = true; w.Cell("H5").Style.Font.FontSize = 10;
            w.Range("I5:J6").Merge();w.Cell("I5").Value = "IP - телефония"; w.Cell("I5").Style.Font.Bold = true; w.Cell("I5").Style.Font.FontSize = 12;
            w.Range("A7:C10").Merge(); w.Range("D7:F10").Merge();
            w.Range("G7:G10").Column(1).Merge(); w.Cell("G7").Value = "774-ХХХ"; w.Cell("G7").Style.Font.Bold = true; w.Cell("G7").Style.Font.FontSize = 10;
            w.Range("I7:J10").Merge(); w.Cell("I7").Value = "город.  774 - ХХХ,    700 - XXX      738 - XXX      местный 9 -ХХХ"; w.Cell("I7").Style.Font.Bold = true; //w.Cell("I7").Style.Font.FontSize = 10;
            w.Range("H7:H10").Column(1).Merge();
            w.Range("K4:K10").Column(1).Merge(); w.Cell("K4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; w.Cell("K4").Value = "№ кабинета"; w.Cell("K4").Style.Font.Bold = true; w.Cell("K4").Style.Font.FontSize = 10;
           
            var moo = db.DeptEmploes.Where(a => a.idManagerDepartment == null).ToList();
            // var products = new System.Data.DataTable("teste");
            //products.Columns.Add("Name", typeof(string));
            
            int by = 11;
            VisitNodes(moo.OrderByDescending(a => a.Rank).ThenByDescending(a => a.IsManager).ThenBy(a => a.pg).ThenBy(a => a.DepartmentName).ThenBy(a => a.Employee), 0, (DeptEmplo x, int level) => {
             
                switch (level)
                {
                    case 1 :
                        w.Cell("A" + (++by).ToString()).Value = (x.DepartmentName);
                        w.Cell("A" + (by).ToString()).Style.Font.Bold = true;// w.Range["A" + (by).ToString()].Font.Name = "Times New Roman";
                       
                        w.Row(by).Height = 30;
                        w.Cell("A" +(by).ToString()).Style.Font.FontSize = 14;
                        w.Range("A" + by.ToString() + ":" + "K" + (by).ToString()).Row(1).Merge();
                        w.Cell("A" + (by).ToString()).Style.Alignment.WrapText = true;
                        w.Cell("A" + (by).ToString()).Style.Fill.BackgroundColor = XLColor.Orange;
                        //w.Cell("A" + (by).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        //w.Cell("A" + (by).ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange);
                        break;
                    case 2 :
                        if(x.Employee == null) { 
                        w.Cell("A" + (++by).ToString()).Value = (x.DepartmentName);
                        w.Cell("A" + (by).ToString()).Style.Font.Bold = true;
                        w.Cell("A" + (by).ToString()).Style.Font.FontSize = 12;
                        w.Range("A" + (by).ToString() + ":" + "K" + (by).ToString()).Row(1).Merge();
                        w.Cell("A" + (by).ToString()).Style.Fill.BackgroundColor = XLColor.PowderBlue;
                        w.Row(by).Height = 30;
                        
                            //w.Range[("A" + (by).ToString()), ("K" + (by).ToString())].Merge();
                            //w.Cell("A" + (by).ToString()).Style.Alignment.WrapText = true; w.Cell("A" + (by).ToString()).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            //w.Cell("A" + (by).ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Aqua);

                        }
                        else 
                        {
                          if (IsChecked == 1 && x.Phone == null) { } else {  
                            w.Cell("A" + (++by).ToString()).Value = (x.Employee);
                            w.Cell("A" + (by)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                w.Range("A" + (by).ToString() + ":" + "C" + (by).ToString()).Row(1).Merge();
                            w.Cell("D" + (by).ToString()).Value = (x.DepartmentName);
                                w.Cell("D" + (by)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                w.Range("D" + by.ToString() + ":" + "F" + by.ToString()).Row(1).Merge();
                            w.Cell("K" + (by).ToString()).Value = (x.Address);
                                if(x.Phone != null) {
                                    if (IsInternalIP(x.Phone) == true) { 
                                    w.Cell("I" + (by).ToString()).Value = (x.Phone);
                                    w.Range("I" + by.ToString() + ":" + "J" + by.ToString()).Row(1).Merge();
                                    }
                                    else
                                    { w.Cell("G" + (by).ToString()).Value = (x.Phone); }
                                }
                          }
                        }
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        if (x.Employee == null)
                        {
                            w.Cell("A" + (++by).ToString()).Value = (x.DepartmentName);
                            w.Cell("A" + (by).ToString()).Style.Font.Bold = true;
                            w.Cell("A" + (by).ToString()).Style.Font.FontSize = 11;
                            w.Range("A" + (by).ToString() + ":" + "K" + (by).ToString()).Row(1).Merge();
                            w.Cell("A" + (by).ToString()).Style.Fill.BackgroundColor = XLColor.FromKnownColor(System.Drawing.KnownColor.Plum);
                            w.Row(by).Height = 25;
                            
                           
                        }
                        else
                        {
                                if (IsChecked == 1 && x.Phone == null) { }
                                else {
                                    w.Cell("A" + (++by).ToString()).Value = (x.Employee);
                                    w.Cell("A" + (by)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                    w.Range("A" + (by).ToString() + ":" + "C" + (by).ToString()).Row(1).Merge();
                                    w.Cell("D" + (by).ToString()).Value = (x.DepartmentName);
                                    w.Cell("D" + (by)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                    w.Range("D" + (by).ToString() + ":" + "F" + (by).ToString()).Merge();
                                    //w.Cell("A" + (by).ToString()).Style.Font.FontSize = 10;
                                    //w.Cell("D" + (by).ToString()).Style.Font.FontSize = 10;
                                    w.Cell("K" + (by).ToString()).Value = (x.Address);
                                    if (x.Phone != null)
                                    {
                                        if (IsInternalIP(x.Phone) == true)
                                        {
                                            w.Cell("I" + (by).ToString()).Value = (x.Phone);
                                            w.Range("I" + by.ToString() + ":" + "J" + by.ToString()).Row(1).Merge();
                                        }
                                        else
                                        { w.Cell("G" + (by).ToString()).Value = (x.Phone); }
                                        //w.Cell("I" + (by).ToString()).Value = (x.Phone) + "  " + (x.IP_Phone);
                                        //w.Range("I" + by.ToString() + ":" + "J" + by.ToString()).Row(1).Merge();
                                    }
                                }
                        }

                        break;
                    default:
                        
                        break;
                }
             

            } );
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Contacts.xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                app.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            //app.SaveAs("hello.xlsx");
            //explorer ""

            //app.Visible = true;

            return View();
        }
        public bool IsDefinity(string tel)
        {
            return !IsInternalIP(tel);
        }

        public bool IsInternalIP( string tel)
        {
            if (tel == null) return false;
            int myph = Convert.ToInt32(tel.Substring(0, 4).ToString());
            int myy = Convert.ToInt32(tel.Substring(3, 2).ToString());
            while (myph == 7744 || myph == 7745)
            {
                switch (myy)
                {
                    case (58-99):
                    case 28:
                    case 56:
                    case 08:
                    case 12:
                    case 13:
                        return true;
                    default:
                        return false;
                        }
            }
            return true;
        }
        private void VisitNodes(IEnumerable<DeptEmplo> moo, int level, Action<DeptEmplo, int> act)
        {
            foreach (var de in moo)
            {
          
                act(de, level);
                if (de.idDepartment != null)
                {
                    var children = db.DeptEmploes.Where(x => x.idManagerDepartment == de.idDepartment && (x.idDepartment != de.idDepartment));
                    if (children.Count() > 0) VisitNodes(children, level + 1, act);
                }
               
            }
            
        }

       
       
        public ActionResult Index(string search)
        {

          var v = db.DeptEmploes.ToList();
            
            return View(db.DeptEmploes.Where(x => x.DepartmentName.Contains(search) || x.Employee.Contains(search) || x.Phone.Contains(search) || (search == null)).ToList());

            



        }
        public ActionResult SearchID(int search)
        {
            return View(db.DeptEmploes.Where(x => x.ID == search).ToList());
        }
        //Autocomplete
        public ActionResult Autocomplete(string term)
        {
            var result = db.DeptEmploes.Where(x => x.DepartmentName.ToLower().Contains(term)).OrderBy(x => x.DepartmentName).Take(20).Select(x => x.DepartmentName);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll(string term)
        {
            using (KadrRealTestEntities dc = new KadrRealTestEntities())
            {
                dc.Configuration.ProxyCreationEnabled = false;
                var v = dc.DeptEmploes.Where(x => x.DepartmentName.ToLower().Contains(term)).OrderBy(a => a.DepartmentName).Take(20).ToList();
                return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        // GET: DeptEmploes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptEmplo deptEmplo = db.DeptEmploes.Find(id);
            if (deptEmplo == null)
            {
                return HttpNotFound();
            }
            return View(deptEmplo);
        }

        // GET: DeptEmploes/Create
        public ActionResult Create()
        {
            DeptEmplo DeptEmplo = db.DeptEmploes.SingleOrDefault();
            return RedirectToAction("Create", "Contacts");
        }

        // POST: DeptEmploes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,idDepartment,idManagerDepartment,idDep,DepartmentName,Post,Employee,Phone,IP_Phone,Email,Address")] DeptEmplo deptEmplo)
        {
            if (ModelState.IsValid)
            {
                db.DeptEmploes.Add(deptEmplo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deptEmplo);
        }

        // GET: DeptEmploes/Edit/5
        public ActionResult Edit(int? id)
        {
           
            DeptEmplo DeptEmplo = db.DeptEmploes.SingleOrDefault(m => m.ID == id);
           
            return RedirectToAction("Edit", "Contacts", new { id = DeptEmplo.ID });
        }

        // POST: DeptEmploes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,idDepartment,idManagerDepartment,idDep,DepartmentName,Post,Employee,Phone,IP_Phone,Email,Address")] DeptEmplo deptEmplo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deptEmplo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deptEmplo);
        }

        // GET: DeptEmploes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptEmplo deptEmplo = db.DeptEmploes.Find(id);
            if (deptEmplo == null)
            {
                return HttpNotFound();
            }
            return View(deptEmplo);
        }

        // POST: DeptEmploes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeptEmplo deptEmplo = db.DeptEmploes.Find(id);
            db.DeptEmploes.Remove(deptEmplo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
