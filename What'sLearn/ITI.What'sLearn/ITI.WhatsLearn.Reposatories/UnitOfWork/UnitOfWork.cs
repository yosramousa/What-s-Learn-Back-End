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
        public EntitiesContext Context { get; set; }
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
    }
}
