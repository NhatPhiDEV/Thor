using System.Collections.Generic;
using Thor.Entities;

namespace Thor.BusinessLogicLayer.Services.Courses
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
