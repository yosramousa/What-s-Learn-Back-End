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
    public class FinishedCourseService
    {

        UnitOfWork unitOfWork;
        Generic<FinishedCourse> FinishedCourseRepo;
        public FinishedCourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            FinishedCourseRepo = unitOfWork.FinishedCourseRepo;
        }
        public FinishedCourseEditViewModel Add(FinishedCourseEditViewModel FinishedCourse)
        {
            FinishedCourse c = FinishedCourseRepo.Add(FinishedCourse.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public FinishedCourseEditViewModel Update(FinishedCourseEditViewModel FinishedCourse)
        {
            FinishedCourse c = FinishedCourseRepo.Update(FinishedCourse.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public FinishedCourseViewModel GetByID(int id)
        {
            return FinishedCourseRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<FinishedCourseViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                FinishedCourseRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<FinishedCourseViewModel> Get(Expression<Func<FinishedCourse, bool>> filter)
        {
            var query =
                FinishedCourseRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            FinishedCourseRepo.Remove(FinishedCourseRepo.GetByID(id));
        }
    }
}
