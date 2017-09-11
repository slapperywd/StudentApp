using StudentApp.Interfaces;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace StudentApp.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private ApplicationDbContext db;

        public GroupRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Group group)
        {
            db.Groups.Add(group);
        }

        public void Delete(int id)
        {
            Group gr = db.Groups.Find(id);
            if (gr == null) throw new NullReferenceException("Group is not found");
            db.Groups.Remove(gr);
            db.SaveChanges();
        }

        public Group Get(int id)
        {
            return db.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return db.Groups;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Group gr)
        {
            db.Entry(gr).State = EntityState.Modified;
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