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
    public class CourseService
    {
        
        UnitOfWork unitOfWork;
        Generic<Course> CourseRepo;
        public CourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CourseRepo = unitOfWork.CourseRepo;
        }
        public CourseEditViewModel Add(CourseEditViewModel P)
        {
            Course PP = CourseRepo.Add(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public CourseEditViewModel Update(CourseEditViewModel P)
        {
            Course PP = CourseRepo.Update(P.ToModel());
            unitOfWork.Commit();
            return PP.ToEditableViewModel();
        }
        public Course GetByID(int id)
        {
            return CourseRepo.GetByID(id);
        }
        public IEnumerable<CourseViewModel> GetAll(){
            var query =
                CourseRepo.GetAll();
               
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseViewModel> Get(int id, string name, int pageIndex, int pageSize = 20)
        {
            var query =
                CourseRepo.Get
                    (i => i.ID == id || i.Name == name );
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CourseRepo.Remove(CourseRepo.GetByID(id));
            unitOfWork.Commit();
        }
    
    }
}
