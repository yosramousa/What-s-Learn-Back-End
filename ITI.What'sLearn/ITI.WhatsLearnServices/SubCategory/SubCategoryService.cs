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
    public class SubCategoryService
    {
        UnitOfWork unitOfWork;
        Generic<SubCategory> SubCategoryRepo;

        Generic<SubCategoryDocument> SubCategoryDocumentRepo;
        Generic<SubCategoryVedio> SubCategoryVedioRepo;

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
            List<SubCategoryDocument> NewDoc = sub.SubCategoryDocuments.ToList();
            List<SubCategoryLink> NewLinks = sub.SubCategoryLinks.ToList();

            List<SubCategoryVedio> NewVedios = sub.SubCategoryVedios.ToList();

            //Update Or Add
            foreach (SubCategoryDocument doc in NewDoc)
            {
                if (doc.ID == 0)
                {
                    SubCategoryDocumentRepo.Add(doc);
                }
                else
                    SubCategoryDocumentRepo.Update(doc);

            }
            foreach (SubCategoryLink link in NewLinks)
            {
                if (link.ID == 0)
                    SubCategoryLinkRepo.Add(link);

                else
                    SubCategoryLinkRepo.Update(link);

            }
            foreach (SubCategoryVedio Vedio in NewVedios
                )
            {
                if (Vedio.ID == 0)
                    SubCategoryVedioRepo.Add(Vedio);
                else

                    SubCategoryVedioRepo.Update(Vedio);

            }
            
            ////Delete

            var Docs = SubCategoryDocumentRepo.GetAll().Where(i => i.SubCategoryID == sub.ID);
            foreach (var doc in Docs)
            {
                if (!NewDoc.Contains(doc))
                {
                    SubCategoryDocumentRepo.Remove(doc);

                }
            }

            var Links = SubCategoryLinkRepo.GetAll().Where(i => i.SubCategoryID == sub.ID);
            foreach (var link in Links)
            {
                if (!sub.SubCategoryLinks.Contains(link))
                {
                    SubCategoryLinkRepo.Remove(link);

                }
            }

            var Vedios = SubCategoryVedioRepo.GetAll().Where(i => i.SubCategoryID == sub.ID);
            foreach (var vedio in Vedios)
            {
                if (!NewVedios.Contains(vedio))
                {
                    SubCategoryVedioRepo.Remove(vedio);

                }
            }
            unitOfWork.Commit();
            return sub.ToEditableViewModel();
        }
        public SubCategoryViewModel GetByID(int id)
        {
            SubCategory sub= SubCategoryRepo.GetByID(id);
            sub.SubCategoryDocuments = Documents(sub);

            sub.SubCategoryLinks = Links(sub);

            sub.SubCategoryVedios = Vedios(sub);
            return sub.ToViewModel();

        }
        public IEnumerable<SubCategoryViewModel> GetAll(out int count, int SortBy, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.GetAll();
            count = query.Count();
            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 4:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SeachByID(int ID)
        {
            var query =
                SubCategoryRepo.Get(i => i.ID == ID);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> Get(Expression<Func<SubCategory, bool>> filter)
        {
            var query =
                SubCategoryRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SearchByName(out int count, int SortBy, string Name, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.Get(i => i.Name.Contains(Name));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 4:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());


        }

        public IEnumerable<SubCategoryViewModel> SearchByChilds(out int count, int SortBy, string ChildName, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.Get(i => i.Tracks.Select(x => x.Name).Contains(ChildName));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 4:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SearchByParentName(out int count, int SortBy, string Parent, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.Get(i => i.MainCategory.Name.Contains(Parent));
            count = query.Count();

            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                case 4:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.MainCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
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
        public IEnumerable<SubCategoryViewModel> SortBYNameAsc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.GetAll();
            count = query.Count();
            query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubCategoryViewModel> SortBYNameDesc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                SubCategoryRepo.GetAll();
            count = query.Count();
            query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public List<SubCategoryDocument> Documents(SubCategory m)
        {
            return m.SubCategoryDocuments.Where(d => d.IsDeleted == false).ToList();

        }
        public List<SubCategoryVedio> Vedios(SubCategory m)
        {
            return m.SubCategoryVedios.Where(i => i.IsDeleted == false).ToList();

        }
        public List<SubCategoryLink> Links(SubCategory m)
        {
            return m.SubCategoryLinks.Where(i => i.IsDeleted == false).ToList();


        }


    }
}
