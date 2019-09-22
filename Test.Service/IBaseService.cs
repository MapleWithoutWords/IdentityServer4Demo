using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Entity.Entities;

namespace Test.Service
{
    public interface IBaseService<TEntity> : ISignFac
                      where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(string id);
        Task UpdateAsync(TEntity entity);
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(IEnumerable<TEntity> entity);
        /// <summary>
        /// 软删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task MarkDelete(string id);
        /// <summary>
        /// 批量软删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task MarkDelete(IEnumerable<string> ids);


        /// <summary>
        /// 物理删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(string id);
        /// <summary>
        /// 物理删除一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(TEntity entity);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddNewRang(IEnumerable<TEntity> entities);

        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AddNew(TEntity entity);
        /// <summary>
        /// 获取所有正常的数据。isdeleted=false
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetNoramlAll();
        /// <summary>
        /// 获取所有软删除的数据
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetFailAll();
    }
}
