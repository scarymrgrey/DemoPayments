using System;
using System.Collections.Generic;
using System.Text;
using Incoding.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Operations.Persistance
{
   public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public class Map : EFClassMap<User>
        {
            public override void OnModel(EntityTypeBuilder<User> entity)
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Login);
                entity.Property(r => r.Password);
                entity.Property(r => r.Role);
            }
        }
    }
}
