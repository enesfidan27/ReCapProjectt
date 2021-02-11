using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakala,veri kaynağıyla ilişkilendir
                addedEntity.State = EntityState.Added; // o aslında eklenecek bir nesne
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity); //referansı yakala,veri kaynağıyla ilişkilendir
                deletedEntity.State = EntityState.Deleted; // o aslında silinecek bir nesne
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null 
                    ? context.Set<Brand>().ToList() 
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity); //referansı yakala,veri kaynağıyla ilişkilendir
                updatedEntity.State = EntityState.Modified; // o aslında güncellenecek  bir nesne
                context.SaveChanges();
            }
        }
    }
}
