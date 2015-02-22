using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demo.Models;

namespace demo.Controllers
{
    public class cigarsController : Controller
    {
        private CTrackrDB db = new CTrackrDB();

        // GET: cigars
        public async Task<ActionResult> Index()
        {
            return View(await db.Cigars.ToListAsync());
        }

        // GET: cigars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cigar cigar = await db.Cigars.FindAsync(id);
            if (cigar == null)
            {
                return HttpNotFound();
            }
            return View(cigar);
        }

        // GET: cigars/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: cigars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description")] cigar cigar)
        {
            if (ModelState.IsValid)
            {
                db.Cigars.Add(cigar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cigar);
        }

        // GET: cigars/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cigar cigar = await db.Cigars.FindAsync(id);
            if (cigar == null)
            {
                return HttpNotFound();
            }
            return View(cigar);
        }

        // POST: cigars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description")] cigar cigar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cigar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cigar);
        }

        // GET: cigars/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cigar cigar = await db.Cigars.FindAsync(id);
            if (cigar == null)
            {
                return HttpNotFound();
            }
            return View(cigar);
        }

        // POST: cigars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cigar cigar = await db.Cigars.FindAsync(id);
            db.Cigars.Remove(cigar);
            await db.SaveChangesAsync();
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
