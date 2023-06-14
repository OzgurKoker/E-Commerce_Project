using ETicaretApp.DAL.Abstract;
using ETicaretApp.DAL.Repositories;
using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.DAL.EntityFramework
{
    public class EfMemberRepository : GenericRepository<Member>, IMemberDal
    {
        ETicaretAppContext context = new ETicaretAppContext();

        public Member GetByGuid(Guid id)
        {
            return context.Set<Member>().Find(id);
        }
    }
}
