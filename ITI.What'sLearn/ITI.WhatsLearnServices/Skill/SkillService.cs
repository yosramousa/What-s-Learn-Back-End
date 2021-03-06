﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
{
    public class SkillService
    {
        UnitOfWork unitOfWork;
        Generic<Skill> SkillRepo;
        public SkillService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SkillRepo = unitOfWork.SkillRepo;
        }
        public SkillEditViewModel Add(SkillEditViewModel Skill)
        {
            Skill c = SkillRepo.Add(Skill.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public SkillEditViewModel Update(SkillEditViewModel Skill)
        {
            Skill c = SkillRepo.Update(Skill.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public SkillViewModel GetByID(int id)
        {
            return SkillRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<SkillViewModel> GetAll(out int count ,int SortBy, int pageIndex, int pageSize = 20)
        {
            var query =
                SkillRepo.GetAll();
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
                    query = query.OrderBy(i => i.skill);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.skill);
                    break;
               
                default:
                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

        public IEnumerable<SkillViewModel> GetAll()
        {
            var query =
                SkillRepo.GetAll();

            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SkillViewModel> Get(Expression<Func<Skill, bool>> filter)
        {
            var query =
                SkillRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            SkillRepo.Remove(SkillRepo.GetByID(id));
            unitOfWork.Commit();

        }
    }
}
