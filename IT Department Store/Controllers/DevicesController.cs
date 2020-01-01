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
    public class DevicesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Devices
        public async Task<ActionResult> Index()
        {
            var devices = db.Devices
                .Include(d => d.Place)
                .Include(d => d.Status)
                .Include(d => d.Type)
                .Include(d => d.User)
                .Where(d=>!d.IsDeleted);
            return View(await devices.ToListAsync());
        }
        public async Task<ActionResult> Filter(int? statusId)
        {
            var devices = db.Devices
                .Include(d => d.Place)
                .Include(d => d.Status)
                .Include(d => d.Type)
                .Include(d => d.User)
                .Where(d => !d.IsDeleted&&d.StatusId==statusId);
            return View(await devices.ToListAsync());
        }
        // GET: Devices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            if (device.IsDeleted)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: Devices/Create
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Text");
            ViewBag.StatusId = new SelectList(db.DeviceStatuses, "Id", "Text");
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Text");
            ViewBag.UserId = new SelectList(db.Users.Where(u => !u.IsDeleted), "Id", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DeviceId,Name,TypeId,PlaceId,StatusId,UserId,IsDeleted")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Text", device.PlaceId);
            ViewBag.StatusId = new SelectList(db.DeviceStatuses, "Id", "Text", device.StatusId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Text", device.TypeId);
            ViewBag.UserId = new SelectList(db.Users.Where(u => !u.IsDeleted), "Id", "Name", device.UserId);
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            if (device.IsDeleted)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Text", device.PlaceId);
            ViewBag.StatusId = new SelectList(db.DeviceStatuses, "Id", "Text", device.StatusId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Text", device.TypeId);
            ViewBag.UserId = new SelectList(db.Users.Where(u => !u.IsDeleted||u.Id==device.UserId), "Id", "Name", device.UserId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DeviceId,Name,TypeId,PlaceId,StatusId,UserId,IsDeleted")] Device device)
        {

            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Places, "Id", "Text", device.PlaceId);
            ViewBag.StatusId = new SelectList(db.DeviceStatuses, "Id", "Text", device.StatusId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Text", device.TypeId);
            ViewBag.UserId = new SelectList(db.Users.Where(u => !u.IsDeleted || u.Id == device.UserId), "Id", "Name", device.UserId);
            return View(device);
        }

        // GET: Devices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Device device = await db.Devices.FindAsync(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            //db.Devices.Remove(device);
            device.IsDeleted = true;
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
