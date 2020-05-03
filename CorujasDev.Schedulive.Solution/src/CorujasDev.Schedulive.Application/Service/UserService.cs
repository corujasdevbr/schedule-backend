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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork uow, IMapper mapper)
        {
            _userRepository = userRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public UserDTO Add(UserDTO user)
        {
            var userTemp = _userRepository.GetByEmail(_mapper.Map<UserDomain>(user).Email);

            if (userTemp != null)
                throw new Exception("User registred");

            _userRepository.Add(_mapper.Map<UserDomain>(user));
            _uow.Commit();

            return user;
        }

        public UserDTO Update(UserDTO user, Guid id)
        {
            var userTemp = _userRepository.GetById(_mapper.Map<UserDomain>(user).Id);

            if (userTemp == null)
                throw new Exception("User not found");

            _userRepository.Update(_mapper.Map<UserDomain>(user));
            _uow.Commit();

            return user;
        }

        public List<UserDTO> GetAll()
        {
            var list = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(list);
        }

        public UserDTO GetById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserByEmailAndPassword(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
                throw new Exception("Email invalid");

            if (user.Password != password)
                throw new Exception("Password invalid");

            var userDTO = _mapper.Map<UserDTO>(user);
            
            return userDTO;
        }

        public UserDTO ForgoutPassword(Guid id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                throw new Exception("User Not Found");

            //Generic Random 
            user.UpdatePassword();

            _userRepository.Update(user);
            _uow.Commit();

            //TODO: Enviar Email

            var userDTO = _mapper.Map<UserDTO>(user);
            
            return userDTO;
        }
    }
}
