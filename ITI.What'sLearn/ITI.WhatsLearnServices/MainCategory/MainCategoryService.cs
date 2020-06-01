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
        Generic<MainCategoryDocument> MainCategoryDocumentRepo;
        Generic<MainCategoryLink> MainCategoryLinkRepo;
        Generic<MainCategoryVedio> MainCategoryVedioRepo;


        Generic<SubCategory> subCategoryRepo;



        public MainCategoryService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MainCategoryRepo = unitOfWork.MainCategoryRepo;
            subCategoryRepo = unitOfWork.SubCategoryRepo;
            MainCategoryDocumentRepo = unitOfWork.MainCategoryDocumentRepo;
            MainCategoryLinkRepo = unitOfWork.MainCategoryLinkRepo;
            MainCategoryVedioRepo = unitOfWork.MainCategoryVedioRepo;


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
            foreach ( MainCategoryDocument doc in c.MainCategoryDocuments)
            {

                MainCategoryDocumentRepo.Update(doc);

            }
            foreach (MainCategoryLink   doc in c.MainCategoryLinks)
            {

                MainCategoryLinkRepo.Update(doc);

            }
            foreach (MainCategoryVedio  doc in c.MainCategoryVedios)
            {

                MainCategoryVedioRepo.Update(doc);

            }
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public MainCategoryViewModel GetByID(int id)
        {
            MainCategoryViewModel m = MainCategoryRepo.GetByID(id)?.ToViewModel();
            return m;
        }
        public IEnumerable<MainCategoryViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.GetAll(); 
             query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> SearchByChilds(string ChildName ,int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.Get(i => i.SubCategories.Select(x=>x.Name).Contains(ChildName));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> SearchByName(string Name,int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.Get(i=>i.Name.Contains( Name));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }


        public void Remove(int id)
        {
            MainCategoryRepo.Remove(MainCategoryRepo.GetByID(id));
            unitOfWork.Commit();

        }

        public int Count()
        {
            return MainCategoryRepo.Count();
        }

    }
}
