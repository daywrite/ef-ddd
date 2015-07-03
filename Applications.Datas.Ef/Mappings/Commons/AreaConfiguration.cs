using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Domains.Commons.Models;
using OBear.Datas.Ef;

namespace Applications.Datas.Ef.Mappings.Commons
{
    public class AreaConfiguration : EntityConfigurationBase<Area, Guid>
    {
        public AreaConfiguration()
        {
            ToTable("Area");
            HasKey(c => c.Id);

            Property(c => c.Code).IsRequired().HasColumnType("Varchar").HasMaxLength(50);
            Property(c => c.Text).IsRequired().HasColumnType("Varchar").HasMaxLength(50);
            Property(c => c.PinYin).IsRequired().HasColumnType("Varchar").HasMaxLength(100);
            Property(c => c.FullPinYin).IsRequired().HasColumnType("Varchar").HasMaxLength(500);

            Property(c => c.IsDeleted).IsRequired().HasColumnType("bit");
            Property(c => c.CreatedTime).IsRequired().HasColumnType("DateTime");
        }
    }
}
