﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
{
    public class UserCertificateService
    {

        UnitOfWork unitOfWork;
        Generic<UserCertificate> UserCertificateRepo;
        public UserCertificateService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserCertificateRepo = unitOfWork.UserCertificateRepo;
        }
        public UserCertificateEditViewModel Add(UserCertificateEditViewModel P)
        {
            UserCertificate PP = UserCertificateRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserCertificateEditViewModel Update(UserCertificateEditViewModel p)
        {
            UserCertificate PP = UserCertificateRepo.Update(p.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public UserCertificate GetByID(int id)
        {
            return UserCertificateRepo.GetByID(id);
        }
        public IEnumerable<UserCertificateViewModel> GetAll(int UserID)
        {
            var query =
                UserCertificateRepo.GetAll().Where(i=>i.UserID == UserID);

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserCertificateViewModel> Get(int id, string skill, string UserCertificatename, int pageIndex, int pageSize = 20)
        {
            var query =
                UserCertificateRepo.Get
                    (i => i.ID == id);
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            UserCertificateRepo.Remove(UserCertificateRepo.GetByID(id));
            //UserCertificate cert= UserCertificateRepo.GetByID(id);
            //cert.IsDeleted = true;
            unitOfWork.Commit();
        }

    }
}
