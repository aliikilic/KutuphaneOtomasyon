using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _ScriptsPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
