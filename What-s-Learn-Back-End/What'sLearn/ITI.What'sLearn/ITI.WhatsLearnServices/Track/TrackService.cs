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
        public TrackService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackRepo = unitOfWork.TrackRepo;
        }
        public TrackEditViewModel Add(TrackEditViewModel P)
        {
            Track PP = TrackRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackEditViewModel Update(TrackEditViewModel P)
        {
            Track PP = TrackRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
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
            query = query.OrderByDescending(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
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
    }
}
