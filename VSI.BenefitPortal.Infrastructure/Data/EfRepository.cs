﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VSI.BenefitPortal.Core.Interfaces;
using VSI.BenefitPortal.Core.SharedKennel;

namespace VSI.BenefitPortal.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BenefitDbContext _dbContext;

        public EfRepository(BenefitDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().SingleOrDefault(item => item.Id == id);
        }

        public List<T> List()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}