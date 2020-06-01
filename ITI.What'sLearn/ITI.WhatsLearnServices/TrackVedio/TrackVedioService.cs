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
    public class TrackVedioService
    {
        
        UnitOfWork unitOfWork;
        Generic<TrackVedio> TrackVedioRepo;
        public TrackVedioService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackVedioRepo = unitOfWork.TrackVedioRepo;
        }
        public TrackVedioEditViewModel Add(TrackVedioEditViewModel P)
        {
            TrackVedio PP = TrackVedioRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackVedioEditViewModel Update(TrackVedioEditViewModel P)
        {
            TrackVedio PP = TrackVedioRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackVedio GetByID(int id)
        {
            return TrackVedioRepo.GetByID(id);
        }
        public IEnumerable<TrackVedioViewModel> GetAll(){
            var query =
                TrackVedioRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackVedioViewModel> Get(int id, string desc, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackVedioRepo.Get
                    (i => i.ID == id || i.Description == desc );
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackVedioRepo.Remove(TrackVedioRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
