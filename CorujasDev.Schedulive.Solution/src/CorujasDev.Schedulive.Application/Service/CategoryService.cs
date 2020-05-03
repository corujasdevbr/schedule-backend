using AutoMapper;
using CorujasDev.Schedulive.Application.DTOs;
using CorujasDev.Schedulive.Application.Interfaces;
using CorujasDev.Schedulive.Core.Data;
using CorujasDev.Schedulive.Domain.Entities;
using CorujasDev.Schedulive.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace CorujasDev.Schedulive.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork uow, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _uow = uow;
            _mapper = mapper;

        }


        public CategoryDTO Add(CategoryDTO category)
        {
            var categoryTemp = _categoryRepository.GetByName(_mapper.Map<CategoryDomain>(category).Name);

            if (categoryTemp != null)
                throw new Exception("Category registred");

            _categoryRepository.Add(_mapper.Map<CategoryDomain>(category));
            _uow.Commit();

            var categoryReturn = _categoryRepository.GetById(category.Id);

            return _mapper.Map<CategoryDTO>(categoryReturn);
        }

        public CategoryDTO Update(CategoryDTO category, Guid id)
        {
            var categoryTemp = _categoryRepository.GetById(_mapper.Map<CategoryDomain>(category).Id);

            if (categoryTemp == null)
                throw new Exception("User not found");

            _categoryRepository.Update(_mapper.Map<CategoryDomain>(category));
            _uow.Commit();

            return category;
        }

        public List<CategoryDTO> GetAll()
        {
            var list = _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDTO>>(list);
        }

        public CategoryDTO GetById(Guid id)
        {
            var categoryTemp = _categoryRepository.GetById(id);

            if (categoryTemp == null)
                throw new Exception("Category not found");

            return _mapper.Map<CategoryDTO>(categoryTemp);
        }

        public CategoryDTO GetByName(string name)
        {
            var categoryTemp = _categoryRepository.GetByName(name);

            if (categoryTemp == null)
                throw new Exception("Category not found");

            return _mapper.Map<CategoryDTO>(categoryTemp);
        }
    }
}
