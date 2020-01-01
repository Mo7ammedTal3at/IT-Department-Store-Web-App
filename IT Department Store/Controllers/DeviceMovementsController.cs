using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_Department_Store.Models;

namespace IT_Department_Store.Controllers
{
    public class DeviceMovementsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: DeviceMovements
        public async Task<ActionResult> Index()
        {
            var deviceMovements = db.DeviceMovements
                .Include(d => d.Commander)
                .Include(d => d.Device)
                .Include(d => d.NewPlace)
                .Include(d => d.PreviousPlace)
                .Include(d => d.Ranker)
                .Include(d => d.Soldier);
            return View(await deviceMovements.ToListAsync());
        }

        // GET: DeviceMovements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceMovement deviceMovement = await db.DeviceMovements.FindAsync(id);
            if (deviceMovement == null)
            {
                return HttpNotFound();
            }
            return View(deviceMovement);
        }

        // GET: DeviceMovements/Create
        public ActionResult Create()
        {
            ViewBag.CommanderId = new SelectList(db.Users.Where(u => !u.IsDeleted&&
            u.DaragaId == 3), "Id", "Name");
            ViewBag.DeviceId = new SelectList(db.Devices.Where(d=>!d.IsDeleted&&d.StatusId==1), "Id", "Name");
            ViewBag.NewPlaceId = new SelectList(db.Places, "Id", "Text");
            ViewBag.PreviousPlaceId = new SelectList(db.Places, "Id", "Text");
            ViewBag.RankerId = new SelectList(db.Users.Where(u =>!u.IsDeleted&& u.DaragaId == 2), "Id", "Name");
            ViewBag.SoldierId = new SelectList(db.Users.Where(u => !u.IsDeleted && u.DaragaId == 1), "Id", "Name");
            return View();
        }

        // POST: DeviceMovements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DeviceId,PreviousPlaceId,NewPlaceId,SoldierId,RankerId,CommanderId,Time,Notes")] DeviceMovement deviceMovement)
        {
            deviceMovement.Time=DateTime.Now;
            if (ModelState.IsValid)
            {
                db.DeviceMovements.Add(deviceMovement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CommanderId = new SelectList(db.Users.Where(u => !u.IsDeleted && u.DaragaId == 3), "Id", "Name", deviceMovement.CommanderId);
            ViewBag.DeviceId = new SelectList(db.Devices.Where(d => !d.IsDeleted && d.StatusId == 1), "Id", "Name", deviceMovement.DeviceId);
            ViewBag.NewPlaceId = new SelectList(db.Places, "Id", "Text", deviceMovement.NewPlaceId);
            ViewBag.PreviousPlaceId = new SelectList(db.Places, "Id", "Text", deviceMovement.PreviousPlaceId);
            ViewBag.RankerId = new SelectList(db.Users.Where(u => !u.IsDeleted && u.DaragaId == 2), "Id", "Name", deviceMovement.RankerId);
            ViewBag.SoldierId = new SelectList(db.Users.Where(u => !u.IsDeleted && u.DaragaId == 1), "Id", "Name", deviceMovement.SoldierId);
            return View(deviceMovement);
        }

        // GET: DeviceMovements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceMovement deviceMovement = await db.DeviceMovements.FindAsync(id);
            if (deviceMovement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommanderId = new SelectList(db.Users.Where(u => u.DaragaId == 3&&(!u.IsDeleted||u.Id==deviceMovement.CommanderId)), "Id", "Name", deviceMovement.CommanderId);
            ViewBag.DeviceId = new SelectList(db.Devices.Where(d => !d.IsDeleted && d.StatusId == 1), "Id", "Name", deviceMovement.DeviceId);
            ViewBag.NewPlaceId = new SelectList(db.Places, "Id", "Text", deviceMovement.NewPlaceId);
            ViewBag.PreviousPlaceId = new SelectList(db.Places, "Id", "Text", deviceMovement.PreviousPlaceId);
            ViewBag.RankerId = new SelectList(db.Users.Where(u => u.DaragaId == 2 && (!u.IsDeleted || u.Id == deviceMovement.RankerId)), "Id", "Name", deviceMovement.RankerId);
            ViewBag.SoldierId = new SelectList(db.Users.Where(u => u.DaragaId == 1 && (!u.IsDeleted || u.Id == deviceMovement.SoldierId)), "Id", "Name", deviceMovement.SoldierId);
            return View(deviceMovement);
        }

        // POST: DeviceMovements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DeviceId,PreviousPlaceId,NewPlaceId,SoldierId,RankerId,CommanderId,Time,Notes")] DeviceMovement deviceMovement)
        {
            deviceMovement.Time=DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(deviceMovement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CommanderId = new SelectList(db.Users.Where(u => u.DaragaId == 3 && (!u.IsDeleted || u.Id == deviceMovement.CommanderId)), "Id", "Name", deviceMovement.CommanderId);
            ViewBag.DeviceId = new SelectList(db.Devices, "Id", "Name", deviceMovement.DeviceId);
            ViewBag.NewPlaceId = new SelectList(db.Places, "Id", "Text", deviceMovement.NewPlaceId);
            ViewBag.PreviousPlaceId = new SelectList(db.Places, "Id", "Text", deviceMovement.PreviousPlaceId);
            ViewBag.RankerId = new SelectList(db.Users.Where(u=>u.DaragaId==2 && (!u.IsDeleted || u.Id == deviceMovement.RankerId)), "Id", "Name", deviceMovement.RankerId);
            ViewBag.SoldierId = new SelectList(db.Users.Where(u => u.DaragaId == 1 && (!u.IsDeleted || u.Id == deviceMovement.SoldierId)), "Id", "Name", deviceMovement.SoldierId);
            return View(deviceMovement);
        }

        // GET: DeviceMovements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceMovement deviceMovement = await db.DeviceMovements.FindAsync(id);
            if (deviceMovement == null)
            {
                return HttpNotFound();
            }
            return View(deviceMovement);
        }

        // POST: DeviceMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DeviceMovement deviceMovement = await db.DeviceMovements.FindAsync(id);
            db.DeviceMovements.Remove(deviceMovement);
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
