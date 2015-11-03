using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fall2015.Models;

namespace Fall2015.Repositories
{
    public interface ICompetenciesHeadersRepository
    {
        IQueryable<CompetencyHeader> All { get; }

        IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties);

        CompetencyHeader Find(int id);
        void InsertOrUpdate(CompetencyHeader competency);
        void Delete(int id);
        void Save();
    }

    public class CompetenciesHeadersRepository : ICompetenciesHeadersRepository
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public IQueryable<CompetencyHeader> All
        {
            get { return dbContext.CompetencyHeaders; }
        }

        public IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = dbContext.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CompetencyHeader Find(int id)
        {
            CompetencyHeader competencyHeader = dbContext.CompetencyHeaders.Find(id);
            return competencyHeader;
        }

        public void InsertOrUpdate(CompetencyHeader competencyHeader)
        {
            if (competencyHeader.CompetencyHeaderId == 0) //new
            {
                dbContext.CompetencyHeaders.Add(competencyHeader);
                Save();
            }
            else //edit
            {
                dbContext.Entry(competencyHeader).State = EntityState.Modified;
                Save();
            }
        }

        public void Delete(int id)
        {
            CompetencyHeader competencyHeader = dbContext.CompetencyHeaders.Find(id);
            dbContext.Entry(competencyHeader).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}