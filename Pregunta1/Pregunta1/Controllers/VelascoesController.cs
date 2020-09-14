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
using Pregunta1.Models;

namespace Pregunta1.Controllers
{
    public class VelascoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Velascoes
        [Authorize]
        public IQueryable<Velasco> GetVelascoes()
        {
            return db.Velascoes;
        }

        // GET: api/Velascoes/5
        [Authorize]
        [ResponseType(typeof(Velasco))]
        public IHttpActionResult GetVelasco(int id)
        {
            Velasco velasco = db.Velascoes.Find(id);
            if (velasco == null)
            {
                return NotFound();
            }

            return Ok(velasco);
        }

        // PUT: api/Velascoes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVelasco(int id, Velasco velasco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != velasco.VelascoID)
            {
                return BadRequest();
            }

            db.Entry(velasco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VelascoExists(id))
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

        // POST: api/Velascoes
        [Authorize]
        [ResponseType(typeof(Velasco))]
        public IHttpActionResult PostVelasco(Velasco velasco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Velascoes.Add(velasco);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = velasco.VelascoID }, velasco);
        }

        // DELETE: api/Velascoes/5
        [Authorize]
        [ResponseType(typeof(Velasco))]
        public IHttpActionResult DeleteVelasco(int id)
        {
            Velasco velasco = db.Velascoes.Find(id);
            if (velasco == null)
            {
                return NotFound();
            }

            db.Velascoes.Remove(velasco);
            db.SaveChanges();

            return Ok(velasco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VelascoExists(int id)
        {
            return db.Velascoes.Count(e => e.VelascoID == id) > 0;
        }
    }
}