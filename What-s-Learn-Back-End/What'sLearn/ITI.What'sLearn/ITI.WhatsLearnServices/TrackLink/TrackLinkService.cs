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
    public class TrackLinkService
    {
        
        UnitOfWork unitOfWork;
        Generic<TrackLink> TrackLinkRepo;
        public TrackLinkService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackLinkRepo = unitOfWork.TrackLinkRepo;
        }
        public TrackLinkEditViewModel Add(TrackLinkEditViewModel P)
        {
            TrackLink PP = TrackLinkRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackLinkEditViewModel Update(TrackLinkEditViewModel P)
        {
            TrackLink PP = TrackLinkRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackLink GetByID(int id)
        {
            return TrackLinkRepo.GetByID(id);
        }
        public IEnumerable<TrackLinkViewModel> GetAll(){
            var query =
                TrackLinkRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackLinkViewModel> Get(int id, string desc, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackLinkRepo.Get
                    (i => i.ID == id || i.Description == desc );
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackLinkRepo.Remove(TrackLinkRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
