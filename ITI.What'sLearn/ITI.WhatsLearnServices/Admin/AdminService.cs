using ITI.WhatsLearn.Entities;
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
        public IEnumerable<AdminViewModel> GetAll(out int count ,int SortBy,int pageIndex, int pageSize = 20)
        {
            var query =
                AdminRepo.GetAll();
            count = query.Count();
            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.Email);
                    break;
                case 6:
                    query = query.OrderBy(i => i.IsActive);
                    break;
                case 7:
                    query = query.OrderByDescending(i => i.IsActive);
                    break;
                default:
                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        
        public AdminViewModel Get(string Email, string Password)
        {
            var query =
                //AdminRepo.Get
                //    (i => i.Email == Email && i.Password == Password);
                AdminRepo.GetAll().Where(i => i.Email == Email && i.Password == Password && i.IsActive==true)?.FirstOrDefault();

            return query?.ToViewModel();
        }
        public IEnumerable<AdminViewModel> SearchByName( int SortBy,string Name, out int Length, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                AdminRepo.Get
                    (i => i.Name.Contains(Name));//
          
            Length = query.Count();
            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.Email);
                    break;
                case 6:
                    query = query.OrderBy(i => i.IsActive);
                    break;
                case 7:
                    query = query.OrderByDescending(i => i.IsActive);
                    break;
                default:
                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<AdminViewModel> SearchByEmail(out int count, int SortBy, string Email, int pageIndex = 0, int pageSize = 20)
        {
            var query =
                AdminRepo.Get
                    (i => i.Email.Contains(Email));
            count = query.Count();
            switch (SortBy)
            {
                case 0:
                    query = query.OrderBy(i => i.ID);
                    break;
                case 1:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;
                case 4:
                    query = query.OrderBy(i => i.Email).Skip(pageIndex * pageSize).Take(pageSize);
                    break;

                case 5:
                    query = query.OrderBy(i => i.Email);
                    break;
                case 6:
                    query = query.OrderBy(i => i.IsActive);
                    break;
                case 7:
                    query = query.OrderByDescending(i => i.IsActive);
                    break;
                default:
                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            AdminRepo.Remove(AdminRepo.GetByID(id));
            unitOfWork.Commit();
        }
        public int GetAdminCount()
        {
            return AdminRepo.Count();
        }


    }
}
