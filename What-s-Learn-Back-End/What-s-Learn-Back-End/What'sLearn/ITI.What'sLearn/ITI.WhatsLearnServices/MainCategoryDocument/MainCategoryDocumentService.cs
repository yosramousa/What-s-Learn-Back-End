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
    public class MainCategoryDocumentService
    {

        UnitOfWork unitOfWork;
        Generic<MainCategoryDocument> MainCategoryDocumentRepo;
        public MainCategoryDocumentService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MainCategoryDocumentRepo = unitOfWork.MainCategoryDocumentRepo;
        }
        public MainCategoryDocumentEditViewModel Add(MainCategoryDocumentEditViewModel MainCategoryDocument)
        {
            MainCategoryDocument c = MainCategoryDocumentRepo.Add(MainCategoryDocument.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryDocumentEditViewModel Update(MainCategoryDocumentEditViewModel MainCategoryDocument)
        {
            MainCategoryDocument c = MainCategoryDocumentRepo.Update(MainCategoryDocument.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryDocumentViewModel GetByID(int id)
        {
            return MainCategoryDocumentRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<MainCategoryDocumentViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryDocumentRepo.GetAll();
            query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryDocumentViewModel> Get(Expression<Func<MainCategoryDocument, bool>> filter)
        {
            var query =
                MainCategoryDocumentRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            MainCategoryDocumentRepo.Remove(MainCategoryDocumentRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
