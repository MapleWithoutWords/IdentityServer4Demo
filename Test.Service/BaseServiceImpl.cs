using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entity;
using Test.Entity.Entities;

namespace Test.Service
{
    public abstract class BaseServiceImpl<TEntity> where TEntity : BaseEntity
    {
        public DbContext Db { get; set; }
        public BaseServiceImpl()
        {
            this.Db = new TestDbContext();
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            Db.Set<TEntity>().Update(entity);
            await Db.SaveChangesAsync();
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(IEnumerable<TEntity> entity)
        {
            Db.Set<TEntity>().UpdateRange(entity);
            await Db.SaveChangesAsync();
        }
        /// <summary>
        /// 软删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task MarkDelete(string id)
        {
            var entity = await Db.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await Db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 批量软删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task MarkDelete(IEnumerable<string> ids)
        {
            await Db.Set<TEntity>().Where(e => ids.Any(x => x == e.Id)).ForEachAsync(e =>
            {
                e.IsDeleted = false;
            });
            await Db.SaveChangesAsync();
        }


        /// <summary>
        /// 物理删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Delete(string id)
        {
            var entity = await Db.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                Db.Set<TEntity>().Remove(entity);
                await Db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 物理删除一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task Delete(TEntity entity)
        {
            var res = await Db.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == entity.Id);
            if (res != null)
            {
                Db.Set<TEntity>().Remove(res);
                await Db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task AddNewRang(IEnumerable<TEntity> entities)
        {
            await Db.Set<TEntity>().AddRangeAsync(entities);
            await Db.SaveChangesAsync();
        }
        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await Db.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<string> AddNew(TEntity entity)
        {
            await Db.Set<TEntity>().AddAsync(entity);
            await Db.SaveChangesAsync();
            return entity.Id;
        }
        /// <summary>
        /// 获取所有正常的数据。isdeleted=false
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetNoramlAll()
        {
            return await Db.Set<TEntity>().Where(e => e.IsDeleted == false).AsNoTracking().ToListAsync();
        }
        /// <summary>
        /// 获取所有软删除的数据
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetFailAll()
        {
            return await Db.Set<TEntity>().Where(e => e.IsDeleted == true).AsNoTracking().ToListAsync();
        }
    }
}
