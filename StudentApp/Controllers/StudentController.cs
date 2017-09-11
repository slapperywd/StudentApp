using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using StudentApp.Models;
using StudentApp.Repositories;
using StudentApp.Interfaces;
using System.Collections;
using System.Web.Http.Cors;

namespace StudentApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    { 
        private IRepository<Student> studRepo;

        public StudentController()
        { 
            studRepo = new StudentRepository( new ApplicationDbContext());
        }

        // GET: api/Student
        public IEnumerable GetStudents()
        {
            return studRepo.GetAll().Select(s => new {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Faculty = s.Faculty,
                Group = s.Group
            });
        }

        // GET: api/Student/5
        public IHttpActionResult GetStudent(int id)
        {
            Student student = studRepo.Get(id); 

            if (student == null)
            {
                return BadRequest("Student is not found");//NotFound();
            }

            return Ok( new {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Faculty = student.Faculty,
                Group=student.Group
            });
        }

        // POST: api/Student
        [ResponseType(typeof(Student))]
        [HttpPost]
        public IHttpActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            studRepo.Create(student);
            studRepo.Save();

            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        //PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Student st = studRepo.Get(id);
            if (id != student.Id)
            {
                return BadRequest();
            }
           
            studRepo.Update(student);  

            try
            {
                studRepo.Save();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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



        // DELETE: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                studRepo.Delete(id);
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
            studRepo.Dispose();
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return studRepo.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}