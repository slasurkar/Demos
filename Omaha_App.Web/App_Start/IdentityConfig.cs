using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Omaha.Libraries;
using Omaha.Libraries.Membership.Application_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Omaha_App.Web.App_Start
{
	public class AppDbInitializer :  CreateDatabaseIfNotExists<AppDbContext>//DropCreateDatabaseAlways<AppDbContext>
	{
		protected override void Seed(AppDbContext context)
		{
			InitializeAppDb(context);
			base.Seed(context);
		}

		private void InitializeAppDb(AppDbContext context)
		{
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			//Create Roles
			CreateRole(roleManager, "Administrators");
			CreateRole(roleManager, "AppGuests");
			CreateRole(roleManager, "AppUsers");

			//Create Users
			var adminUser = new ApplicationUser();
			adminUser.UserName = "AppAdmin";
			adminUser.NickName = "Admin";
			adminUser.User_Detail_Info = new User_Detail() { First_Name = "App", Last_Name = "Admin" };

			var adminUserResult = userManager.Create(adminUser, "AppAdmin1234");

			if(adminUserResult.Succeeded)
			{
				var roleAddResult = userManager.AddToRole(adminUser.Id, "Administrators");
			}
		}

		protected static async System.Threading.Tasks.Task VerifyUserExists(UserManager<ApplicationUser> userManager, string userName, string password)
		{
			ApplicationUser existingUser = await userManager.FindAsync(userName, password);
		}

		private static void CreateRole(RoleManager<IdentityRole> roleManager, string role_Name)
		{
			if (!roleManager.RoleExists(role_Name))
			{
				roleManager.Create(new IdentityRole(role_Name));
			}
		}

	}
}