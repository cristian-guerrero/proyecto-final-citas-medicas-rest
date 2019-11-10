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
using citasMedicasRest;

namespace citasMedicasRest.Controllers
{
    public class citasController : ApiController
    {
        private citas_medicasEntities db = new citas_medicasEntities();

        // GET: api/citas
        public IQueryable<cita> Getcitas()
        {
            return db.citas;
        }

        // GET: api/citas/5
        [ResponseType(typeof(cita))]
        public IHttpActionResult Getcita(int id)
        {
            cita cita = db.citas.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }



        // POST: api/citas
        [ResponseType(typeof(cita))]
        public IHttpActionResult Postcita(cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.citas.Add(cita);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cita.id }, cita);
        }

 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool citaExists(int id)
        {
            return db.citas.Count(e => e.id == id) > 0;
        }
    }
}