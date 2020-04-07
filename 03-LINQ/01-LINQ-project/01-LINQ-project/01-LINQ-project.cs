using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_LINQ_project
{
    class Schedule
    {
        public string Name { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }

    class DaysOfWork
    {
        public Schedule Schedule{ get; set; }
        public System.DayOfWeek Day { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var schedules = new List<Schedule>();
            var daysOfWork = new List<DaysOfWork>();
            string employeeName = "First Employee";

            #region AddingScheduleElements

            schedules.Add(new Schedule
            {
                Name = "First Employee",
                DateIn = new DateTime(2020, 04, 06),
                DateOut = new DateTime(2020, 04, 16)
            });


            schedules.Add(new Schedule
            {
                Name = "Second Employee",
                DateIn = new DateTime(2020, 04, 16),
                DateOut = new DateTime(2020, 04, 30)
            });


            schedules.Add(new Schedule
            {
                Name = "Third Employee",
                DateIn = new DateTime(2020, 05, 01),
                DateOut = new DateTime(2020, 05, 15)
            });

            #endregion

            #region AddingDayOfWeekElements

            daysOfWork.Add(new DaysOfWork
            {
                Schedule = schedules[0],
                Day = DayOfWeek.Monday
            });

            daysOfWork.Add(new DaysOfWork
            {
                Schedule = schedules[1],
                Day = DayOfWeek.Thursday
            });

            daysOfWork.Add(new DaysOfWork
            {
                Schedule = schedules[2],
                Day = DayOfWeek.Wednesday
            });

            #endregion

            var emloyeeDays =
                             (from d in daysOfWork
                              where d.Schedule.Name == employeeName
                              select d).ToList();

            //Синтаксис методов
            var range =
                         emloyeeDays
                        .Select(e => Enumerable.Range(0, 1 + e.Schedule.DateOut.Subtract(e.Schedule.DateIn).Days)
                        .Select(offset => e.Schedule.DateIn.AddDays(offset)).Where(date => date.DayOfWeek == e.Day)
                        .ToArray());

            //Синтаксис запросов
            var range1 =
                        from e in emloyeeDays
                        select new
                        {
                            Dates = Enumerable.Range(0, 1 + e.Schedule.DateOut.Subtract(e.Schedule.DateIn).Days).Select(offset => e.Schedule.DateIn.AddDays(offset)).ToArray()
                        }.Dates.Where(date => date.DayOfWeek == e.Day);

            foreach (var item in range1)
            {
                foreach (var i in item)
                {
                    Console.WriteLine(i.ToShortDateString());
                }
            }
            Console.WriteLine();

            foreach (var item in range)
            {
                foreach(var i in item)
                {
                    Console.WriteLine(i.ToShortDateString());
                }
            }
            Console.WriteLine();
        }
    }
}
