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
    public class CourseLinkService
    {

        UnitOfWork unitOfWork;
        Generic<CourseLink> CourseLinkRepo;
        public CourseLinkService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CourseLinkRepo = unitOfWork.CourseLinkRepo;
        }
        public CourseLinkEditViewModel Add(CourseLinkEditViewModel CourseLink)
        {
            CourseLink c = CourseLinkRepo.Add(CourseLink.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseLinkEditViewModel Update(CourseLinkEditViewModel CourseLink)
        {
            CourseLink c = CourseLinkRepo.Update(CourseLink.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseLinkViewModel GetByID(int id)
        {
            return CourseLinkRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<CourseLinkViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                CourseLinkRepo.GetAll();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseLinkViewModel> Get(Expression<Func<CourseLink, bool>> filter)
        {
            var query =
                CourseLinkRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CourseLinkRepo.Remove(CourseLinkRepo.GetByID(id));
            unitOfWork.Commit();

        }

    }
}
