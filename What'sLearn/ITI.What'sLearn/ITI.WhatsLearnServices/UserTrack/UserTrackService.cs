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
    public class UserTrackCourseService
    {

        UnitOfWork unitOfWork;
        Generic<UserTrackCourse> UserTrackCourseRepo;
        public UserTrackCourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserTrackCourseRepo = unitOfWork.UserTrackCourseRepo;
        }
        public UserTrackCourseEditViewModel Add(UserTrackCourseEditViewModel P)
        {
            UserTrackCourse PP = UserTrackCourseRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserTrackCourseEditViewModel Update(UserTrackCourseEditViewModel P)
        {
            UserTrackCourse PP = UserTrackCourseRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserTrackCourse GetByID(int id)
        {
            return UserTrackCourseRepo.GetByID(id);
        }
        public IEnumerable<UserTrackCourseViewModel> GetAll()
        {
            var query =
                UserTrackCourseRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserTrackCourseViewModel> Get(int id, string TrackCourseName, string username, int pageIndex, int pageSize = 20)
        {
            var query =
                UserTrackCourseRepo.Get
                    (i => i.ID == id || i.TrackCourse.Name == TrackCourseName || i.User.Name == username);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserTrackCourseRepo.Remove(UserTrackCourseRepo.GetByID(id));
            unitOfWork.Commit();
        }

    }
}
