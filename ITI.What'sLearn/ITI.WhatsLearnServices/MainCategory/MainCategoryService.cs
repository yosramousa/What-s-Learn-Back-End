using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
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
            List <MainCategoryDocument> NewDoc = c.MainCategoryDocuments.ToList();
            List<MainCategoryLink> NewLinks= c.MainCategoryLinks.ToList();

            List<MainCategoryVedio> NewVedios = c.MainCategoryVedios.ToList();



            foreach (MainCategoryDocument doc in NewDoc)
            {
                if (doc.ID == 0)
                {
                    MainCategoryDocumentRepo.Add(doc);
                }
                else
                    MainCategoryDocumentRepo.Update(doc);

            }
            var Docs = MainCategoryDocumentRepo.GetAll().Where(i => i.MainCategoryID == c.ID);
            foreach (var doc in Docs)
            {
                if(!NewDoc.Contains(doc))
                {
                    MainCategoryDocumentRepo.Remove(doc);

                }
            }
           
            foreach (MainCategoryLink link in NewLinks)
            {
                if (link.ID == 0)
                    MainCategoryLinkRepo.Add(link);

                else
                    MainCategoryLinkRepo.Update(link);

            }
            var Links = MainCategoryLinkRepo.GetAll().Where(i => i.MainCategoryID == c.ID);
            foreach (var link in Links)
            {
                if (!NewLinks.Contains(link))
                {
                    MainCategoryLinkRepo.Remove(link);

                }
            }
           
            foreach (MainCategoryVedio Vedio in  NewVedios)
            {
                if (Vedio.ID == 0)
                    MainCategoryVedioRepo.Add(Vedio);
                else

                    MainCategoryVedioRepo.Update(Vedio);

            }
            var Vedios = MainCategoryVedioRepo.GetAll().Where(i => i.MainCategoryID == c.ID);
            foreach (var vedio in Vedios)
            {
                if (!NewVedios.Contains(vedio))
                {
                    MainCategoryVedioRepo.Remove(vedio);

                }
            }
          
            unitOfWork.Commit();
            
            return c.ToEditableViewModel();
        }
        public MainCategoryViewModel GetByID(int id)
        {
            MainCategory m = MainCategoryRepo.GetByID(id);
            
            m.MainCategoryDocuments = Documents(m);
         
            m.MainCategoryLinks = Links(m);

            m.MainCategoryVedios = Vedios(m);

            return m.ToViewModel();
        }
        public IEnumerable<MainCategoryViewModel> GetAll()
        {
            var query = MainCategoryRepo.GetAll();
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategory> Get()
        {
            var query = MainCategoryRepo.GetAll();
            return query.ToList();
        }
        public IEnumerable<MainCategoryViewModel> GetAll(out int count, int SortBy, int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.GetAll();
                //.Select(j=>j.MainCategoryDocuments.
                //SkipWhile(x=>x.IsDeleted==true)
                //.SkipWhile(x => x.IsDeleted == true));
            count = query.Count();
            switch (SortBy)
            {
                case 0:
                case 4:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                case 5:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;


                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> GetAll( int pageIndex, int pageSize )
        {
            var query =
                MainCategoryRepo.GetAll();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> SearchByChilds(out int count ,int SortBy, string ChildName ,int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.Get(i => i.SubCategories.Select(x => x.Name).Contains(ChildName));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                case 4:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                case 5:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;


                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> SearchByName(out int count, int SortBy, string Name, int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.Get(i => i.Name.Contains(Name));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                case 4:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                case 5:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;


                default:
                    break;
            }
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
        public IEnumerable<MainCategoryViewModel> SortBYNameAsc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.GetAll();
            count = query.Count();
            query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<MainCategoryViewModel> SortBYNameDesc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                MainCategoryRepo.GetAll();
            count = query.Count();
            query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public List<MainCategoryDocument> Documents(MainCategory m)
        {
            return m.MainCategoryDocuments.Where(d => d.IsDeleted == false)?.ToList();

        }
        public List<MainCategoryVedio> Vedios(MainCategory m)
        {
            return m.MainCategoryVedios.Where(i => i.IsDeleted == false)?.ToList();

        }
        public List<MainCategoryLink> Links(MainCategory m)
        {
            return m.MainCategoryLinks.Where(i => i.IsDeleted == false)?.ToList();


        }

    }
}
