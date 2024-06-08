using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _HeaderPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
