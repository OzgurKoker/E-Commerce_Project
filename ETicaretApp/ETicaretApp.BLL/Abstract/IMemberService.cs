using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IMemberService
    {
        void Create(Member member);
        void Update(Member member);
        void Delete(Member member);
        Member GetById(int id);
        Member GetByGuid(Guid id);
        List<Member> ListAll();
        IQueryable<Member> Query();
    }
}
