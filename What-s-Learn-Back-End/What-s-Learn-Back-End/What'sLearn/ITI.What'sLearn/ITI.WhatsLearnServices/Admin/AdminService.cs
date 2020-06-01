﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearnServices
{
    public class AdminService
    {
        UnitOfWork unitOfWork;
        Generic<Admin> AdminRepo;
        public AdminService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            AdminRepo = unitOfWork.AdminRepo;
        }
        public AdminEditViewModel Add(AdminEditViewModel P)
        {
            Admin PP = AdminRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public AdminEditViewModel Update(AdminEditViewModel P)
        {
            Admin PP = AdminRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public Admin GetByID(int id)
        {
            return AdminRepo.GetByID(id);
        }

        public bool ChangeStatus(int id)
        {
           
            Admin admin = GetByID(id);
            if (admin != null)
            {
                admin.IsActive = !admin.IsActive;
                unitOfWork.Commit();
                return true;
            }
            return false;

           
        }
        public IEnumerable<AdminViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                AdminRepo.GetAll();
            query = query.OrderBy(i=>i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public AdminViewModel Get(string Email, string Password)
        {
            var query =
                //AdminRepo.Get
                //    (i => i.Email == Email && i.Password == Password);
                AdminRepo.GetAll().Where(i => i.Email == Email && i.Password == Password)?.FirstOrDefault();

            return query?.ToViewModel();
        }

        public IEnumerable<AdminViewModel> SearchByName(string Name, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                AdminRepo.Get
                    (i => i.Name == Name);
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }


        public void Remove(int id)
        {
            AdminRepo.Remove(AdminRepo.GetByID(id));
            unitOfWork.Commit();
        }
    }
}