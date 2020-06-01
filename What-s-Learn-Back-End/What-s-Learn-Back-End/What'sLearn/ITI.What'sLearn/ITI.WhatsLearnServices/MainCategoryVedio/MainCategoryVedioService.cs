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
    public class MainCategoryVedioService
    {
        UnitOfWork unitOfWork;
        Generic<MainCategoryVedio> MainCategoryVedioRepo;
        public MainCategoryVedioService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MainCategoryVedioRepo = unitOfWork.MainCategoryVedioRepo;
        }
        public MainCategoryVedioEditViewModel Add(MainCategoryVedioEditViewModel MainCategoryVedio)
        {
            MainCategoryVedio c = MainCategoryVedioRepo.Add(MainCategoryVedio.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryVedioEditViewModel Update(MainCategoryVedioEditViewModel MainCategoryVedio)
        {
            MainCategoryVedio c = MainCategoryVedioRepo.Update(MainCategoryVedio.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryVedioViewModel GetByID(int id)
        {
            return MainCategoryVedioRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<MainCategoryVedioViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryVedioRepo.GetAll();
            query = query .OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<MainCategoryVedioViewModel> Get(Expression<Func<MainCategoryVedio, bool>> filter)
        {
            var query =
                MainCategoryVedioRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            MainCategoryVedioRepo.Remove(MainCategoryVedioRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
