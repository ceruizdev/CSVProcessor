using AutoMapper;
using CSVApplication.Core.Interfaces;
using CSVApplication.Core.Models;
using CSVApplication.Entities;

namespace CSVApplication.Business.Services
{
    public class UserService : IUser
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> repository,
                           IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public UserModel Get(UserLoginModel login)
        {
            var user = _repository.GetByExpression(user => user.UserName.Equals(login.UserName) 
                    && user.Password == login.Password);
            return _mapper.Map<UserModel>(user);
        }

        public UserModel Login(UserLoginModel login)
        {
            UserModel user = new UserModel();
            if (!string.IsNullOrEmpty(login.UserName) && !string.IsNullOrEmpty(login.Password)) {
                user = Get(login);
            }
            return user;
        }
    }
}
