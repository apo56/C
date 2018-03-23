using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BO;
using WebSportVersionEF.Models;

namespace WebApi.Controllers
{
    public class OrganizersController : ApiController
    {
        private Context db = new Context();

        // GET: api/Organizers
        public IEnumerable<Organizer> GetOrganizers()
        {
            return db.Organizers.ToList();
        }

        // GET: api/Organizers/5
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult GetOrganizer(int id)
        {
            Organizer organizer = db.Organizers.Include("Races").FirstOrDefault(o => o.Id == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return Ok(organizer);
        }

        // PUT: api/Organizers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganizer(int id, Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizer.Id)
            {
                return BadRequest();
            }

            db.Entry(organizer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Organizers
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult PostOrganizer(Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organizers.Add(organizer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organizer.Id }, organizer);
        }

        // DELETE: api/Organizers/5
        [ResponseType(typeof(Organizer))]
        public IHttpActionResult DeleteOrganizer(int id)
        {
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return NotFound();
            }

            db.Organizers.Remove(organizer);
            db.SaveChanges();

            return Ok(organizer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizerExists(int id)
        {
            return db.Organizers.Count(e => e.Id == id) > 0;
        }
    }
}