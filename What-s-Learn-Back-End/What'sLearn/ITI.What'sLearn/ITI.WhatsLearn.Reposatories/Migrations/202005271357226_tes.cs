namespace ITI.WhatsLearn.Reposatories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        Adress = c.String(),
                        Phone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseDocument",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        File = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Discription = c.String(nullable: false, maxLength: 1000),
                        Image = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseLink",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseVedio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vedio = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.TrackCourse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrackID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Track", t => t.TrackID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.TrackID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Discription = c.String(nullable: false, maxLength: 1000),
                        Image = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(nullable: false),
                        SubCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Discription = c.String(nullable: false, maxLength: 1000),
                        Image = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(nullable: false),
                        MainCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainCategory", t => t.MainCategoryID, cascadeDelete: true)
                .Index(t => t.MainCategoryID);
            
            CreateTable(
                "dbo.MainCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Discription = c.String(nullable: false, maxLength: 1000),
                        Image = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MainCategoryDocument",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        File = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        MainCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainCategory", t => t.MainCategoryID, cascadeDelete: true)
                .Index(t => t.MainCategoryID);
            
            CreateTable(
                "dbo.MainCategoryLink",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        MainCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainCategory", t => t.MainCategoryID, cascadeDelete: true)
                .Index(t => t.MainCategoryID);
            
            CreateTable(
                "dbo.MainCategoryVedio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vedio = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        MainCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainCategory", t => t.MainCategoryID, cascadeDelete: true)
                .Index(t => t.MainCategoryID);
            
            CreateTable(
                "dbo.SubCategoryDocument",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        File = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        SubCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.SubCategoryLink",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        SubCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.SubCategoryVedio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vedio = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        SubCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.TrackDocument",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        File = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        TrackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Track", t => t.TrackID, cascadeDelete: true)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.TrackLinks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Description = c.String(),
                        TrackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Track", t => t.TrackID, cascadeDelete: true)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.TrackVedio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vedio = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 250),
                        TrackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Track", t => t.TrackID, cascadeDelete: true)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.UserTrack",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TrackID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsApproveed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.FinishedCourse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        courseID = c.Int(nullable: false),
                        UserTrackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserTrack", t => t.UserTrackID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.courseID, cascadeDelete: true)
                .Index(t => t.courseID)
                .Index(t => t.UserTrackID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Education = c.String(nullable: false, maxLength: 250),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        Adress = c.String(),
                        Phone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserCertificate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserSkill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Skill", t => t.SkillID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Skill = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserSocialLink",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false, maxLength: 250),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 1000),
                        SendTime = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseDocument", "CourseID", "dbo.Course");
            DropForeignKey("dbo.FinishedCourse", "courseID", "dbo.Course");
            DropForeignKey("dbo.TrackCourse", "CourseID", "dbo.Course");
            DropForeignKey("dbo.TrackCourse", "TrackID", "dbo.Track");
            DropForeignKey("dbo.UserTrack", "TrackID", "dbo.Track");
            DropForeignKey("dbo.UserTrack", "UserID", "dbo.User");
            DropForeignKey("dbo.UserSocialLink", "UserID", "dbo.User");
            DropForeignKey("dbo.UserSkill", "UserID", "dbo.User");
            DropForeignKey("dbo.UserSkill", "SkillID", "dbo.Skill");
            DropForeignKey("dbo.UserCertificate", "UserID", "dbo.User");
            DropForeignKey("dbo.FinishedCourse", "UserTrackID", "dbo.UserTrack");
            DropForeignKey("dbo.TrackVedio", "TrackID", "dbo.Track");
            DropForeignKey("dbo.TrackLinks", "TrackID", "dbo.Track");
            DropForeignKey("dbo.TrackDocument", "TrackID", "dbo.Track");
            DropForeignKey("dbo.Track", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategoryVedio", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategoryLink", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategoryDocument", "SubCategoryID", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "MainCategoryID", "dbo.MainCategory");
            DropForeignKey("dbo.MainCategoryVedio", "MainCategoryID", "dbo.MainCategory");
            DropForeignKey("dbo.MainCategoryLink", "MainCategoryID", "dbo.MainCategory");
            DropForeignKey("dbo.MainCategoryDocument", "MainCategoryID", "dbo.MainCategory");
            DropForeignKey("dbo.CourseVedio", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseLink", "CourseID", "dbo.Course");
            DropIndex("dbo.UserSocialLink", new[] { "UserID" });
            DropIndex("dbo.UserSkill", new[] { "SkillID" });
            DropIndex("dbo.UserSkill", new[] { "UserID" });
            DropIndex("dbo.UserCertificate", new[] { "UserID" });
            DropIndex("dbo.FinishedCourse", new[] { "UserTrackID" });
            DropIndex("dbo.FinishedCourse", new[] { "courseID" });
            DropIndex("dbo.UserTrack", new[] { "TrackID" });
            DropIndex("dbo.UserTrack", new[] { "UserID" });
            DropIndex("dbo.TrackVedio", new[] { "TrackID" });
            DropIndex("dbo.TrackLinks", new[] { "TrackID" });
            DropIndex("dbo.TrackDocument", new[] { "TrackID" });
            DropIndex("dbo.SubCategoryVedio", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategoryLink", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategoryDocument", new[] { "SubCategoryID" });
            DropIndex("dbo.MainCategoryVedio", new[] { "MainCategoryID" });
            DropIndex("dbo.MainCategoryLink", new[] { "MainCategoryID" });
            DropIndex("dbo.MainCategoryDocument", new[] { "MainCategoryID" });
            DropIndex("dbo.SubCategory", new[] { "MainCategoryID" });
            DropIndex("dbo.Track", new[] { "SubCategoryID" });
            DropIndex("dbo.TrackCourse", new[] { "CourseID" });
            DropIndex("dbo.TrackCourse", new[] { "TrackID" });
            DropIndex("dbo.CourseVedio", new[] { "CourseID" });
            DropIndex("dbo.CourseLink", new[] { "CourseID" });
            DropIndex("dbo.CourseDocument", new[] { "CourseID" });
            DropTable("dbo.Message");
            DropTable("dbo.UserSocialLink");
            DropTable("dbo.Skill");
            DropTable("dbo.UserSkill");
            DropTable("dbo.UserCertificate");
            DropTable("dbo.User");
            DropTable("dbo.FinishedCourse");
            DropTable("dbo.UserTrack");
            DropTable("dbo.TrackVedio");
            DropTable("dbo.TrackLinks");
            DropTable("dbo.TrackDocument");
            DropTable("dbo.SubCategoryVedio");
            DropTable("dbo.SubCategoryLink");
            DropTable("dbo.SubCategoryDocument");
            DropTable("dbo.MainCategoryVedio");
            DropTable("dbo.MainCategoryLink");
            DropTable("dbo.MainCategoryDocument");
            DropTable("dbo.MainCategory");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Track");
            DropTable("dbo.TrackCourse");
            DropTable("dbo.CourseVedio");
            DropTable("dbo.CourseLink");
            DropTable("dbo.Course");
            DropTable("dbo.CourseDocument");
            DropTable("dbo.Admins");
        }
    }
}
