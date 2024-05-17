using Thor.BusinessLogicLayer.Services.Courses;
using Thor.DataAccessLayer;
using Thor.Entities;

namespace Thor.UnitTest.Courses
{
    [TestFixture]
    public class CourseRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private ICourseService _courseService;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = new UnitOfWork();
            _courseService = new CourseService();
        }

        [TearDown]
        public void TearDown()
        {
            _unitOfWork.Dispose();
        }

        [Test]
        public void Test_GetAllSource()
        {
            _unitOfWork.BeginTransaction();

            var allCourses = _courseService.GetAllCourses();

            _unitOfWork.Commit();

            Assert.That(allCourses.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Test_AddCourse()
        {
            var newCourse = new Course
            {
                Name = "Toán cao cấp 9",
                Description = "Học về các khái niệm toán học nâng cao"
            };

            _unitOfWork.BeginTransaction();

            _courseService.AddCourse(newCourse);

            var allCourses = _courseService.GetAllCourses();

            _unitOfWork.Commit();

            Assert.That(allCourses.Any(item => item.Name.Equals(newCourse.Name)), Is.True);
        }

        [Test]
        public void Test_UpdateCourse()
        {
            int updateId = 1;
            string newCourseName = "New Course 1";
            var newCourse = new Course
            {
                Id = updateId,
                Name = newCourseName,
                Description = "Học về các khái niệm toán học nâng cao"
            };

            _unitOfWork.BeginTransaction();

            _courseService.UpdateCourse(newCourse);

            var course = _courseService.GetCourseById(updateId);

            _unitOfWork.Commit();

            if (course is null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.That(course.Name, Is.EqualTo(newCourseName));
            }
        }
    }
}
