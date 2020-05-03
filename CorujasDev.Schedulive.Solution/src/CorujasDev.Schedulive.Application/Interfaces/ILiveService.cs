using CorujasDev.Schedulive.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CorujasDev.Schedulive.Application.Interfaces
{
    public interface ILiveService
    {
        #region Read
        List<LiveDTO> GetAll();
        LiveDTO GetById(Guid id);
        List<LiveDTO> GetByTitle(string title);
        List<LiveDTO> GetByCategory(Guid categoryId);
        #endregion

        #region Write
        LiveDTO Add(LiveDTO live);
        LiveDTO Update(LiveDTO live, Guid id);
        #endregion
    }
}
