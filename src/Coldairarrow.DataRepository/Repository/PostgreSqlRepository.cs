﻿using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Coldairarrow.DataRepository
{
    public class PostgreSqlRepository : DbRepository, IRepository
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PostgreSqlRepository()
            : base(null, DatabaseType.PostgreSql, null)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conStr">数据库连接名</param>
        public PostgreSqlRepository(string conStr)
            : base(conStr, DatabaseType.PostgreSql, null)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conStr">数据库连接名</param>
        /// <param name="entityNamespace">实体命名空间</param>
        public PostgreSqlRepository(string conStr, string entityNamespace)
            : base(conStr, DatabaseType.PostgreSql, entityNamespace)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库连接上下文</param>
        public PostgreSqlRepository(DbContext dbContext)
            : base(dbContext, DatabaseType.PostgreSql, null)
        {
        }

        #endregion

        #region 插入数据

        /// <summary>
        /// 使用Bulk批量插入数据（适合大数据量，速度非常快）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entities">数据</param>
        public override void BulkInsert<T>(List<T> entities)
        {
            throw new Exception("抱歉！暂不支持PostgreSql！");
        }

        public override void Delete_Sql<T>(Expression<Func<T, bool>> condition)
        {
            Delete(condition);
        }

        #endregion
    }
}
