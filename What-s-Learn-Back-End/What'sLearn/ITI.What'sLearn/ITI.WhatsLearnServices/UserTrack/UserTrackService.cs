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
    public class UserTrackService
    {

        UnitOfWork unitOfWork;
        Generic<UserTrack> UserTrackRepo;
        public UserTrackService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserTrackRepo = unitOfWork.UserTrackRepo;
        }
        public UserTrackEditViewModel Add(UserTrackEditViewModel P)
        {
            UserTrack PP = UserTrackRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserTrackEditViewModel Update(UserTrackEditViewModel P)
        {
            UserTrack PP = UserTrackRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserTrack GetByID(int id)
        {
            return UserTrackRepo.GetByID(id);
        }
        public IEnumerable<UserTrackViewModel> GetAll()
        {
            var query =
                UserTrackRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserTrackViewModel> Get(int id, string TrackName, string username, int pageIndex, int pageSize = 20)
        {
            var query =
                UserTrackRepo.Get
                    (i => i.ID == id || i.Track.Name == TrackName || i.User.Name == username);
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserTrackRepo.Remove(UserTrackRepo.GetByID(id));
            unitOfWork.Commit();
        }

    }
}
