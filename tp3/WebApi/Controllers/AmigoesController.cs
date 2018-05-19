using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
using WebApi.Domain;

namespace WebApi.Controllers
{
    //[Authorize]
    [RequireHttps]
    //[RoutePrefix("api/Amigoes")]
    public class AmigoesController : ApiController
    {
        private db_amigo_tp3Entities db = new db_amigo_tp3Entities();

        // GET: api/Amigoes
        public IQueryable<Amigo> GetAmigos()
        {
            return db.Amigos;
        }

        // GET: api/Amigoes/5
        [ResponseType(typeof(Amigo))]
        public async Task<IHttpActionResult> GetAmigo(int id)
        {
            Amigo amigo = await db.Amigos.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }

            return Ok(amigo);
        }

        // PUT: api/Amigoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAmigo(int id, Amigo amigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amigo.Id)
            {
                return BadRequest();
            }

            db.Entry(amigo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
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

        // POST: api/Amigoes
        [ResponseType(typeof(Amigo))]
        public async Task<IHttpActionResult> PostAmigo(Amigo amigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Amigos.Add(amigo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = amigo.Id }, amigo);
        }

        // DELETE: api/Amigoes/5
        [ResponseType(typeof(Amigo))]
        public async Task<IHttpActionResult> DeleteAmigo(int id)
        {
            Amigo amigo = await db.Amigos.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }

            db.Amigos.Remove(amigo);
            await db.SaveChangesAsync();

            return Ok(amigo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmigoExists(int id)
        {
            return db.Amigos.Count(e => e.Id == id) > 0;
        }
    }
}