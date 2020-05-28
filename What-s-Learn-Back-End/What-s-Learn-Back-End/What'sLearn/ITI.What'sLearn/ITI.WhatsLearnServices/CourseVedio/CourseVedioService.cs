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
    public class CourseVedioService
    {

        UnitOfWork unitOfWork;
        Generic<CourseVedio> CourseVedioRepo;
        public CourseVedioService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CourseVedioRepo = unitOfWork.CourseVedioRepo;
        }
        public CourseVedioEditViewModel Add(CourseVedioEditViewModel CourseVedio)
        {
            CourseVedio c = CourseVedioRepo.Add(CourseVedio.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseVedioEditViewModel Update(CourseVedioEditViewModel CourseVedio)
        {
            CourseVedio c = CourseVedioRepo.Update(CourseVedio.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseVedioViewModel GetByID(int id)
        {
            return CourseVedioRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<CourseVedioViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
                CourseVedioRepo.GetAll();
            query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseVedioViewModel> Get(Expression<Func<CourseVedio, bool>> filter)
        {
            var query =
                CourseVedioRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CourseVedioRepo.Remove(CourseVedioRepo.GetByID(id));
            unitOfWork.Commit();

        }

    }
}
