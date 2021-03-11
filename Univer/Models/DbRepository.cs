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

        public DbRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentsContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=University;Trusted_Connection=True;")
                    .Options;

            _db = new StudentsContext(options);
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
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
