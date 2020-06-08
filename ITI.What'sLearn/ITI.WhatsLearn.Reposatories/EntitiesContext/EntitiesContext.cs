using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Reposatories
{
    public class EntitiesContext :DbContext
    {
        public EntitiesContext() :base("name=WhatsLearn")
        {}

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseDocument> CourseDocuments { get; set; }
        public virtual DbSet<CourseLink> CourseLinks { get; set; }
        public virtual DbSet<CourseVedio> CourseVedios { get; set; }
        public virtual DbSet<FinishedCourse> FinishedCourses { get; set; }
        public virtual DbSet<MainCategory> MainCategories { get; set; }
        public virtual DbSet<MainCategoryDocument> MainCategoryDocuments { get; set; }
        public virtual DbSet<MainCategoryLink> MainCategoryLinks { get; set; }
        public virtual DbSet<MainCategoryVedio> MainCategoryVedios { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<SubCategoryDocument> SubCategoryDocument { get; set; }
        public virtual DbSet<SubCategoryLink> SubCategoryLinks { get; set; }
        public virtual DbSet<SubCategoryVedio> SubCategoryVedios { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackDocument> TrackDocuments { get; set; }
        public virtual DbSet<TrackLink> TrackLinks { get; set; }
        public virtual DbSet<TrackVedio> TrackVedios { get; set; }
        public virtual DbSet<TrackCourse> TrackCourses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCertificate> UserCertificates { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<UserSocialLink> UserSocialLink { get; set; }
        public virtual DbSet<UserTrack> UserTrack { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add
                (new AdminConfiguration());
            modelBuilder.Configurations.Add
               (new CourseConfiguration());
            modelBuilder.Configurations.Add
               (new CourseDocumentConfiguration());
            modelBuilder.Configurations.Add
               (new CourseLinkConfiguration());
            modelBuilder.Configurations.Add
                (new CourseVedioConfiguration());
            modelBuilder.Configurations.Add
                (new FinishedCourseConfigurations());
            modelBuilder.Configurations.Add
                (new MainCategoyConfiguration());
            modelBuilder.Configurations.Add
                (new MainCategoryDocumentConfiguration());
            modelBuilder.Configurations.Add
                (new MainCategoryLinkConfiguration());
            modelBuilder.Configurations.Add
                (new MainCategoryVedioConfiguration());
            modelBuilder.Configurations.Add
                (new MessageConfiguration());
            modelBuilder.Configurations.Add
                (new SkillConfiguration());
            modelBuilder.Configurations.Add
                (new SubCategoryConfiguration());
            modelBuilder.Configurations.Add
                (new SubCategoryDocumentConfiguration());
            modelBuilder.Configurations.Add
                (new SubCategoryLinkConfiguration());
            modelBuilder.Configurations.Add
                (new SubCategoryVedioConfiguration());
            modelBuilder.Configurations.Add
                (new TrackConfiguration());
            modelBuilder.Configurations.Add
                (new TrackCourseConfigurations());
            
            modelBuilder.Configurations.Add
                (new TrackDocumentConfiguration());
            modelBuilder.Configurations.Add
                (new TrackedioConfiguration());
            modelBuilder.Configurations.Add
                (new UserConfiguration());
            modelBuilder.Configurations.Add
                (new UserCertificateConfiguration());
            modelBuilder.Configurations.Add
                (new UserSkillConfiguration());
            modelBuilder.Configurations.Add
                (new UserSocialLinkConfiguration());
            modelBuilder.Configurations.Add
                (new UserTrackConfigurations());
        }
    }
}
