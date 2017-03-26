using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW1_1.Models;
using PagedList;
using HW1_1.ActionFilters;

namespace HW1_1.Controllers
{
    //[Authorize]
    [紀錄Action執行時間]
    public class 客戶資料Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        public ActionResult 客戶關聯資料表()
        {
            return View(db.客戶資料關聯表.ToList());
        }
        
        // GET: 客戶資料
        public ActionResult Index(string sortBy,string keyword,int pageNo=1)
        {
            //return View(db.客戶資料.ToList());
            //return View(db.客戶資料.Where (p => false == p.是否已刪除).ToList());

            //var data = db.客戶資料.AsQueryable();
            var data = repo.All().AsQueryable();

            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(keyword));
            }

            if (sortBy == "+客戶名稱") { data = data.OrderBy(p => p.客戶名稱); }
            else if (sortBy == "-客戶名稱") { data = data.OrderByDescending(p => p.客戶名稱); }
            else if (sortBy == "+統一編號") { data = data.OrderBy(p => p.客戶名稱); }
            else if (sortBy == "-統一編號") { data = data.OrderByDescending(p => p.客戶名稱); }
            else if (sortBy == "+電話") { data = data.OrderBy(p => p.電話); }
            else if (sortBy == "-電話") { data = data.OrderByDescending(p => p.電話); }
            else if (sortBy == "+傳真") { data = data.OrderBy(p => p.傳真); }
            else if (sortBy == "-傳真") { data = data.OrderByDescending(p => p.傳真); }
            else if (sortBy == "+地址") { data = data.OrderBy(p => p.地址); }
            else if (sortBy == "-地址") { data = data.OrderByDescending(p => p.地址); }
            else if (sortBy == "+Email") { data = data.OrderBy(p => p.Email); }
            else if (sortBy == "-Email") { data = data.OrderByDescending(p => p.Email); }


            ViewBag.keyword = keyword;
            //return View(data);
            //return View(data.ToPagedList(pageNo, 10));
            return View(data.ToList());

        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var db1= repo.UnitOfWork.Context;
                db1.Entry(客戶資料).State = EntityState.Modified;
                repo.UnitOfWork.Commit();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ////客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料
            ////客戶資料.是否已刪除 = true;
            ////db.SaveChanges();
            客戶資料 客戶資料 = repo.Find(id);
            repo.Delete(客戶資料);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult NewPage()
        {
            return View();
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
