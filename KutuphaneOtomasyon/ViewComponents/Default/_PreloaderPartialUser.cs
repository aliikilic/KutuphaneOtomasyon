using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _PreloaderPartialUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
