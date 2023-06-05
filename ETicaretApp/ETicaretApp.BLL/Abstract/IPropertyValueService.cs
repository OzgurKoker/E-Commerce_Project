using ETicaretApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.BLL.Abstract
{
    public interface IPropertyValueService
    {
        void Create(PropertyValue propertyValue);
        void Update(PropertyValue propertyValue);
        void Delete(PropertyValue propertyValue);
        PropertyValue GetById(int id);
        List<PropertyValue> ListAll();
        IQueryable<PropertyValue> Query();
    }
}
