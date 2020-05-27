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
    public class MainCategoryService
    {

        UnitOfWork unitOfWork;
        Generic<MainCategory> MainCategoryRepo;
        public MainCategoryService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MainCategoryRepo = unitOfWork.MainCategoryRepo;
        }
        public MainCategoryEditViewModel Add(MainCategoryEditViewModel MainCategory)
        {
            MainCategory c = MainCategoryRepo.Add(MainCategory.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryEditViewModel Update(MainCategoryEditViewModel MainCategory)
        {
            MainCategory c = MainCategoryRepo.Update(MainCategory.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryViewModel GetByID(int id)
        {
            return MainCategoryRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<MainCategoryViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> Get(Expression<Func<MainCategory, bool>> filter)
        {
            var query =
                MainCategoryRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            MainCategoryRepo.Remove(MainCategoryRepo.GetByID(id));
            unitOfWork.Commit();

        }

    }
}
