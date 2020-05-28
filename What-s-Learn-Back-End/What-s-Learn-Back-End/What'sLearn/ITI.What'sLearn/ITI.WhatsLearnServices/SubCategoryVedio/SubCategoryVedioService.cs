using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
{
    public class SubCategoryVedioService
    {
        
        UnitOfWork unitOfWork;
        Generic<SubCategoryVedio> SubCategoryVedioRepo;
        public SubCategoryVedioService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SubCategoryVedioRepo = unitOfWork.SubCategoryVedioRepo;
        }
        public SubCategoryVedioEditViewModel Add(SubCategoryVedioEditViewModel P)
        {
            SubCategoryVedio PP = SubCategoryVedioRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public SubCategoryVedioEditViewModel Update(SubCategoryVedioEditViewModel P)
        {
            SubCategoryVedio PP = SubCategoryVedioRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public SubCategoryVedio GetByID(int id)
        {
            return SubCategoryVedioRepo.GetByID(id);
        }
        public IEnumerable<SubCategoryVedioViewModel> GetAll(){
            var query =
                SubCategoryVedioRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryVedioViewModel> Get(int id, string description, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryVedioRepo.Get
                    (i => i.ID == id || i.Description ==description);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            SubCategoryVedioRepo.Remove(SubCategoryVedioRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
