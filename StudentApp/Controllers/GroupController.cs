using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using StudentApp.Models;
using System.Web.Http.Cors;
using StudentApp.Interfaces;
using System;
using StudentApp.Repositories;

namespace StudentApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GroupController : ApiController
    {
        private IRepository<Group> grRepo;
        public GroupController()
        {
            grRepo = new GroupRepository(new ApplicationDbContext());
        }
        // GET: api/Group
        public IEnumerable<Group> GetGroups()
        {
            return grRepo.GetAll();
        }

        // GET: api/Group/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult GetGroup(int id)
        {
            Group group = grRepo.Get(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // POST: api/Group
        [ResponseType(typeof(Group))]
        [HttpPost]
        public IHttpActionResult CreateGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            grRepo.Create(group);
            grRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = group.Id }, group);
        }
        // PUT: api/Group/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Group gr = db.Groups.Find(id);
            if (id != group.Id)
            {
                return BadRequest();
            }

            grRepo.Update(group);

            try
            {
                grRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // DELETE: api/Group/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult DeleteGroup(int id)
        {
            try
            {
                grRepo.Delete(id);
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
                //return NotFound();
            }
            catch (Exception e) { }

            return Ok();        
        }

        protected override void Dispose(bool disposing)
        {
            grRepo.Dispose();
            base.Dispose(disposing);
        }

        private bool GroupExists(int id)
        {
            return grRepo.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}