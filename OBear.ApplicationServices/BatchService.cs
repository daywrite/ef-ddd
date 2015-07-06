using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Datas;
using OBear.Domains;
using OBear.Domains.EntityRepositories;

namespace OBear.ApplicationServices
{
    public abstract class BatchService<TEntity, TDto, TQuery, TKey> : ServiceBase<TEntity, TDto, TQuery, TKey>, IBatchService<TDto, TQuery>
        where TEntity : class, IAggregateRoot<TKey>, new()
        where TDto : IDto, new()
        //where TQuery : IPager
    {
        /// <summary>
        /// 初始化批操作服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected BatchService(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
            : base(unitOfWork, repository)
        {
            _addList = new List<TEntity>();
            _updateList = new List<TEntity>();
            _deleteList = new List<TEntity>();
        }

        /// <summary>
        /// 新增列表
        /// </summary>
        protected List<TEntity> _addList;
        /// <summary>
        /// 修改列表
        /// </summary>
        protected List<TEntity> _updateList;
        /// <summary>
        /// 删除列表
        /// </summary>
        protected List<TEntity> _deleteList;

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        public List<TDto> Save(List<TDto> addList, List<TDto> updateList, List<TDto> deleteList)
        {
            //UnitOfWork.Start();
            //SaveBefore(addList, updateList, deleteList);
            //AddList();
            //UpdateList();
            //DeleteList();
            //Save();
            //SaveAfter();
            //WriteLog("保存集合成功");
            //return GetResult();
            return null;
        }
    }
}
