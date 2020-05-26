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
    public class TrackCourseCourseService
    {
        
        UnitOfWork unitOfWork;
        Generic<TrackCourseCourse> TrackCourseCourseRepo;
        public TrackCourseCourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TrackCourseCourseRepo = unitOfWork.TrackCourseCourseRepo;
        }
        public TrackCourseCourseEditViewModel Add(TrackCourseCourseEditViewModel P)
        {
            TrackCourseCourse PP = TrackCourseCourseRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseCourseEditViewModel Update(TrackCourseCourseEditViewModel P)
        {
            TrackCourseCourse PP = TrackCourseCourseRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public TrackCourseCourse GetByID(int id)
        {
            return TrackCourseCourseRepo.GetByID(id);
        }
        public IEnumerable<TrackCourseCourseViewModel> GetAll(){
            var query =
                TrackCourseCourseRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<TrackCourseCourseViewModel> Get(int id, string TrackCoursename, int pageIndex, int pageSize = 20)
        {
            var query =
                TrackCourseCourseRepo.Get
                    (i => i.ID == id || i.TrackCourse.Name == TrackCoursename );
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            TrackCourseCourseRepo.Remove(TrackCourseCourseRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
