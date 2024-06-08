using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _SidebarPartialUser :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
