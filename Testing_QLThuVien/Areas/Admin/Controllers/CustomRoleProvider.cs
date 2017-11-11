using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Testing_QLThuVien.Models;
using System.Web.Caching;

namespace Testing_QLThuVien.Areas.Admin.Controllers
{
    public class CustomRoleProvider : RoleProvider
    {
        QLThuVien db = new QLThuVien();

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            NhanVien account = db.NhanViens.Single(x => x.TenNhanVien.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (account != null)
            {
                return new string[] { account.IDChucVu };
            }
            else
            {
                return new string[] { };
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            NhanVien user = db.NhanViens.FirstOrDefault(u => u.TenNhanVien.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            var roles = user.IDChucVu;
            if (user != null)
                return roles.Equals(roles);
            else
                return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}