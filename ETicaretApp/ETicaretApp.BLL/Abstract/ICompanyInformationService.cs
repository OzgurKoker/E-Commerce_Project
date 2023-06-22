using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface ICompanyInformationService
    {
        void Create(CompanyInformation companyInformation);
        void Update(CompanyInformation companyInformation);
        void Delete(CompanyInformation companyInformation);
        CompanyInformation GetById(int id);
        List<CompanyInformation> ListAll();
        IQueryable<CompanyInformation> Query();
    }
}
