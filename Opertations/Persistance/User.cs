using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Incoding.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Operations.Persistance
{
    [Table("User")]
   public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public class Map : EFClassMap<User>
        {
            public override void OnModel(EntityTypeBuilder<User> entity)
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Login);
                entity.Property(r => r.Password);
            }
        }
    }
}
