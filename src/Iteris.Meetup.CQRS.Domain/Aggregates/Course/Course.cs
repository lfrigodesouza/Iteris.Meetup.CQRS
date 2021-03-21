using Iteris.Meetup.CQRS.Domain.SeedWorks;
using System;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.Course
{
    public class Course : Entity
    {
        private Course()
        {
        }

        public static Course DefaultEntity() => new Course();

        public Course(int courseId, DateTime startDate, DateTime endDate, int maxEnrollment)
        {
            CourseId = courseId;
            MaxEnrollment = maxEnrollment;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int CourseId { get; }
        public int MaxEnrollment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}