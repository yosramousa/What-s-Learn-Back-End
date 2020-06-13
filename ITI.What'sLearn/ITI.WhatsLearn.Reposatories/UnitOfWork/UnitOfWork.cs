using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Reposatories
{
    public class UnitOfWork
    {
        private EntitiesContext context { get; set; }
        public Generic<Admin> AdminRepo { get; set; }
        public Generic<Course> CourseRepo { get; set; }
        public Generic<CourseDocument> CourseDocumentRepo { get; set; }
        public Generic<CourseLink> CourseLinkRepo { get; set; }
        public Generic<CourseVedio> CourseVedioRepo { get; set; }
        public Generic<FinishedCourse> FinishedCourseRepo { get; set; }
        public Generic<MainCategory> MainCategoryRepo { get; set; }
        public Generic<MainCategoryDocument> MainCategoryDocumentRepo { get; set; }
        public Generic<MainCategoryLink> MainCategoryLinkRepo { get; set; }
        public Generic<MainCategoryVedio> MainCategoryVedioRepo { get; set; }
        public Generic<Message> MessageRepo { get; set; }
        public Generic<Skill> SkillRepo { get; set; }
        public Generic<SubCategory> SubCategoryRepo { get; set; }
        public Generic<SubCategoryDocument> SubCategoryDocumentRepo { get; set; }
        public Generic<SubCategoryLink> SubCategoryLinkRepo { get; set; }
        public Generic<SubCategoryVedio> SubCategoryVedioRepo { get; set; }
        public Generic<Track> TrackRepo { get; set; }
        public Generic<TrackCourse> TrackCourseRepo { get; set; }
        public Generic<TrackDocument> TrackDocumentRepo { get; set; }
        public Generic<TrackLink> TrackLinkRepo { get; set; }
        public Generic<TrackVedio> TrackVedioRepo { get; set; }
        public Generic<User> UserRepo { get; set; }
        public Generic<UserCertificate> UserCertificateRepo { get; set; }
        public Generic<UserSkill> UserSkillRepo { get; set; }
        public Generic<UserSocialLink> UserSocialLinkRepo { get; set; }
        public Generic<UserTrack> UserTrackRepo { get; set; }
        public Generic<Configuration> ConfigurationRepo { get; set; }


        public UnitOfWork
            (
             EntitiesContext _context,
             Generic<Admin> adminRepo,
             Generic<Course> courseRepo,
             Generic<CourseDocument> courseDocumentRepo,
             Generic<CourseLink> courseLinkRepo,
             Generic<CourseVedio> courseVedioRepo,
             Generic<FinishedCourse> finishedCourseRepo,
             Generic<MainCategory> mainCategoryRepo,
             Generic<MainCategoryDocument> mainCategoryDocumentRepo,
             Generic<MainCategoryLink> mainCategoryLinkRepo,
             Generic<MainCategoryVedio> mainCategoryVedioRepo,
             Generic<Message> messageRepo,
             Generic<Skill> skillRepo,
             Generic<SubCategory> subCategoryRepo,
             Generic<SubCategoryDocument> subCategoryDocumentRepo,
             Generic<SubCategoryLink> subCategoryLinkRepo,
             Generic<SubCategoryVedio> subCategoryVedioRepo,
             Generic<Track> trackRepo,
             Generic<TrackCourse> trackCourseRepo,
             Generic<TrackDocument> trackDocumentRepo,
             Generic<TrackLink> trackLinkRepo,
             Generic<TrackVedio> trackVedioRepo,
             Generic<User> userRepo,
             Generic<UserCertificate> userCertificateRepo,
             Generic<UserSkill> userSkillRepo,
             Generic<UserSocialLink> userSocialLinkRepo,
             Generic<UserTrack> userTrackRepo,
             Generic<Configuration>  configRepo



        )
        {
            context = _context;
            AdminRepo = adminRepo;
            AdminRepo.Context = context;
            CourseRepo = courseRepo;
            CourseRepo.Context = context;
            CourseDocumentRepo = courseDocumentRepo;
            CourseDocumentRepo.Context = context;
            CourseVedioRepo = courseVedioRepo;
            CourseVedioRepo.Context = context;
            CourseLinkRepo = courseLinkRepo;
            CourseLinkRepo.Context = context;
            FinishedCourseRepo = finishedCourseRepo;
            FinishedCourseRepo.Context = context;
            MainCategoryRepo = mainCategoryRepo;
            MainCategoryRepo.Context = context;
            MainCategoryDocumentRepo = mainCategoryDocumentRepo;
            MainCategoryDocumentRepo.Context = context;
            MainCategoryLinkRepo = mainCategoryLinkRepo;
            MainCategoryLinkRepo.Context = context;
            MainCategoryVedioRepo = mainCategoryVedioRepo;
            MainCategoryVedioRepo.Context = context;
            MessageRepo = messageRepo;
            MessageRepo.Context = context;
            SkillRepo = skillRepo;
            SkillRepo.Context = context;
            SubCategoryRepo = subCategoryRepo;
            SubCategoryRepo.Context = context;
            SubCategoryDocumentRepo = subCategoryDocumentRepo;
            SubCategoryDocumentRepo.Context = context;
            SubCategoryLinkRepo = subCategoryLinkRepo;
            SubCategoryLinkRepo.Context = context;
            SubCategoryVedioRepo = subCategoryVedioRepo;
            SubCategoryVedioRepo.Context = context;
            TrackRepo = trackRepo;
            TrackRepo.Context = context;
            TrackCourseRepo =trackCourseRepo;
            TrackCourseRepo.Context = context;
            TrackDocumentRepo = trackDocumentRepo;
            TrackDocumentRepo.Context = context;
            TrackLinkRepo = trackLinkRepo;
            TrackLinkRepo.Context = context;
            TrackVedioRepo = trackVedioRepo;
            TrackVedioRepo.Context = context;
            UserRepo = userRepo;
            UserRepo.Context = context;
            UserCertificateRepo = userCertificateRepo;
            UserCertificateRepo.Context = context;
            UserSkillRepo = userSkillRepo;
            UserSkillRepo.Context = context;
            UserSocialLinkRepo = userSocialLinkRepo;
            UserSocialLinkRepo.Context = context;
            UserTrackRepo = userTrackRepo;
            UserTrackRepo.Context = context;
            ConfigurationRepo = configRepo;
            ConfigurationRepo.Context = context;



        }
        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
