using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univer.Interfaces;
using Univer.Models.Entities;

namespace Univer.Models
{
    class DbRepository<T> : IRepository<T>
        where T : Entity
    {
        private StudentsContext _db;
        private DbSet<T> _set;

        public DbRepository(StudentsContext context)
        {
            _db = context;
            _set = _db.Set<T>();
        }

        public virtual IQueryable<T> GetList => _set;

        public T Get(int id)
        {
            return GetList.Single(item => item.Id == id);
        }

        public void Create(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _db.Entry(item).State = EntityState.Added;

            _db.SaveChanges();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _set.Local.FirstOrDefault(item => item.Id == id);

            _db.Remove(item);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
