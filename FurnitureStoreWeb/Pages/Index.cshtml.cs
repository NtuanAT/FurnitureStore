﻿using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IAccountService _accountService;

		[BindProperty]
		public Account account { get; set; }

		public IndexModel(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public void OnGet()
		{

		}

		public IActionResult OnPost()
		{
			var result = _accountService.Login(account.Username, account.Password);
			if (result != null)
			{
				return RedirectToPage("Privacy");
			}
			else
			{
				return RedirectToPage("Error");
			}
		}
	}
}