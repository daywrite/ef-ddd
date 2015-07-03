﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Datas.Ef.Migrations
{
    public class MigrationsConfiguration : DbMigrationsConfiguration<ApplicationUnitOfWork>
    {
        static MigrationsConfiguration()
        {
            SeedActions = new List<ISeedAction>();
        }

        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            //部署的时候还是改成false
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// 获取 数据迁移初始化种子数据操作信息集合，各个模块可以添加自己的数据初始化操作
        /// </summary>
        public static ICollection<ISeedAction> SeedActions { get; private set; }

        protected override void Seed(ApplicationUnitOfWork context)
        {
            IEnumerable<ISeedAction> seedActions = SeedActions.OrderBy(m => m.Order);
            foreach (ISeedAction seedAction in seedActions)
            {
                seedAction.Action(context);
            }
        }
    }
}

