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
    public class PropertyValueManager : IPropertyValueService
    {
        IPropertyValueDal _propertyValueDal;
        public PropertyValueManager(IPropertyValueDal propertyValueDal)
        {
            _propertyValueDal = propertyValueDal;
        }

        public void Create(PropertyValue propertyValue)
        {
            _propertyValueDal.Create(propertyValue);
        }

        public void Delete(PropertyValue propertyValue)
        {
            _propertyValueDal.Delete(propertyValue);
        }

        public PropertyValue GetById(int id)
        {
          return _propertyValueDal.GetById(id);
        }

        public List<PropertyValue> ListAll()
        {
           return _propertyValueDal.ListAll();
        }

        public IQueryable<PropertyValue> Query()
        {
            return _propertyValueDal.Query();
        }

        public void Update(PropertyValue propertyValue)
        {
            _propertyValueDal.Update(propertyValue);
        }
    }
}
