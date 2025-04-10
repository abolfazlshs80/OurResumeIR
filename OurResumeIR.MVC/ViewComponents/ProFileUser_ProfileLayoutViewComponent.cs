
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using OurResumeIR.Infra.Data.Context;

namespace SlideCloud.ViewComponents
{
    public class ProFileUser_ProfileLayoutViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        

        public ProFileUser_ProfileLayoutViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
  
        public async Task<IViewComponentResult> InvokeAsync()
        {
   
            return View("~/Views/Shared/Components/User/Layout/ProFileUser_ProfileLayoutView.cshtml");
        }
        
    }
}
