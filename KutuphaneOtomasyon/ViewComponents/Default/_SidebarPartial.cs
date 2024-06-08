using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _SidebarPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
