using ITI.WhatsLearn.Entities;
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
    public class CourseService
    {
        UnitOfWork unitOfWork;
        Generic<Course> CourseRepo;
        Generic<CourseDocument> CourseDocumentRepo;
        Generic<CourseVedio> CourseVedioRepo;

        Generic<CourseLink> CourseLinkRepo;
        public CourseService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CourseRepo = unitOfWork.CourseRepo;
            CourseDocumentRepo = unitOfWork.CourseDocumentRepo;
            CourseVedioRepo = unitOfWork.CourseVedioRepo;
            CourseLinkRepo = unitOfWork.CourseLinkRepo;

        }


        public CourseEditViewModel Add(CourseEditViewModel course)
        {
            Course c = CourseRepo.Add(course.ToModel());
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseEditViewModel Update(CourseEditViewModel course)
        {
            Course c = CourseRepo.Update(course.ToModel());

            foreach (CourseDocument doc in c.CourseDocuments)
            {

                CourseDocumentRepo.Update(doc);

            }
            foreach (CourseLink doc in c.CourseLinks)
            {

                CourseLinkRepo.Update(doc);

            }
            foreach (CourseVedio doc in c.CourseVedios)
            {

                CourseVedioRepo.Update(doc);

            }
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseViewModel GetByID(int id)
        {
            return CourseRepo.GetByID(id)?.ToViewModel();
        }
        public IEnumerable<CourseViewModel> GetAll(int pageIndex, int pageSize = 20)
        {
            var query =
                CourseRepo.GetAll();
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseViewModel> Get(Expression<Func<Course, bool>> filter)
        {
            var query =
                CourseRepo.Get(filter);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public void Remove(int id)
        {
            CourseRepo.Remove(CourseRepo.GetByID(id));
            unitOfWork.Commit();

        }
        public IEnumerable<CourseViewModel> SeachByID(int ID)
        {
            var query =
                CourseRepo.Get(i => i.ID == ID);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseViewModel> SearchByName(string Name, int pageIndex, int pageSize = 20)
        {
            var query =
                CourseRepo.Get(i => i.Name.Contains(Name));
            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());


        }

        public IEnumerable<CourseViewModel> SearchByParentName(string Parent, int pageIndex, int pageSize = 20)
        {
            var query = CourseRepo.Get(i => i.Tracks.Select(x => x.Track.Name).Contains(Parent));

            query = query.OrderBy(i => i.ID).Skip(pageIndex * pageSize).Take(pageSize);

            return query.ToList().Select(i => i.ToViewModel());


        }

        public int Count()
        {
            return CourseRepo.Count();
        }
        public IEnumerable<CourseViewModel> SortBYNameAsc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                 CourseRepo.GetAll();
            count = query.Count();
            query = query.OrderBy(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<CourseViewModel> SortBYNameDesc(out int count, int pageIndex, int pageSize = 20)
        {
            var query =
                 CourseRepo.GetAll();
            count = query.Count();
            query = query.OrderByDescending(i => i.Name).Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());
        }

    }
}
