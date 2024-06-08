using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _HeaderPartialUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
