using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyon.ViewComponents.Default
{
    public class _LogoPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
