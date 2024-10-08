﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        private UserProfile()
        {
            
        }
        public Guid Id { get; private set; }
        public string IdentityId { get; private set; }
        public BasicInfo BasicInfo { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }

        #region Factory Methods
        public static UserProfile CreateUserProfile(string identityId, BasicInfo basicInfo)
        {
            return new()
            {
                IdentityId = identityId,
                BasicInfo = basicInfo,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
        }
        #endregion
        #region Public Methods
        public void UpdateBasicInfo(BasicInfo newInfo)
        {
            BasicInfo = newInfo;
            LastModified = DateTime.UtcNow;
        }
        #endregion
    }
}
