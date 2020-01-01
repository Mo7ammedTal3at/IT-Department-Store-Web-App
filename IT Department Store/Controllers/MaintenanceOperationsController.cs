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
    public class MaintenanceOperationsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MaintenanceOperations
        public async Task<ActionResult> Index()
        {
            var maintenanceOperations = db.MaintenanceOperations.Include(m => m.Device).Include(m => m.Status);
            return View(await maintenanceOperations.ToListAsync());
        }
        public async Task<ActionResult> Filter(int? statusId)
        {
            var maintenanceOperations = db.MaintenanceOperations
                .Include(m => m.Device)
                .Include(m => m.Status)
                .Where(m => m.StatusId == statusId);
            return View(await maintenanceOperations.ToListAsync());
        }
        // GET: MaintenanceOperations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceOperation maintenanceOperation = await db.MaintenanceOperations.FindAsync(id);
            if (maintenanceOperation == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceOperation);
        }

        // GET: MaintenanceOperations/Create
        public ActionResult Create()
        {
            ViewBag.DeviceId = new SelectList(db.Devices.Where(u => !u.IsDeleted), "Id", "Name");
            ViewBag.StatusId = new SelectList(db.MaintenanceStatuses, "Id", "Text");
            ViewBag.RecevierId = new SelectList(db.Users.Where(u => !u.IsDeleted), "Id", "Name");
            return View();
        }

        // POST: MaintenanceOperations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RecevierId,DeviceId,Problem")] MaintenanceOperation maintenanceOperation)
        {
            maintenanceOperation.ReceiveTime = DateTime.Now;
            maintenanceOperation.StatusId = 2;
            if (ModelState.IsValid)
            {
                db.MaintenanceOperations.Add(maintenanceOperation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DeviceId = new SelectList(db.Devices.Where(u => !u.IsDeleted), "Id", "Name", maintenanceOperation.DeviceId);
            ViewBag.StatusId = new SelectList(db.MaintenanceStatuses, "Id", "Text", maintenanceOperation.StatusId);
            ViewBag.RecevierId = new SelectList(db.Users.Where(u => !u.IsDeleted), "Id", "Name", maintenanceOperation.RecevierId);
            return View(maintenanceOperation);
        }
        public async Task<ActionResult> FinishMaintenence(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceOperation maintenanceOperation = await db.MaintenanceOperations.FindAsync(id);
            if (maintenanceOperation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.MaintenanceStatuses, "Id", "Text", maintenanceOperation.StatusId);
            ViewBag.ExporterId = new SelectList(db.Users.Where(u => !u.IsDeleted), "Id", "Name", maintenanceOperation.ExporterId);
            return View(maintenanceOperation);
        }

        // POST: MaintenanceOperations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FinishMaintenence( MaintenanceOperation maintenanceOperation)
        {
            maintenanceOperation.EndTime=DateTime.Now;
            if (ModelState.IsValid&&maintenanceOperation.ExporterId!=null)
            {
                db.Entry(maintenanceOperation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.MaintenanceStatuses, "Id", "Text", maintenanceOperation.StatusId);
            ViewBag.ExporterId = new SelectList(db.Users.Where(u => !u.IsDeleted), "Id", "Name", maintenanceOperation.ExporterId);
            return View(maintenanceOperation);
        }
        // GET: MaintenanceOperations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceOperation maintenanceOperation = await db.MaintenanceOperations.FindAsync(id);
            if (maintenanceOperation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceId = new SelectList(db.Devices.Where(u => !u.IsDeleted || u.Id == maintenanceOperation.DeviceId), "Id", "Name", maintenanceOperation.DeviceId);
            ViewBag.StatusId = new SelectList(db.MaintenanceStatuses, "Id", "Text", maintenanceOperation.StatusId);
            ViewBag.RecevierId = new SelectList(db.Users.Where(u => !u.IsDeleted || u.Id == maintenanceOperation.RecevierId), "Id", "Name", maintenanceOperation.RecevierId);
            ViewBag.ExporterId = new SelectList(db.Users.Where(u => !u.IsDeleted || u.Id == maintenanceOperation.ExporterId), "Id", "Name", maintenanceOperation.ExporterId);
            return View(maintenanceOperation);
        }

        // POST: MaintenanceOperations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Time,StatusId,UserId,DeviceId")] MaintenanceOperation maintenanceOperation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceOperation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DeviceId = new SelectList(db.Devices.Where(u => !u.IsDeleted || u.Id == maintenanceOperation.DeviceId), "Id", "Name", maintenanceOperation.DeviceId);
            ViewBag.StatusId = new SelectList(db.MaintenanceStatuses, "Id", "Text", maintenanceOperation.StatusId);
            ViewBag.RecevierId = new SelectList(db.Users.Where(u => !u.IsDeleted || u.Id == maintenanceOperation.RecevierId), "Id", "Name", maintenanceOperation.RecevierId);
            ViewBag.ExporterId = new SelectList(db.Users.Where(u => !u.IsDeleted || u.Id == maintenanceOperation.ExporterId), "Id", "Name", maintenanceOperation.ExporterId);
            return View(maintenanceOperation);
        }

        // GET: MaintenanceOperations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceOperation maintenanceOperation = await db.MaintenanceOperations.FindAsync(id);
            if (maintenanceOperation == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceOperation);
        }

        // POST: MaintenanceOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MaintenanceOperation maintenanceOperation = await db.MaintenanceOperations.FindAsync(id);
            db.MaintenanceOperations.Remove(maintenanceOperation);
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
