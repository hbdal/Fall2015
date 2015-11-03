using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Fall2015.Models;

namespace Fall2015.Repositories
{
    public interface ICompetenciesRepository
    {
        IQueryable<Competency> All { get; }

        IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties);

        Competency Find(int id);
        void InsertOrUpdate(Competency competency);
        void Delete(int id);
        void Save();
    }

    public class CompetenciesRepository : ICompetenciesRepository
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public IQueryable<Competency> All
        {
            get { return dbContext.Competencies; }
        }

        public IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties)
        {
            IQueryable<Competency> query = dbContext.Competencies;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Competency Find(int id)
        {
            Competency competency = dbContext.Competencies.Find(id);
            return competency;
        }

        public void InsertOrUpdate(Competency competency)
        {
            if (competency.CompetencyId == 0) //new
            {
                dbContext.Competencies.Add(competency);
                Save();
            }
            else //edit
            {
                dbContext.Entry(competency).State = EntityState.Modified;
                Save();
            }
        }

        public void Delete(int id)
        {
            Competency competency = dbContext.Competencies.Find(id);
            dbContext.Entry(competency).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
