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
        public AdminViewModel GetByID(int id)
        {
            return AdminRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<AdminViewModel> GetAll( int pageIndex, int pageSize = 20)
        {
            var query =
                AdminRepo.GetAll();
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            AdminRepo.Remove(AdminRepo.GetByID(id));
            unitOfWork.Commit();
        }
    }
}
