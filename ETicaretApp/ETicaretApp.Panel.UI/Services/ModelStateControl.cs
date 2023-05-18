using CrmUygulamasi.UI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ETicaretApp.Panel.UI.Services
{
    public class ModelStateControl
    {
        public static void KontrolEt(INotificationService notificationService, ModelStateDictionary ModelState)
        {
            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count > 0)
                    notificationService.Notification(NotifyType.Error, item.Value.Errors[0].ErrorMessage);
            }
        }
    }
}
