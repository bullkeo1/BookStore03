using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook03.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook03.ViewComponents
{
    public class UserNameViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserNameViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == claim.Value);
            return View(userFromDb); // view này nằm trong Views/Shared/Components. UserName như tên Controller, phải tạo thư mục UserName trong đường dẫn trên.
        }
    }
}