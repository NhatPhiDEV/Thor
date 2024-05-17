using System;
using System.Collections.Generic;
using Thor.DataAccessLayer;
using Thor.DataAccessLayer.Repositories.Core;
using Thor.DataAccessLayer.Repositories.Courses;
using Thor.Entities;

namespace Thor.BusinessLogicLayer.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IBaseRepository<Course> _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService()
        {
            _unitOfWork = new UnitOfWork();
            _courseRepository = new CourseRepository(_unitOfWork);
        }


        public void AddCourse(Course course)
        {
            // Thực hiện các validation cần thiết cho Course
            if (string.IsNullOrWhiteSpace(course.Name))
            {
                throw new ArgumentException("Course name cannot be empty.");
            }

            _unitOfWork.BeginTransaction();

            try
            {
                _courseRepository.Create(course);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ArgumentException("AddCourse" + ex.Message);
            }
        }

        public void DeleteCourse(int id)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                _courseRepository.Delete(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ArgumentException("DeleteCourse" + ex.Message);
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            _unitOfWork.BeginTransaction();
            var allCourses = _courseRepository.GetAll();
            _unitOfWork.Commit();
            return allCourses;
        }

        public Course GetCourseById(int id)
        {
            _unitOfWork.BeginTransaction();
            var course = _courseRepository.GetById(id);
            _unitOfWork.Commit();
            return course;
        }

        public void UpdateCourse(Course course)
        {
            // Thực hiện các validation cần thiết cho Course
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            if (string.IsNullOrWhiteSpace(course.Name))
            {
                throw new ArgumentException("Course name cannot be empty.");
            }
            _unitOfWork.BeginTransaction();
            try
            {
                _courseRepository.Update(course);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ArgumentException("UpdateCourse" + ex.Message);
            }
        }
    }
}
