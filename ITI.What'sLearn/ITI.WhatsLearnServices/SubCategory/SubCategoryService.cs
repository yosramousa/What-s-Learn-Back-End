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

         Generic<SubCategoryDocument> SubCategoryDocumentRepo;
         Generic<SubCategoryVedio > SubCategoryVedioRepo;
        
        Generic<SubCategoryLink> SubCategoryLinkRepo;
        public SubCategoryService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SubCategoryRepo = unitOfWork.SubCategoryRepo;
            SubCategoryDocumentRepo = unitOfWork.SubCategoryDocumentRepo;
            SubCategoryVedioRepo = unitOfWork.SubCategoryVedioRepo;
            SubCategoryLinkRepo = unitOfWork.SubCategoryLinkRepo;

        }
        public SubCategory Add(SubCategoryEditViewModel subCategory)
        {
            SubCategory sub = SubCategoryRepo.Add(subCategory.ToModel());
            unitOfWork.Commit();
            return sub;
        }
        public SubCategoryEditViewModel Update(SubCategoryEditViewModel subCategory)
        {
            SubCategory sub = SubCategoryRepo.Update(subCategory.ToModel());

            foreach (SubCategoryDocument doc in sub.SubCategoryDocuments)
            {

                SubCategoryDocumentRepo.Update(doc);

            }
            foreach (SubCategoryLink doc in sub.SubCategoryLinks)
            {

                SubCategoryLinkRepo.Update(doc);

            }
            foreach (SubCategoryVedio doc in sub.SubCategoryVedios)
            {

                SubCategoryVedioRepo.Update(doc);

            }

            unitOfWork.Commit();
            return sub.ToEditableViewModel();
        }
        public SubCategoryViewModel GetByID(int id)
        {
            return SubCategoryRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<SubCategoryViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.GetAll();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SeachByID(int ID)
        {
            var query =
                SubCategoryRepo.Get(i=>i.ID==ID);
               return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> Get(Expression<Func<SubCategory, bool>> filter)
        {
            var query =
                SubCategoryRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SearchByName(string Name,int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.Get(i=>i.Name.Contains(Name));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());


        }

        public IEnumerable<SubCategoryViewModel> SearchByChilds(string ChildName, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.Get(i => i.Tracks.Select(x => x.Name).Contains(ChildName));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SearchByParentName(string Parent, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.Get(i => i.MainCategory.Name.Contains(Parent));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());


        }

        public void Remove(int id)
        {
            SubCategoryRepo.Remove(SubCategoryRepo.GetByID(id));
            unitOfWork.Commit();

        }
        public int Count()
        {
            return SubCategoryRepo.Count();
        }
    }
}
