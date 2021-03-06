﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public IEnumerable<UserTrackViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<UserTrackViewModel> GetRequest(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().Where(u => u.IsApproveed == false);
            count = query.Count();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<UserTrackViewModel> GetAll()
        {
            var query =
                UserTrackRepo.GetAll();
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<UserTrackViewModel> GetEnrollRequest(int pageIndex = 0, int pageSize = 5)
        {
            var query =
                UserTrackRepo.GetAll().Where(i => i.IsApproveed == false).OrderByDescending(i => i.ID).Skip(pageIndex * pageSize)
                .Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<UserTrackViewModel> SearchByName(out int count, string Name, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().Where
                    (i => i.IsApproveed == false && i.User.Name.ToLower() == Name.ToLower());
            count = query.Count();

            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserTrackViewModel> SearchByTrackName(out int count, string TrackName, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                UserTrackRepo.GetAll().Where
                    (i => i.IsApproveed == false && i.Track.Name.Contains(TrackName));
            count = query.Count();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Approve(int id)
        {

            UserTrack u = GetByID(id);
            if (u != null)
            {
                u.IsApproveed = true;
                unitOfWork.Commit();
            }

        }
        public void Remove(int id)
        {
            if (UserTrackRepo.GetByID(id) != null)
            {
                UserTrackRepo.Remove(UserTrackRepo.GetByID(id));
                unitOfWork.Commit();
            }
        }
        public int Count()
        {
            return UserTrackRepo.Count();
        }
        public int GetUserTracksCount(int UserID)
        {
            return UserTrackRepo.
                 Get(i => i.IsApproveed
                 && i.UserID == UserID
                 && i.Track.Courses.Count() > i.FinishedCourses.Count())
                 .Count();

        }
        public void RemoveUserTrack(int TrackID, int UserID)
        {
            UserTrack T = Get(UserID, TrackID);
            if (T != null)
            {
                UserTrackRepo.Remove(T);
                unitOfWork.Commit();
            }
        }
        public UserTrack Get(int UserID, int TrackID)
        {
            UserTrack T = UserTrackRepo.
                 Get(i => i.IsApproveed && i.TrackID == TrackID && i.UserID == UserID).FirstOrDefault();


            return T;
        }
        public bool CheckToEnroll(int UserID, int TrackID)
        {
            try
            {
                var user = UserTrackRepo.GetAll().Where(i => i.UserID == UserID && i.TrackID == TrackID).FirstOrDefault();
                if (user == null)
                {
                    return true;


                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public Dictionary<string, int> GetPieChartData()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var userTracks = GetAll().Where(i=>i.IsApproveed==true)
                .GroupBy(n => n.TrackName)
                .Select(n => new
                {
                    trackName = n.Key,
                    Count = n.Count()
                }).OrderBy(n => n.Count).Take(4);

            foreach (var x in userTracks)
            {
                result.Add(x.trackName, x.Count);
            }

            return result;



        }
       
        public UserTrackViewModel GetDeletedEnrollRequest(int UserID,int TrackID)
        {
           return
                UserTrackRepo.GetDeleted()
                .Where(i=>i.IsApproveed==false && i.UserID == UserID && i.TrackID == TrackID).FirstOrDefault()
                .ToViewModel();
        }

    }
}
