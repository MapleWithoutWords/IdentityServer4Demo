﻿using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Settings
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = context.Subject.Claims.ToList();
            context.IssuedClaims = claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
