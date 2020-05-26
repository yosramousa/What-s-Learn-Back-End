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
    public class TrackCourseVedioService
    {
        
        UnitOfWork unitOfWork;
        Generic<TrackCourseVedio> TrackCourseVedioRepo;
        public TrackCourseVedioService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackCourseVedioRepo = unitOfWork.TrackCourseVedioRepo;
        }
        public TrackCourseVedioEditViewModel Add(TrackCourseVedioEditViewModel P)
        {
            TrackCourseVedio PP = TrackCourseVedioRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseVedioEditViewModel Update(TrackCourseVedioEditViewModel P)
        {
            TrackCourseVedio PP = TrackCourseVedioRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseVedio GetByID(int id)
        {
            return TrackCourseVedioRepo.GetByID(id);
        }
        public IEnumerable<TrackCourseVedioViewModel> GetAll(){
            var query =
                TrackCourseVedioRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackCourseVedioViewModel> Get(int id, string desc, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackCourseVedioRepo.Get
                    (i => i.ID == id || i.Description == desc );
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackCourseVedioRepo.Remove(TrackCourseVedioRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
