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
    public class TrackCourseService
    {
        
        UnitOfWork unitOfWork;
        Generic<TrackCourse> TrackCourseRepo;
        public TrackCourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackCourseRepo = unitOfWork.TrackCourseRepo;
        }
        public TrackCourseEditViewModel Add(TrackCourseEditViewModel P)
        {
            TrackCourse PP = TrackCourseRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseEditViewModel Update(TrackCourseEditViewModel P)
        {
            TrackCourse PP = TrackCourseRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourse GetByID(int id)
        {
            return TrackCourseRepo.GetByID(id);
        }
        public IEnumerable<TrackCourseViewModel> GetAll(){
            var query =
                TrackCourseRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackCourseViewModel> Get(int id, string name, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackCourseRepo.Get
                    (i => i.ID == id || i.Name == name );
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackCourseRepo.Remove(TrackCourseRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
