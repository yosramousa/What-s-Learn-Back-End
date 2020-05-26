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
    public class TrackCourseLinkService
    {
        
        UnitOfWork unitOfWork;
        Generic<TrackCourseLink> TrackCourseLinkRepo;
        public TrackCourseLinkService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackCourseLinkRepo = unitOfWork.TrackCourseLinkRepo;
        }
        public TrackCourseLinkEditViewModel Add(TrackCourseLinkEditViewModel P)
        {
            TrackCourseLink PP = TrackCourseLinkRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseLinkEditViewModel Update(TrackCourseLinkEditViewModel P)
        {
            TrackCourseLink PP = TrackCourseLinkRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseLink GetByID(int id)
        {
            return TrackCourseLinkRepo.GetByID(id);
        }
        public IEnumerable<TrackCourseLinkViewModel> GetAll(){
            var query =
                TrackCourseLinkRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackCourseLinkViewModel> Get(int id, string desc, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackCourseLinkRepo.Get
                    (i => i.ID == id || i.Description == desc );
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackCourseLinkRepo.Remove(TrackCourseLinkRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
