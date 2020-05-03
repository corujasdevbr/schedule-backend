using CorujasDev.Schedulive.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorujasDev.Schedulive.Application.Interfaces
{
    public interface ICategoryService
    {
        #region Read
        List<CategoryDTO> GetAll();
        CategoryDTO GetById(Guid id);
        CategoryDTO GetByName(string name);
        #endregion

        #region Write
        CategoryDTO Add(CategoryDTO category);
        CategoryDTO Update(CategoryDTO category, Guid id);
        #endregion
    }
}
