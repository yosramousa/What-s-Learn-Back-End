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
    public class SubCategoryService
    {
        UnitOfWork unitOfWork;
        Generic<SubCategory> SubCategoryRepo;
        public SubCategoryService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SubCategoryRepo = unitOfWork.SubCategoryRepo;
        }
        public SubCategoryEditViewModel Add(SubCategoryEditViewModel subCategory)
        {
            SubCategory sub = SubCategoryRepo.Add(subCategory.ToModel());
            unitOfWork.Commit();
            return sub.ToEditableViewModel();
        }
        public SubCategoryEditViewModel Update(SubCategoryEditViewModel subCategory)
        {
            SubCategory sub = SubCategoryRepo.Update(subCategory.ToModel());
            unitOfWork.Commit();
            return sub.ToEditableViewModel();
        }
        public SubCategoryViewModel GetByID(int id)
        {
            return SubCategoryRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<SubCategoryViewModel> GetList( int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> Get(Expression<Func<SubCategory, bool>> filter)
        {
            var query =
                SubCategoryRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public void Remove(int id)
        {
            SubCategoryRepo.Remove(SubCategoryRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
