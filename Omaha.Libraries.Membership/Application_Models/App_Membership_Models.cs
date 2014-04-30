using Microsoft.AspNet.Identity.EntityFramework;
using Omaha.Libraries.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omaha.Libraries.Membership.Application_Models
{
	public class ApplicationUser : IdentityUser
	{
		public const string CLASS_TITLE = "ApplicationUser";
		public string NickName { get; set; }

		public virtual User_Detail User_Detail_Info { get; set;}
	}

	public class User_Detail
	{
		public const string CLASS_TITLE = "User_Info";
		public int Id { get; set; }
		public string First_Name { get; set; }
		public string Middle_Name { get; set; }
		public string Last_Name { get; set; }

		public virtual Online_Detail Online_Info { get; set; }
	}

	public class Online_Detail
	{
		public const string CLASS_TITLE = "Online_Id";
		[Key]
		public int OI_Id { get; set; }
		public string Facebook_Id { get; set; }
		public string Google_Id { get; set; }
		public string Yahoo_Id { get; set; }

		public virtual ApplicationUser User {get; set;}
	}


	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public AppDbContext() : base(Application_Constants.APPLICATION_CONNECTION_STRING_NAME)
		{
			//Default Constructor
		}

		protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ApplicationUser>().ToTable(Application_Constants.MEMBERSHIP_TABLES_APP_USERS);
			modelBuilder.Entity<IdentityUser>().ToTable(Application_Constants.MEMBERSHIP_TABLES_APP_USERS);
			modelBuilder.Entity<User_Detail>().ToTable(Application_Constants.MEMBERSHIP_TABLES_USER_DETAILS); 
			modelBuilder.Entity<Online_Detail>().ToTable(Application_Constants.MEMBERSHIP_TABLES_ONLINE_DETAILS);
		}

		public DbSet<User_Detail> User_Details { get; set; }

		public DbSet<Online_Detail> Online_Details { get; set; }
	}
}
