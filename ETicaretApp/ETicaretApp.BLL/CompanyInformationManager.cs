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
    public class CompanyInformationManager : ICompanyInformationService
    {
        ICompanyInformationDal _companyInformationDal;
        public CompanyInformationManager(ICompanyInformationDal companyInformationDal)
        {
            _companyInformationDal = companyInformationDal;
        }

        public void Create(CompanyInformation companyInformation)
        {
            _companyInformationDal.Create(companyInformation);
        }

        public void Delete(CompanyInformation companyInformation)
        {
            _companyInformationDal.Delete(companyInformation);
        }

        public CompanyInformation GetById(int id)
        {
          return _companyInformationDal.GetById(id);
        }

        public List<CompanyInformation> ListAll()
        {
           return _companyInformationDal.ListAll();
        }

        public IQueryable<CompanyInformation> Query()
        {
            return _companyInformationDal.Query();
        }

        public void Update(CompanyInformation companyInformation)
        {
            _companyInformationDal.Update(companyInformation);
        }
    }
}
