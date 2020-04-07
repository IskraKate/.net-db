﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            var _schedules = new List<Schedule>();
            var _daysOfWork = new List<DaysOfWork>();
            string _employeeName = "First Employee";

            #region AddingScheduleElements

            _schedules.Add(new Schedule
            {
                Name = "First Employee",
                DateIn = new DateTime(2020, 04, 06),
                DateOut = new DateTime(2020, 04, 16)
            });


            _schedules.Add(new Schedule
            {
                Name = "Second Employee",
                DateIn = new DateTime(2020, 04, 16),
                DateOut = new DateTime(2020, 04, 30)
            });


            _schedules.Add(new Schedule
            {
                Name = "Third Employee",
                DateIn = new DateTime(2020, 05, 01),
                DateOut = new DateTime(2020, 05, 15)
            });

            #endregion

            #region AddingDayOfWeekElements

            _daysOfWork.Add(new DaysOfWork
            {
                Schedule = _schedules[0],
                Day = DayOfWeek.Monday
            });

            _daysOfWork.Add(new DaysOfWork
            {
                Schedule = _schedules[1],
                Day = DayOfWeek.Thursday
            });

            _daysOfWork.Add(new DaysOfWork
            {
                Schedule = _schedules[2],
                Day = DayOfWeek.Wednesday
            });

            #endregion



            DateTime dateTime1 = new DateTime(2020, 04, 07);
            DateTime dateTime2 = new DateTime(2020, 05, 07);


            var array = Enumerable.Range(0, 1 + dateTime2.Subtract(dateTime1).Days)
              .Select(offset => dateTime1.AddDays(offset))
            .ToArray();

            //from d in _daysOfWork
            //            where d.Schedule.Name == _employeeName
            //            select (offset =>
            //            {
            //                Enumerable.Range(0, 1 + d.Schedule.DateOut.Subtract(d.Schedule.DateIn).Days)
            //                 .Select(offset => d.Schedule.DateIn.AddDays(offset));
            //             });
                        
                        


            foreach (var a in array)
            {
                Console.WriteLine(a.ToShortDateString());
            }

        }
    }
}
