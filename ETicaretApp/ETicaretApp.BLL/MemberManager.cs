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
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public void Create(Member member)
        {
            _memberDal.Create(member);
        }

        public void Delete(Member member)
        {
            _memberDal.Delete(member);
        }

        public Member GetById(int id)
        {
          return _memberDal.GetById(id);
        }

        public List<Member> ListAll()
        {
           return _memberDal.ListAll();
        }

        public IQueryable<Member> Query()
        {
            return _memberDal.Query();
        }

        public void Update(Member member)
        {
            _memberDal.Update(member);
        }
    }
}
