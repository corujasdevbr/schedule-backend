using CorujasDev.Schedulive.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorujasDev.Schedulive.Application.Interfaces
{
    public interface IUserService
    {
        #region Read
        List<UserDTO> GetAll();
        UserDTO GetById(Guid id);
        UserDTO ForgoutPassword(Guid id);
        UserDTO GetUserByEmailAndPassword(string email, string password);
        #endregion

        #region Write
        UserDTO Add(UserDTO user);
        UserDTO Update(UserDTO user, Guid id);
        #endregion
    }
}
