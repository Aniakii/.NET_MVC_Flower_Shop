using Microsoft.AspNetCore.Mvc;

namespace Kwiatostan.Helpers
{
    public static class AlertHelper
    {
        public static void SetAlert(Controller controller, string alertMessage, AlertType alertType, int? alertTimeout = null)
        {
            controller.TempData["AlertType"] = alertType.ToString();
            controller.TempData["AlertMessage"] = alertMessage;
            controller.TempData["AlertTimeout"] = alertTimeout;
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
