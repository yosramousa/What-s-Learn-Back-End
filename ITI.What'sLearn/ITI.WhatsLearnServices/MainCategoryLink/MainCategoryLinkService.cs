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
    public class MainCategoryLinkService
    {

        UnitOfWork unitOfWork;
        Generic<MainCategoryLink> MainCategoryLinkRepo;
        public MainCategoryLinkService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MainCategoryLinkRepo = unitOfWork.MainCategoryLinkRepo;
        }
        public MainCategoryLinkEditViewModel Add(MainCategoryLinkEditViewModel MainCategoryLink)
        {
            MainCategoryLink c = MainCategoryLinkRepo.Add(MainCategoryLink.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryLinkEditViewModel Update(MainCategoryLinkEditViewModel MainCategoryLink)
        {
            MainCategoryLink c = MainCategoryLinkRepo.Update(MainCategoryLink.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryLinkViewModel GetByID(int id)
        {
            return MainCategoryLinkRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<MainCategoryLinkViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryLinkRepo.GetAll();
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryLinkViewModel> Get(Expression<Func<MainCategoryLink, bool>> filter)
        {
            var query =
                MainCategoryLinkRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            MainCategoryLinkRepo.Remove(MainCategoryLinkRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
