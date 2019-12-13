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

            if(context.Groups.Any())
            {
                return;
            }

            var groups = new Group[]
            {
                new Group { Name = "ПИ1" },
                new Group { Name = "ПИ2" },
            };

            foreach(Group g in groups)
            {
                context.Groups.Add(g);
            }
            context.SaveChanges();

            var lessons = new Lesson[]
            {
                new Lesson { Name = "Математика" },
                new Lesson { Name = "Программирование" },
                new Lesson { Name = "Web-программирование" },
                new Lesson { Name = "Информатика" },
                new Lesson { Name = "История" },
                new Lesson { Name = "Физика" },
                new Lesson { Name = "Иностранный язык" },
                new Lesson { Name = "Нет занятий" },
            };

            foreach(Lesson l in lessons)
            {
                context.Lessons.Add(l);
            }
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject{ GroupID = 1, LessonID = 3, NumberInDay = 1, NumberInWeek = 1 },
                new Subject{ GroupID = 1, LessonID = 2, NumberInDay = 1, NumberInWeek = 2 },
                new Subject{ GroupID = 1, LessonID = 5, NumberInDay = 1, NumberInWeek = 3 },
                new Subject{ GroupID = 1, LessonID = 1, NumberInDay = 1, NumberInWeek = 4 },
                new Subject{ GroupID = 1, LessonID = 6, NumberInDay = 1, NumberInWeek = 5 },

                new Subject{ GroupID = 1, LessonID = 4, NumberInDay = 2, NumberInWeek = 1 },
                new Subject{ GroupID = 1, LessonID = 3, NumberInDay = 2, NumberInWeek = 2 },
                new Subject{ GroupID = 1, LessonID = 6, NumberInDay = 2, NumberInWeek = 3 },
                new Subject{ GroupID = 1, LessonID = 2, NumberInDay = 2, NumberInWeek = 4 },
                new Subject{ GroupID = 1, LessonID = 7, NumberInDay = 2, NumberInWeek = 5 },

                new Subject{ GroupID = 1, LessonID = 8, NumberInDay = 1, NumberInWeek = 6 },
                new Subject{ GroupID = 1, LessonID = 8, NumberInDay = 1, NumberInWeek = 7 },
                ////////////////////////////////////////////////////////////////////////////
                new Subject{ GroupID = 2, LessonID = 5, NumberInDay = 1, NumberInWeek = 1 },
                new Subject{ GroupID = 2, LessonID = 4, NumberInDay = 1, NumberInWeek = 2 },
                new Subject{ GroupID = 2, LessonID = 7, NumberInDay = 1, NumberInWeek = 3 },
                new Subject{ GroupID = 2, LessonID = 3, NumberInDay = 1, NumberInWeek = 4 },
                new Subject{ GroupID = 2, LessonID = 1, NumberInDay = 1, NumberInWeek = 5 },

                new Subject{ GroupID = 2, LessonID = 6, NumberInDay = 2, NumberInWeek = 1 },
                new Subject{ GroupID = 2, LessonID = 5, NumberInDay = 2, NumberInWeek = 2 },
                new Subject{ GroupID = 2, LessonID = 2, NumberInDay = 2, NumberInWeek = 3 },
                new Subject{ GroupID = 2, LessonID = 5, NumberInDay = 2, NumberInWeek = 4 },
                new Subject{ GroupID = 2, LessonID = 2, NumberInDay = 2, NumberInWeek = 5 },

                new Subject{ GroupID = 2, LessonID = 8, NumberInDay = 1, NumberInWeek = 6 },
                new Subject{ GroupID = 2, LessonID = 8, NumberInDay = 1, NumberInWeek = 7 },
            };

            foreach(Subject s in subjects)
            {
                context.Subjects.Add(s);
            }
            context.SaveChanges();
        }
    }
}
