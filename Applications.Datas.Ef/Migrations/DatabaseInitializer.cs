using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Datas.Ef.Migrations
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public class DatabaseInitializer
    {
        /// <summary>
        /// 设置数据库初始化，策略为自动迁移到最新版本
        /// </summary>
        public static void Initialize()
        {
            ApplicationUnitOfWork context = new ApplicationUnitOfWork();
            IDatabaseInitializer<ApplicationUnitOfWork> initializer;
            if (!context.Database.Exists())
            {
                initializer = new CreateDatabaseIfNotExistsWithSeed();
            }
            else
            {
                initializer = new MigrateDatabaseToLatestVersion<ApplicationUnitOfWork, MigrationsConfiguration>();
            }
            Database.SetInitializer(initializer);

            ////增加字段可以立马展示出来--有好--有坏
            ////增加的整数不能为null，就得等增加的时候才能加上，看情况
            ////目前先加上
            context.Database.Initialize(false);
        }
    }
}
