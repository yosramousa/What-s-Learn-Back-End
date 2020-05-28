using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearnServices
{
    public class CourseService
    {
        UnitOfWork unitOfWork;
        Generic<Course> CourseRepo;
        public CourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CourseRepo = unitOfWork.CourseRepo;
        }
        public CourseEditViewModel Add(CourseEditViewModel course)
        {
            Course c = CourseRepo.Add(course.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseEditViewModel Update(CourseEditViewModel course)
        {
            Course c = CourseRepo.Update(course.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseViewModel GetByID(int id)
        {
            return CourseRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<CourseViewModel> Get(int pageIndex, int pageSize = 20)
        {
            var query =
                CourseRepo.GetAll();
            query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseViewModel> Get(Expression<Func<Course, bool>> filter)
        {
            var query =
                CourseRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CourseRepo.Remove(CourseRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
