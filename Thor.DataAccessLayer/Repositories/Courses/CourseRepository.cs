using Thor.DataAccessLayer.Repositories.Core;
using Thor.Entities;

namespace Thor.DataAccessLayer.Repositories.Courses
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        protected override string TableName => "Courses";
        protected override string GetAllQuery() => $"SELECT Id, Name, Description FROM {TableName}";
        protected override string GetByIdQuery(int Id) => $"SELECT Id, Name, Description FROM {TableName} WHERE Id = {Id}";

    }
}
