﻿using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);
        }

        public List<Category> TGetAll()
        {
           return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
          return _categoryDal.GetById(id);
        }

        public int TGetCategoryCount()
        {
            return _categoryDal.GetCategoryCount();
        }

        public void TInsert(Category entity)
        {
             _categoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
           _categoryDal.Update(entity);
        }
    }
}
