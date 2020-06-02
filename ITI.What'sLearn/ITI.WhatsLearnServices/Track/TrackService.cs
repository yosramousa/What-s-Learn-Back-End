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
            Track PP = TrackRepo.Update(P.ToModel());

            foreach (TrackDocument doc in PP.TrackDocuments)
            {

                TrackDocumentRepo.Update(doc);

            }
            foreach (TrackLink doc in PP.TrackLinks)
            {

                TrackLinkRepo.Update(doc);

            }
            foreach (TrackVedio doc in PP.TrackVedios)
            {

                TrackVedioRepo.Update(doc);

            }
            unitOfWork.Commit();
            return PP;
        }
        public Track GetByID(int id)
        {
            return TrackRepo.GetByID(id);
        }
        public IEnumerable<TrackViewModel> GetAll(){
            var query =
                TrackRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
              TrackRepo.GetAll();
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
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
        public IEnumerable<TrackViewModel> SearchByName(string Name, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.Get(i => i.Name.Contains(Name));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());


        }

        public IEnumerable<TrackViewModel> SearchByChilds(string ChildName, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.Get(i => i.Courses.Select(x => x.Course.Name).Contains(ChildName));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackViewModel> SearchByParentName(string Parent, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.Get(i => i.SubCategory.Name.Contains(Parent));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());


        }
        public IEnumerable<TrackViewModel> SortBYNameAsc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.GetAll();
            count = query.Count();
            query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackViewModel> SortBYNameDesc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackRepo.GetAll();
            count = query.Count();
            query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

    }
}
