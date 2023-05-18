using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IUserService
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        List<User> ListAll();

    }
}
