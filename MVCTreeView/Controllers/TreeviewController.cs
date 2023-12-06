using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTreeView.Models;

namespace MVCTreeView.Controllers
{
    public class TreeviewController : Controller
    {
        RamyaEntities db = new RamyaEntities();
        // GET: Treeview
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Example()
        {
            return View();
        }
        public ActionResult Simple() {
            List<SiteMenu> all = new List<SiteMenu>();
            using (RamyaEntities db = new RamyaEntities()) {
                all = db.SiteMenus.ToList();
            }
            return View(all);
        }
        [HttpPost]
        public ActionResult Save(int parent_id, string name)
        {
            Category1 newFolder = new Category1();
            if (parent_id == -1)
            {
                newFolder.Name = name;
                newFolder.Pid = null;
                newFolder.Description = name;
            }
            else
            {
                newFolder.Name = name;
                newFolder.Pid = parent_id;
                newFolder.Description = name;
            }
            db.Category1.Add(newFolder);
            db.SaveChanges();
            return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult CIndex()
        {

            List<Category1> categories = new List<Category1>();
             var categ = db.Category1.ToList();
            
            return View(categ.Where(x => !x.Pid.HasValue).ToList());
        }
    }
}