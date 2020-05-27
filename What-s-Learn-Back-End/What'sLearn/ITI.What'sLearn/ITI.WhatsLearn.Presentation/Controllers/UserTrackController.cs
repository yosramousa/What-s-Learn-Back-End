﻿using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation
{
    public class UserTrackController : ApiController
    {
        private readonly UserCertificateService UserCertificateService;
        public UserTrackController(UserCertificateService _UserCertificateService)
        {
            UserCertificateService = _UserCertificateService;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<UserCertificateViewModel>> GetList()
        {
            ResultViewModel<IEnumerable<UserCertificateViewModel>> result
                = new ResultViewModel<IEnumerable<UserCertificateViewModel>>();
            try
            {
                var UserCertificates = UserCertificateService.GetAll();
                result.Successed = true;
                result.Data = UserCertificates;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }


        [HttpPost]
        public ResultViewModel<UserCertificateEditViewModel> Post(UserCertificateEditViewModel UserCertificate)
        {
            ResultViewModel<UserCertificateEditViewModel> result
                = new ResultViewModel<UserCertificateEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserCertificateEditViewModel selectedUserCertificate
                        = UserCertificateService.Add(UserCertificate);

                    result.Successed = true;
                    result.Data = selectedUserCertificate;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }

        [HttpPost]
        public ResultViewModel<UserCertificateEditViewModel> Update(UserCertificateEditViewModel UserCertificate)
        {
            ResultViewModel<UserCertificateEditViewModel> result
                = new ResultViewModel<UserCertificateEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserCertificateEditViewModel selectedEmp
                        = UserCertificateService.Update(UserCertificate);

                    result.Successed = true;
                    result.Data = selectedEmp;
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
        public ResultViewModel<UserCertificateViewModel> GetByID(int id)
        {
            ResultViewModel<UserCertificateViewModel> result
                = new ResultViewModel<UserCertificateViewModel>();
            try
            {
                var UserCertificate = UserCertificateService.GetByID(id)?.ToViewModel();
                result.Successed = true;
                result.Data = UserCertificate;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }

        [HttpGet]
        public string Delete(int id)
        {
            if (UserCertificateService.GetByID(id) != null)
            {
                UserCertificateService.Remove(id);
                return "UserCertificate Deleted Sucessfully";
            }
            else
                return "UserCertificate Not Found !";
        }

    }
}