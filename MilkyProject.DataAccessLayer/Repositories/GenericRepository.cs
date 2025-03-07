﻿using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly MilkyContext _context;

        public GenericRepository(MilkyContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();

        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
           _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
