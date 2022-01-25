using Stepik_ASP_Core_MVC_course.Models;
using System.Collections.Generic;

namespace Stepik_ASP_Core_MVC_course
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
        void ChangePassword(string userName, string newPassword);
    }
}
