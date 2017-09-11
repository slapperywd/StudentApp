using StudentApp.Interfaces;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StudentApp.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Student student)
        {
            db.Students.Add(student);
        }

        public void Delete(int id)
        {
            Student stud = db.Students.Find(id);
            if (stud == null) throw new NullReferenceException("Student is not found");
            db.Students.Remove(stud);
            db.SaveChanges();
        }

        public Student Get(int id)
        {
            return db.Students.Include(g => g.Group).FirstOrDefault(s => s.Id == id);

        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.Include(g => g.Group);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Student student)
        {
             db.Entry(student).State = EntityState.Modified;
          
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}