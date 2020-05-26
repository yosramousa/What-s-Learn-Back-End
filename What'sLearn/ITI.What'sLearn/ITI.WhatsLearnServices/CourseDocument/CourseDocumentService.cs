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
    public class CourseDocumentService
    {


        UnitOfWork unitOfWork;
        Generic<CourseDocument> CourseDocumentRepo;
        public CourseDocumentService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CourseDocumentRepo = unitOfWork.CourseDocumentRepo;
        }
        public CourseDocumentEditViewModel Add(CourseDocumentEditViewModel CourseDocument)
        {
            CourseDocument c = CourseDocumentRepo.Add(CourseDocument.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseDocumentEditViewModel Update(CourseDocumentEditViewModel CourseDocument)
        {
            CourseDocument c = CourseDocumentRepo.Update(CourseDocument.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseDocumentViewModel GetByID(int id)
        {
            return CourseDocumentRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<CourseDocumentViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                CourseDocumentRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseDocumentViewModel> Get(Expression<Func<CourseDocument, bool>> filter)
        {
            var query =
                CourseDocumentRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CourseDocumentRepo.Remove(CourseDocumentRepo.GetByID(id));
        }
    }
}

