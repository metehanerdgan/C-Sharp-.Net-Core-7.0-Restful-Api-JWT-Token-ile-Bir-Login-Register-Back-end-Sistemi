using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NodebookApp.DbContext
{
	public class AuthenticationDbContext : IdentityDbContext
	{
		public AuthenticationDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}

