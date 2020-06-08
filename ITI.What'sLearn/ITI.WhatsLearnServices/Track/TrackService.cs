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
    public class TrackService
    {

        UnitOfWork unitOfWork;
        Generic<Track> TrackRepo;
        Generic<TrackDocument> TrackDocumentRepo;
        Generic<TrackVedio> TrackVedioRepo;

        Generic<TrackLink> TrackLinkRepo;
        public TrackService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackRepo = unitOfWork.TrackRepo;
            TrackDocumentRepo = unitOfWork.TrackDocumentRepo;
            TrackVedioRepo = unitOfWork.TrackVedioRepo;
            TrackLinkRepo = unitOfWork.TrackLinkRepo;

        }

        public Track Add(TrackEditViewModel P)
        {
            Track PP = TrackRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP;
        }
        public Track Update(TrackEditViewModel P)
        {
            Track Track = TrackRepo.Update(P.ToModel());

            List<TrackDocument> NewDoc = Track.TrackDocuments.ToList();
            List<TrackLink> NewLinks = Track.TrackLinks.ToList();

            List<TrackVedio> NewVedios = Track.TrackVedios.ToList();

            //Update or Add


            foreach (TrackDocument doc in NewDoc)
            {
                if (doc.ID == 0)
                {
                    TrackDocumentRepo.Add(doc);
                }
                else
                    TrackDocumentRepo.Update(doc);

            }

            foreach (TrackLink link in NewLinks)
            {
                if (link.ID == 0)
                    TrackLinkRepo.Add(link);

                else
                    TrackLinkRepo.Update(link);

            }

            foreach (TrackVedio Vedio in NewVedios)
            {
                if (Vedio.ID == 0)
                    TrackVedioRepo.Add(Vedio);
                else

                    TrackVedioRepo.Update(Vedio);

            }

            //Delete

            var Docs = TrackDocumentRepo.GetAll().Where(i => i.TrackID == Track.ID);
            foreach (var doc in Docs)
            {
                if (!NewDoc.Contains(doc))
                {
                    TrackDocumentRepo.Remove(doc);

                }
            }


            var Links = TrackLinkRepo.GetAll().Where(i => i.TrackID == Track.ID);
            foreach (var link in Links)
            {
                if (!NewLinks.Contains(link))
                {
                    TrackLinkRepo.Remove(link);

                }
            }

            var Vedios = TrackVedioRepo.GetAll().Where(i => i.TrackID == Track.ID);
            foreach (var vedio in Vedios)
            {
                if (!NewVedios.Contains(vedio))
                {
                    TrackVedioRepo.Remove(vedio);

                }
            }
            unitOfWork.Commit();
            return Track;
        }
        public Track GetByID(int id)
        {
            Track m = TrackRepo.GetByID(id);
            m.TrackDocuments = Documents(m);

            m.TrackLinks = Links(m);

            m.TrackVedios = Vedios(m);
            return m;

        }

        public IEnumerable<TrackViewModel> GetAll(out int count, int SortBy, int pageIndex, int pageSize = 20)
        {
            var query =
              TrackRepo.GetAll();
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
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackViewModel> GetAll(int pageIndex, int pageSize)
        {
            var query =
                TrackRepo.GetAll();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackRepo.Remove(TrackRepo.GetByID(id));
            unitOfWork.Commit();
        }

        public int Count()
        {
            return TrackRepo.Count();
        }

        public IEnumerable<TrackViewModel> SeachByID(int ID)
        {
            var query =
                TrackRepo.Get(i => i.ID == ID);

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackViewModel> SearchByName(out int count, int SortBy, string Name, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.Get(i => i.Name.Contains(Name));
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
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());


        }
        public IEnumerable<TrackViewModel> SearchByChilds(out int count, int SortBy, string ChildName, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.Get(i => i.Courses.Select(x => x.Course.Name).Contains(ChildName));
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
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackViewModel> SearchByParentName(out int count, int SortBy, string Parent, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.Get(i => i.SubCategory.Name.Contains(Parent));
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
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.SubCategory.Name).Skip(pageIndex * pageSize).Take(pageSize);
                    break;
                default:
                    break;
            }
            return query.ToList().Select(i => i.ToViewModel());


        }
        public IEnumerable<TrackViewModel> GetByParentID(out int count,int ParentID, int pageIndex, int pageSize)
        {
            var query =
              TrackRepo.Get(i => i.SubCategory.ID == ParentID);
            count = query.Count();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());

        }
        public List<TrackDocument> Documents(Track m)
        {
            return m.TrackDocuments.Where(d => d.IsDeleted == false).ToList();

        }
        public List<TrackVedio> Vedios(Track m)
        {
            return m.TrackVedios.Where(i => i.IsDeleted == false).ToList();

        }
        public List<TrackLink> Links(Track m)
        {
            return m.TrackLinks.Where(i => i.IsDeleted == false).ToList();


        }

        public IEnumerable<TrackViewModel> Get(Expression<Func<Track, bool>> filter)
        {
            var query =
                TrackRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }

    }
}
