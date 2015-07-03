using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Domains;

namespace OBear.Datas.Ef
{
    /// <summary>
    /// 数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TKey">动态主键类型</typeparam>
    public abstract class EntityConfigurationBase<TEntity> : EntityTypeConfiguration<TEntity>, IEntityMapper where TEntity : class, IEntity
    {
        /// <summary>
        /// 初始化映射
        /// </summary>
        protected EntityConfigurationBase()
        {
            MapTable();
            MapId();
            MapVersion();
            MapProperties();
            MapAssociations();
        }

        /// <summary>
        /// 映射表
        /// </summary>
        protected abstract void MapTable();

        /// <summary>
        /// 映射标识
        /// </summary>
        protected abstract void MapId();

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        protected virtual void MapVersion() {
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected virtual void MapProperties() {
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected virtual void MapAssociations() {
        }
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}

