using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
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
        Generic<Admin> DepartmentRepo;
        public AdminService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            DepartmentRepo = unitOfWork.AdminRepo;
        }
        //public AdmEditViewModel Add(AdmEditViewModel P)
        //{
        //    Admin PP = DepartmentRepo.Add(P.ToModel());
        //    unitOfWork.Commit();
        //    return PP.ToEditableViewModel();
        //}
        //public AdmEditViewModel Update(AdmEditViewModel P)
        //{
        //    Admin PP = DepartmentRepo.Update(P.ToModel());
        //    unitOfWork.Commit();
        //    return PP.ToEditableViewModel();
        //}
        //public AdminViewModel GetByID(int id)
        //{
        //    return DepartmentRepo.GetByID(id)?.ToViewModel();
        //}
        //public IEnumerable<AdminViewModel> Get(int id, string name, string phone, int pageIndex, int pageSize = 20)
        //{
        //    var query =
        //        DepartmentRepo.GetAll();
        //    query = query.Skip(pageIndex * pageSize).Take(pageSize);
        //    return query.ToList().Select(i => i.ToViewModel());
        //}
        public void Remove(int id)
        {
        }
    }
}
