using ScheduleConstructor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ScheduleContext context)
        {
            context.Database.EnsureCreated();

            if(context.Departments.Any())
            {
                return;
            }

            var department = new Department[]
            {
                new Department{ Name = "физмат" }
            };

            foreach(Department d in department)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var groups = new Group[]
            {
                new Group { Name = "ПИ1", DepartmentID = 1 },
                new Group { Name = "ПИ2", DepartmentID = 1 },
            };

            foreach(Group g in groups)
            {
                context.Groups.Add(g);
            }
            context.SaveChanges();

            var teachers = new Teacher[]
            {
                new Teacher{ Name = "Иванов И.И." },
                new Teacher{ Name = "Петрова А.В." },
                new Teacher{ Name = "Ложкин В.Ф." },
                new Teacher{ Name = "Двачевская Н.В." },
                new Teacher{ Name = "Леонов А.А." },
                new Teacher{ Name = "Рыбка А.А." },
                new Teacher{ Name = "Цукеберг А.И." },
                new Teacher{ Name = "_" },
            };

            foreach(Teacher t in teachers)
            {
                context.Teachers.Add(t);
            }
            context.SaveChanges();

            var lessons = new Lesson[]
            {
                new Lesson { Name = "Математика", TeacherID = teachers.Single(t => t.Name == "Иванов И.И.").ID },
                new Lesson { Name = "Программирование", TeacherID = teachers.Single(t => t.Name == "Петрова А.В.").ID },
                new Lesson { Name = "Web-программирование", TeacherID = teachers.Single(t => t.Name == "Ложкин В.Ф.").ID },
                new Lesson { Name = "Информатика", TeacherID = teachers.Single(t => t.Name == "Двачевская Н.В.").ID },
                new Lesson { Name = "История", TeacherID = teachers.Single(t => t.Name == "Леонов А.А.").ID },
                new Lesson { Name = "Физика", TeacherID = teachers.Single(t => t.Name == "Рыбка А.А.").ID },
                new Lesson { Name = "Иностранный язык", TeacherID = teachers.Single(t => t.Name == "Цукеберг А.И.").ID },
                new Lesson { Name = "Нет занятий", TeacherID = teachers.Single(t => t.Name == "_").ID },
            };

            foreach(Lesson l in lessons)
            {
                context.Lessons.Add(l);
            }
            context.SaveChanges();

            var audiences = new Audience[]
            {
                new Audience{ Number = 0 },
                new Audience{ Number = 101 },
                new Audience{ Number = 102 },
                new Audience{ Number = 103 },
                new Audience{ Number = 104 },
                new Audience{ Number = 105 },
                new Audience{ Number = 106 },
                new Audience{ Number = 107 },
                new Audience{ Number = 108 },
                new Audience{ Number = 109 },
                new Audience{ Number = 110 },
                new Audience{ Number = 201 },
                new Audience{ Number = 202 },
                new Audience{ Number = 203 },
                new Audience{ Number = 204 },
                new Audience{ Number = 205 },
                new Audience{ Number = 206 },
                new Audience{ Number = 207 },
                new Audience{ Number = 208 },
                new Audience{ Number = 209 },
                new Audience{ Number = 210 }
            };

            foreach (Audience a in audiences)
            {
                context.Audiences.Add(a);
            }
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = lessons.Single(l => l.Name == "Web-программирование").LessonID, NumberInDay = 1, NumberInWeek = 1, AudienceNumber = 101 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = lessons.Single(l => l.Name == "Программирование").LessonID, NumberInDay = 1, NumberInWeek = 2, AudienceNumber = 102 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = lessons.Single(l => l.Name == "История").LessonID, NumberInDay = 1, NumberInWeek = 3, AudienceNumber = 103 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = lessons.Single(l => l.Name == "Математика").LessonID, NumberInDay = 1, NumberInWeek = 4, AudienceNumber = 104 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = lessons.Single(l => l.Name == "Физика").LessonID, NumberInDay = 1, NumberInWeek = 5, AudienceNumber = 105 },

                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 4, NumberInDay = 2, NumberInWeek = 1, AudienceNumber = 102 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 3, NumberInDay = 2, NumberInWeek = 2, AudienceNumber = 103 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 6, NumberInDay = 2, NumberInWeek = 3, AudienceNumber = 104 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 2, NumberInDay = 2, NumberInWeek = 4, AudienceNumber = 105 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 7, NumberInDay = 2, NumberInWeek = 5, AudienceNumber = 106 },

                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 8, NumberInDay = 1, NumberInWeek = 6, AudienceNumber = 0 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ1").ID, LessonID = 8, NumberInDay = 1, NumberInWeek = 7, AudienceNumber = 0 },
                ////////////////////////////////////////////////////////////////////////////
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 5, NumberInDay = 1, NumberInWeek = 1, AudienceNumber = 103 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 4, NumberInDay = 1, NumberInWeek = 2, AudienceNumber = 104 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 7, NumberInDay = 1, NumberInWeek = 3, AudienceNumber = 105 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 3, NumberInDay = 1, NumberInWeek = 4, AudienceNumber = 106 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 1, NumberInDay = 1, NumberInWeek = 5, AudienceNumber = 107 },

                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 6, NumberInDay = 2, NumberInWeek = 1, AudienceNumber = 104 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 5, NumberInDay = 2, NumberInWeek = 2, AudienceNumber = 105 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 2, NumberInDay = 2, NumberInWeek = 3, AudienceNumber = 106 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 5, NumberInDay = 2, NumberInWeek = 4, AudienceNumber = 107 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 2, NumberInDay = 2, NumberInWeek = 5, AudienceNumber = 108 },

                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 8, NumberInDay = 1, NumberInWeek = 6, AudienceNumber = 0 },
                new Subject{ GroupID = groups.Single(g => g.Name == "ПИ2").ID, LessonID = 8, NumberInDay = 1, NumberInWeek = 7, AudienceNumber = 0 },
            };

            foreach(Subject s in subjects)
            {
                context.Subjects.Add(s);
            }
            context.SaveChanges();
        }
    }
}
