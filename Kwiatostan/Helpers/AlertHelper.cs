using Microsoft.AspNetCore.Mvc;

namespace Kwiatostan.Helpers
{
    public static class AlertHelper
    {
        public static void SetAlert(Controller controller, string alertMessage, AlertType alertType)
        {
            controller.TempData["AlertType"] = alertType.ToString();
            controller.TempData["AlertMessage"] = alertMessage;
        }
    }

    public enum AlertType
    {
        success,
        warning,
        error,
        danger,
        info
    }
}
