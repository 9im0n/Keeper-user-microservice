﻿using UserMicroservice.Models.Database;

namespace UserMicroservice.Services.Interfaces
{
    public interface IProfileService
    {
        public Profiles GetByUserId(Guid id);
        public Profiles Create(Users user);
        public Profiles Update(Profiles newProfile);
    }
}