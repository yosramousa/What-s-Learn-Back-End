using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.What_sLearn.Entities
{
    public class BaseModelConfiguration : EntityTypeConfiguration<BaseModel>
    {
        public BaseModelConfiguration() {
            //HasKey(i => i.ID);
            //Property(i => i.ID).HasDatabaseGeneratedOption
            //    (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
