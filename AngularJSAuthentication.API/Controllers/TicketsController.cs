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
using AngularJSAuthentication.API;
using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Controllers
{
    public class TicketsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Tickets
        public IQueryable<Ticket> GetTicket()
        {
            var a =  db.Ticket;
            return db.Ticket;
        }

        // GET: api/Tickets/5
        [ResponseType(typeof(Ticket))]
        public async Task<IHttpActionResult> GetTicket(long id)
        {
            Ticket ticket = await db.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // PUT: api/Tickets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTicket(long id, Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket.TicketID)
            {
                return BadRequest();
            }

            db.Entry(ticket).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        [ResponseType(typeof(Ticket))]
        public async Task<IHttpActionResult> PostTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ticket.Add(ticket);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ticket.TicketID }, ticket);
        }

        // DELETE: api/Tickets/5
        [ResponseType(typeof(Ticket))]
        public async Task<IHttpActionResult> DeleteTicket(long id)
        {
            Ticket ticket = await db.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            db.Ticket.Remove(ticket);
            await db.SaveChangesAsync();

            return Ok(ticket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketExists(long id)
        {
            return db.Ticket.Count(e => e.TicketID == id) > 0;
        }
    }
}