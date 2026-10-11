namespace ShopManagementSystem.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}