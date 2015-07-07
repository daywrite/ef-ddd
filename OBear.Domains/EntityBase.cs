﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBear.Domains
{
    /// <summary>
    /// 可持久化到数据库的数据模型基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        protected EntityBase(TKey id)
        {
            IsDeleted = false;
            CreatedTime = DateTime.Now;

            Id = id;
        }

        #region 属性

        /// <summary>
        /// 获取或设置 实体唯一标识，主键
        /// </summary>
        [Required]
        public TKey Id { get; private set; }

        /// <summary>
        /// 获取或设置 是否删除，逻辑上的删除，非物品删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        #endregion

        #region Init(初始化)

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            if (Id.Equals(default(TKey)))
                Id = CreateId();
        }

        /// <summary>
        /// 创建标识
        /// </summary>
        protected virtual TKey CreateId()
        {
            return Conv.To<TKey>(Guid.NewGuid());
        }

        #endregion
    }
}
