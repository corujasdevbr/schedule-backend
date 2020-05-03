using AutoMapper;
using CorujasDev.Schedulive.Application.DTOs;
using CorujasDev.Schedulive.Application.Interfaces;
using CorujasDev.Schedulive.Core.Data;
using CorujasDev.Schedulive.Domain.Entities;
using CorujasDev.Schedulive.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorujasDev.Schedulive.Application.Service
{
    public class LiveService : ILiveService
    {
        private readonly ILiveRepository _liveRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LiveService(ILiveRepository liveRepository, ICategoryRepository categoryRepository, IUnitOfWork uow, IMapper mapper)
        {
            _liveRepository = liveRepository;
            _categoryRepository = categoryRepository;
            _uow = uow;
            _mapper = mapper;
        }


        public LiveDTO Add(LiveDTO live)
        {
            //TODO: Verify live title exists

            _liveRepository.Add(_mapper.Map<LiveDomain>(live));
            _uow.Commit();

            var liveReturn = GetById(live.Id);

            return _mapper.Map<LiveDTO>(liveReturn);

        }

        public LiveDTO Update(LiveDTO live, Guid id)
        {
            //TODO: Verify live title exists

            _liveRepository.Update(_mapper.Map<LiveDomain>(live));
            _uow.Commit();

            var liveReturn = GetById(live.Id);

            return _mapper.Map<LiveDTO>(liveReturn);
        }

        public List<LiveDTO> GetAll()
        {
            var list = _liveRepository.GetAll();
            return _mapper.Map<List<LiveDTO>>(list.OrderByDescending(x => x.DateTime));
        }

        public List<LiveDTO> GetByCategory(Guid categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);

            if (category == null)
                throw new Exception("Category not found");

            var lives = _liveRepository.FindBy(x => x.CategoryId == categoryId);

            if (lives == null)
                throw new Exception("Live not found");

            return _mapper.Map<List<LiveDTO>>(lives);
        }

        public LiveDTO GetById(Guid id)
        {
            var categoryTemp = _liveRepository.GetById(id);

            if (categoryTemp == null)
                throw new Exception("Live not found");

            return _mapper.Map<LiveDTO>(categoryTemp);
        }

        public List<LiveDTO> GetByTitle(string title)
        {
            var lives = _liveRepository.FindBy(x => x.Title.Contains(title));

            if (lives == null)
                throw new Exception("Live not found");

            return _mapper.Map<List<LiveDTO>>(lives);
        }
    }
}
