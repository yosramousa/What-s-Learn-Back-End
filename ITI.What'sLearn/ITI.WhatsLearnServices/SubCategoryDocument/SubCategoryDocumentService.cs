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
    public class SubCategoryDocumentService
    {
        
        UnitOfWork unitOfWork;
        Generic<SubCategoryDocument> SubCategoryDocumentRepo;
        public SubCategoryDocumentService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SubCategoryDocumentRepo = unitOfWork.SubCategoryDocumentRepo;
        }
        public SubCategoryDocumentEditViewModel Add(SubCategoryDocumentEditViewModel P)
        {
            SubCategoryDocument PP = SubCategoryDocumentRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public SubCategoryDocumentEditViewModel Update(SubCategoryDocumentEditViewModel P)
        {
            SubCategoryDocument PP = SubCategoryDocumentRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public SubCategoryDocument GetByID(int id)
        {
            return SubCategoryDocumentRepo.GetByID(id);
        }
        public IEnumerable<SubCategoryDocumentViewModel> GetAll(){
            var query =
                SubCategoryDocumentRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryDocumentViewModel> Get(int id, string description, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryDocumentRepo.Get
                    (i => i.ID == id || i.Description ==description);
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            SubCategoryDocumentRepo.Remove(SubCategoryDocumentRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
