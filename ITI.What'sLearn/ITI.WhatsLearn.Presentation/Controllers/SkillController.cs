﻿using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ITI.WhatsLearn.Presentation.Filters;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "User,Admin")]

    public class SkillController : ApiController
    {

        private readonly SkillService skillService;
        public SkillController(SkillService _skillService)
        {
            skillService = _skillService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<SkillViewModel>> GetList(int pageIndex, int pageSize = 20)
        {
            ResultViewModel<IEnumerable<SkillViewModel>> result
               = new ResultViewModel<IEnumerable<SkillViewModel>>();
            int count = 0;
            try
            {
                var Skills = skillService.GetAll(out count, 0, pageIndex, pageSize);
                result.Successed = true;
                result.Data = Skills;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]
        public ResultViewModel<SkillEditViewModel> Post(SkillEditViewModel Skill)
        {
            ResultViewModel<SkillEditViewModel> result
                = new ResultViewModel<SkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SkillEditViewModel selectedSkill
                        = skillService.Add(Skill);

                    result.Successed = true;
                    result.Data = selectedSkill;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<SkillViewModel> GetByID(int id)
        {
            ResultViewModel<SkillViewModel> result
                = new ResultViewModel<SkillViewModel>();
            try
            {
                var skill = skillService.GetByID(id);
                result.Successed = true;
                result.Data = skill;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }
        [HttpPost]

        [HttpGet]
        public ResultViewModel<SkillEditViewModel> Update(SkillEditViewModel Skill)
        {
            ResultViewModel<SkillEditViewModel> result
              = new ResultViewModel<SkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    SkillEditViewModel selectedSkill
                        = skillService.Update(Skill);
                    result.Successed = true;
                    result.Data = selectedSkill;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModel<SkillEditViewModel> Delete(int id)
        {
            ResultViewModel<SkillEditViewModel> result
             = new ResultViewModel<SkillEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    skillService.Remove(id);
                    result.Successed = true;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;

        }
        [HttpGet]
        public ResultViewModel<IEnumerable<SkillViewModel>> GetAllSkills()
        {
            ResultViewModel<IEnumerable<SkillViewModel>> result =
                new ResultViewModel<IEnumerable<SkillViewModel>>();

            try
            {
                result.Data = skillService.GetAll();
                result.Message = "Skills gotten succesfuly";
                result.Successed = true;
            }
            catch
            {

                result.Message = "Something went wrong!!";
                result.Successed = false;
            }
            return result;
        }
    }
}
