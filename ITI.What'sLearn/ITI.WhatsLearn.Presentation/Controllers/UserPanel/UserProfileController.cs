using BroadCaster.Helpers;
using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Presentation.Filters;
using ITI.WhatsLearn.Services;
using ITI.WhatsLearn.ViewModel;
using ITI.WhatsLearnServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    [AUTHORIZE(Roles = "User")]
    public class UserProfileController : ApiController
    {
        private readonly UserService userService;
        private readonly UserTrackService userTrackService;
        private readonly FinishedCourseService finishedCourseService;
        private readonly TrackService trackService;
        private readonly CourseService courseService;
        private readonly SkillService skillService;

        public UserProfileController(
            CourseService _courseService,
            
            UserService _UserService,
            UserTrackService _userTrackService, 
            TrackService _trackService,
            FinishedCourseService _finishedCourseService,
            SkillService _skillService
            )
        { 
            userService = _UserService;
            userTrackService = _userTrackService;
            trackService = _trackService;
            courseService = _courseService;
            finishedCourseService = _finishedCourseService;
            skillService = _skillService;
        }


        [HttpGet]
        public ResultViewModel<UserProfileViewModel> GetProfile()
        {

            ResultViewModel<UserProfileViewModel> result
                   = new ResultViewModel<UserProfileViewModel>();

            string Token = Request.Headers.Authorization?
                    .Parameter;

            Dictionary<string, string>
                            cliams = SecurityHelper.Validate(Token);
            string ID = cliams.FirstOrDefault(i => i.Key == "ID").Value;
            try
            {
                var user = userService.GetByID(int.Parse(ID));
                result.Successed = true;
                result.Data = user.ToUserProfileViewModel();
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }


            return result;
        }

        [HttpGet]
        public ResultViewModel<UserProfileEditViewModel> GetEditProfile()
        {

            ResultViewModel<UserProfileEditViewModel> result
                   = new ResultViewModel<UserProfileEditViewModel>();

            string Token = Request.Headers.Authorization?
                    .Parameter;

            Dictionary<string, string>
                            cliams = SecurityHelper.Validate(Token);
            string ID = cliams.FirstOrDefault(i => i.Key == "ID").Value;
            try
            {
                var user = userService.GetByID(int.Parse(ID));
                result.Successed = true;
                result.Data = user.ToEditableViewModel().ToUserProfileEditViewModel();
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }


            return result;
        }

        [HttpPost]
        public ResultViewModel<UserProfileEditViewModel> UpdateProfile(UserProfileEditViewModel User)
        {
            ResultViewModel<UserProfileEditViewModel> result
                = new ResultViewModel<UserProfileEditViewModel>();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "In Valid Model State";
                }
                else
                {
                    UserEditViewModel selectedEmp
                        = userService.Update(User.ToUserEditViewModel());

                    result.Successed = true;
                    result.Data = selectedEmp.ToUserProfileEditViewModel();
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Semething Went Wrong";
            }
            return result;
        }

        //[HttpGet]
        //public ResultViewModel<UserTrackEditViewModel> UnEnroll(int TrackID)
        //{

        //    ResultViewModel<UserTrackEditViewModel> result = new ResultViewModel<UserTrackEditViewModel>();
        //    try
        //    {
        //        string Token = Request.Headers.Authorization?
        //               .Parameter;
        //        Dictionary<string, string>
        //                        cliams = SecurityHelper.Validate(Token);
        //        int UserID = int.Parse(cliams.First(i => i.Key == "ID").Value);

        //        userTrackService.RemoveUserTrack(TrackID, UserID);
        //        result.Successed = true;
        //    }
        //    catch (Exception e)
        //    {
        //        result.Successed = false;
        //        result.Message = "Error";
        //    }
        //    return result;
        //}
        [HttpGet]
        public ResultViewModel<FinishedCourseEditViewModel> FinishCourse(int CourseID, int TrackID)
        {
            ResultViewModel<FinishedCourseEditViewModel> result = new ResultViewModel<FinishedCourseEditViewModel>();
            try
            {
                string Token = Request.Headers.Authorization?
                          .Parameter;
                Dictionary<string, string>
                                cliams = SecurityHelper.Validate(Token);
                int UserID = int.Parse(cliams.First(i => i.Key == "ID").Value);
                UserTrack T = userTrackService.Get(UserID, TrackID);
                if (T != null)
                {
                    int UserTrackID = T.ID;
                    //Check If  User Finshed Previous Courses
                    var FinedCourses = finishedCourseService.Get(i => i.UserTrackID == UserTrackID).Select(i => i.course).ToList();//html
                    var TrackCourses = T.Track.Courses.Select(i => i.Course).ToList();//html css js
                    var lastFinshedCourse = FinedCourses.LastOrDefault();//html
                    var Course = courseService.GetByID(CourseID);//js
                                        
                if (TrackCourses.IndexOf(Course) == TrackCourses.IndexOf(lastFinshedCourse) + 1)
                    {
                        FinishedCourseEditViewModel F = finishedCourseService.Add(new FinishedCourseEditViewModel()
                        {
                            ID = 0,
                            CourseID = CourseID,
                            TrackID = TrackID,
                            UserID = UserID,
                            UserTrackID = UserTrackID
                        });
                        result.Data = F;
                        result.Successed = true;
                    }
                    else
                    {
                        result.Successed = false;
                        result.Message = "User Not Finshed Prequest Courses";
                    }
                }
        }
            catch (Exception e)
            {
                result.Successed = false;
                result.Message = "Error";
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
        [HttpGet]
        public ResultViewModel<CourseViewModel> GetByID(int id)
        {
            ResultViewModel<CourseViewModel> result
                = new ResultViewModel<CourseViewModel>();
            try
            {
                var course = courseService.GetByID(id);
                result.Successed = true;
                result.Data = course.ToViewModel();
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }
            return result;
        }



    }
}

