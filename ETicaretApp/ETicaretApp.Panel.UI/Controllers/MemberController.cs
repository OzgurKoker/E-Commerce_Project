using ETicaretApp.BLL;
using ETicaretApp.DAL.EntityFramework;
using ETicaretApp.Entities;
using ETicaretApp.Panel.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApp.Panel.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        MemberManager memberManager = new MemberManager(new EfMemberRepository());
        private readonly INotificationService notificationService;

        public MemberController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public IActionResult Index()
        {
            List<Member> memberList=memberManager.ListAll();
            return View(memberList);
        }

        //[HttpPost]
        //public IActionResult UpdateMemberState(Guid memberId)
        //{
        //    var member = memberManager.GetByGuid(memberId);
        //    member.State = !member.State;
        //    memberManager.Update(member);
        //    notificationService.Notification(NotifyType.Success, $"{member.Email} Mail adresli kullanıcı güncellendi.");

        //    return Ok("Üye durumu güncellendi..");
        //}
    }
}
