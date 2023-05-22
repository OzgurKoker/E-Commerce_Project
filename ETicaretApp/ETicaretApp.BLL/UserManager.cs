using ETicaretApp.BLL.Abstract;
using ETicaretApp.DAL.Abstract;
using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Create(User user)
        {
            _userDal.Create(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int id)
        {
          return _userDal.GetById(id);
        }

        public List<User> ListAll()
        {
           return _userDal.ListAll();
        }

        public IQueryable<User> Query()
        {
            return _userDal.Query();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
