using Fall2015.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Hosting;

namespace Fall2015.Repositories
{
    public interface IStudentsRepository
    {
        IQueryable<Student> All { get; }

        IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties);

        Student Find(int id);
        void InsertOrUpdate(Student student, HttpPostedFileBase image);
        void Delete(int id);
        void Save();
    }

    public class StudentsRepository : IStudentsRepository
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public IQueryable<Student> All
        {
            get { return dbContext.Students; }
        }

        public IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = dbContext.Students;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Student Find(int id)
        {
            Student student = dbContext.Students.Find(id);
            return student;
        }

        public void InsertOrUpdate(Student student, HttpPostedFileBase image)
        {
            if (student.StudentId == 0) //new
            {
                dbContext.Students.Add(student);
                student.SaveImage(image, HostingEnvironment.MapPath("~"), "/UserUploads/");
                Save();
            }
            else //edit
            {
                dbContext.Entry(student).State = EntityState.Modified;
                student.SaveImage(image, HostingEnvironment.MapPath("~"), "/UserUploads/");
                Save();
            }
        }

        public void Delete(int id)
        {
            Student student = dbContext.Students.Find(id);
            dbContext.Entry(student).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}