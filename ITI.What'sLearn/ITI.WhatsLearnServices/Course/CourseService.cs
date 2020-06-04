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
        public CourseEditViewModel Update(CourseEditViewModel P)
        {
            Course c = CourseRepo.Update(P.ToModel());

            List<CourseDocument> NewDoc = c.CourseDocuments.ToList();
            List<CourseLink> NewLinks = c.CourseLinks.ToList();

            List<CourseVedio> NewVedios = c.CourseVedios.ToList();


            foreach (CourseDocument doc in NewDoc)
            {
                if (doc.ID == 0)
                {
                    CourseDocumentRepo.Add(doc);
                }
                else
                    CourseDocumentRepo.Update(doc);

            }

            foreach (CourseLink link in NewLinks)
            {
                if (link.ID == 0)
                    CourseLinkRepo.Add(link);

                else
                    CourseLinkRepo.Update(link);

            }

            foreach (CourseVedio Vedio in NewVedios)
            {
                if (Vedio.ID == 0)
                    CourseVedioRepo.Add(Vedio);
                else

                    CourseVedioRepo.Update(Vedio);

            }

            var Docs = CourseDocumentRepo.GetAll().Where(i => i.CourseID == c.ID);
            foreach (var doc in Docs)
            {
                if (!NewDoc.Contains(doc))
                {
                    CourseDocumentRepo.Remove(doc);

                }
            }



            var Links = CourseLinkRepo.GetAll().Where(i => i.CourseID == c.ID);
            foreach (var Link in Links)
            {
                if (!c.CourseLinks.Contains(Link))
                {
                    CourseLinkRepo.Remove(Link);

                }
            }
            var Vedios = CourseVedioRepo.GetAll().Where(i => i.CourseID == c.ID);
            foreach (var vedio in Vedios)
            {
                if (!c.CourseVedios.Contains(vedio))
                {
                    CourseVedioRepo.Remove(vedio);

                }
            }
            unitOfWork.Commit();
            return c.ToEditableViewModel();
        }
        public CourseViewModel GetByID(int id)
        {
            Course m = CourseRepo.GetByID(id);
            m.CourseDocuments = Documents(m);

            m.CourseLinks = Links(m);

            m.CourseVedios = Vedios(m);
            return m.ToViewModel();

        }
        public IEnumerable<CourseViewModel> GetAll(out int count, int SortBy, int pageIndex, int pageSize = 20)
        {
            var query =
                CourseRepo.GetAll();
            count = query.Count();
            switch (SortBy)
            {

                case 1:
                case 5:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;

                default:
                    query = query.OrderBy(i => i.ID);

                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
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
        public IEnumerable<CourseViewModel> SearchByName(out int count, int SortBy, string Name, int pageIndex, int pageSize = 20)
        {
            var query =
                CourseRepo.Get(i => i.Name.Contains(Name));
            count = query.Count();

            switch (SortBy)
            {

                case 1:
                case 5:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;

                default:
                    query = query.OrderBy(i => i.ID);

                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return query.ToList().Select(i => i.ToViewModel());


        }

        public IEnumerable<CourseViewModel> SearchByParentName(out int count, int SortBy, string Parent, int pageIndex, int pageSize = 20)
        {
            var query = CourseRepo.Get(i => i.Tracks.Select(x => x.Track.Name).Contains(Parent));
            count = query.Count();

            switch (SortBy)
            {

                case 1:
                case 5:
                    query = query.OrderByDescending(i => i.ID);
                    break;
                case 2:
                    query = query.OrderBy(i => i.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(i => i.Name);
                    break;

                default:
                    query = query.OrderBy(i => i.ID);

                    break;
            }
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
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
        public List<CourseDocument> Documents(Course m)
        {
            return m.CourseDocuments.Where(d => d.IsDeleted == false).ToList();

        }
        public List<CourseVedio> Vedios(Course m)
        {
            return m.CourseVedios.Where(i => i.IsDeleted == false).ToList();

        }
        public List<CourseLink> Links(Course m)
        {
            return m.CourseLinks.Where(i => i.IsDeleted == false).ToList();


        }
    }
}
