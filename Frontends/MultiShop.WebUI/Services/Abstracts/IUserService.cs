using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Abstracts;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfo();
}
