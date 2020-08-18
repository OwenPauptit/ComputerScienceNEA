using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NEA.Areas.Identity.Data;
using NEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Pages
{
    public class DI_BasePageModel : PageModel
    {
        protected NEAContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<NEAUser> UserManager { get; }

        public DI_BasePageModel(
            NEAContext context,
            IAuthorizationService authorizationService,
            UserManager<NEAUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
}
