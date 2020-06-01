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
    public class SubCategoryLinkService
    {
        
        UnitOfWork unitOfWork;
        Generic<SubCategoryLink> SubCategoryLinkRepo;
        public SubCategoryLinkService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SubCategoryLinkRepo = unitOfWork.SubCategoryLinkRepo;
        }
        public SubCategoryLinkEditViewModel Add(SubCategoryLinkEditViewModel P)
        {
            SubCategoryLink PP = SubCategoryLinkRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public SubCategoryLinkEditViewModel Update(SubCategoryLinkEditViewModel P)
        {
            SubCategoryLink PP = SubCategoryLinkRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public SubCategoryLink GetByID(int id)
        {
            return SubCategoryLinkRepo.GetByID(id);
        }
        public IEnumerable<SubCategoryLinkViewModel> GetAll(){
            var query =
                SubCategoryLinkRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryLinkViewModel> Get(int id, string description, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryLinkRepo.Get
                    (i => i.ID == id || i.Description ==description);
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            SubCategoryLinkRepo.Remove(SubCategoryLinkRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
