using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Univer.Models.Entities;

namespace Univer.Models
{
    static class DbInit
    {
        public static void Init()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentsContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=University;Trusted_Connection=True;")
                    .Options;

            using (var db = new StudentsContext(options))
            {
                var group1 = new Group()
                {
                    Name = "АААА-01-01"
                };

                db.Groups.Add(group1);

                var stud1 = new Student()
                {
                    Name = "Глеб",
                    Surname = "Шалимов",
                    Patronymic = "Дмитриевич",
                    Birthday = DateTime.Now,
                    Group = group1
                };

                var stud2 = new Student()
                {
                    Name = "Глеб",
                    Surname = "Глебов",
                    Patronymic = "Глебович",
                    Birthday = DateTime.Now,
                    Group = group1
                };

                db.Students.Add(stud1);
                db.Students.Add(stud2);

                db.SaveChanges();

                var prof1 = new Professor()
                {
                    Name = "Пётр",
                    Surname = "Петров",
                    Patronymic = "Петрович",
                    Birthday = DateTime.Now,
                    Degree = "Доцент"
                };

                db.Professors.Add(prof1);

                var sub = new Subject()
                {
                    Name = "Математический анализ",
                    Professor = prof1
                };

                db.Subject.Add(sub);

                var mark1 = new Mark()
                {
                    Score = 71,
                    Comment = "Хорошо",
                    Subject = sub,
                    Student = stud1
                };

                db.Marks.Add(mark1);

                db.SaveChanges();
            }
        }
    }
}
