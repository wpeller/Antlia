using Abp.Notifications;
using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}