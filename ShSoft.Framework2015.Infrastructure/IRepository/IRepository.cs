﻿using System;
using System.Collections.Generic;
using ShSoft.Framework2015.Infrastructure.IEntity;

namespace ShSoft.Framework2015.Infrastructure.IRepository
{
    /// <summary>
    /// 仓储层基接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRepository<T> : IDisposable where T : PlainEntity
    {
        #region # 根据Id获取唯一实体对象（查看时用） —— T SingleOrDefault(Guid id)
        /// <summary>
        /// 根据Id获取唯一实体对象（查看时用），
        /// 无该对象时返回null
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>单个实体对象</returns>
        /// <exception cref="ArgumentNullException">id为空</exception>
        T SingleOrDefault(Guid id);
        #endregion

        #region # 根据Id获取唯一子类对象（查看时用） —— TSub SingleOrDefault<TSub>(Guid id)
        /// <summary>
        /// 根据Id获取唯一子类对象（查看时用），
        /// 无该对象时返回null
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>唯一子类对象</returns>
        /// <exception cref="ArgumentNullException">id为空</exception>
        TSub SingleOrDefault<TSub>(Guid id) where TSub : T;
        #endregion

        #region # 根据编号获取唯一实体对象（查看时用） —— T SingleOrDefault(string no)
        /// <summary>
        /// 根据编号获取唯一实体对象（查看时用），
        /// 无该对象时返回null
        /// </summary>
        /// <param name="no">编号</param>
        /// <returns>唯一实体对象</returns>
        /// <exception cref="ArgumentNullException">编号为空</exception>
        T SingleOrDefault(string no);
        #endregion

        #region # 根据编号获取唯一子类对象（查看时用） —— TSub SingleOrDefault<TSub>(string no)
        /// <summary>
        /// 根据编号获取唯一子类对象（查看时用），
        /// 无该对象时返回null
        /// </summary>
        /// <param name="no">编号</param>
        /// <returns>唯一子类对象</returns>
        /// <exception cref="ArgumentNullException">编号为空</exception>
        TSub SingleOrDefault<TSub>(string no) where TSub : T;
        #endregion

        #region # 根据Id获取唯一实体对象（查看时用） —— T Single(Guid id)
        /// <summary>
        /// 根据Id获取唯一实体对象（查看时用），
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>单个实体对象</returns>
        /// <exception cref="ArgumentNullException">id为空</exception>
        /// <exception cref="NullReferenceException">无该对象</exception>
        T Single(Guid id);
        #endregion

        #region # 根据Id获取唯一子类对象（查看时用） —— TSub Single<TSub>(Guid id)
        /// <summary>
        /// 根据Id获取唯一子类对象（查看时用），
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>单个子类对象</returns>
        /// <exception cref="ArgumentNullException">id为空</exception>
        /// <exception cref="NullReferenceException">无该对象</exception>
        TSub Single<TSub>(Guid id) where TSub : T;
        #endregion

        #region # 根据编号获取唯一实体对象（查看时用） —— T Single(string no)
        /// <summary>
        /// 根据编号获取唯一实体对象（查看时用），
        /// </summary>
        /// <param name="no">编号</param>
        /// <returns>单个实体对象</returns>
        /// <exception cref="ArgumentNullException">编号为空</exception>
        /// <exception cref="NullReferenceException">无该对象</exception>
        T Single(string no);
        #endregion

        #region # 根据编号获取唯一子类对象（查看时用） —— TSub Single<TSub>(string no)
        /// <summary>
        /// 根据编号获取唯一子类对象（查看时用），
        /// </summary>
        /// <param name="no">编号</param>
        /// <returns>单个子类对象</returns>
        /// <exception cref="ArgumentNullException">编号为空</exception>
        /// <exception cref="NullReferenceException">无该对象</exception>
        TSub Single<TSub>(string no) where TSub : T;
        #endregion

        #region # 根据名称获取唯一实体对象（查看时用） —— T SingleByName(string name)
        /// <summary>
        /// 根据名称获取唯一实体对象（查看时用），
        /// 无该对象时返回null
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>单个实体对象</returns>
        /// <exception cref="ArgumentNullException">名称为空</exception>
        T SingleByName(string name);
        #endregion

        #region # 获取默认或第一个实体对象 —— T FirstOrDefault()
        /// <summary>
        /// 获取默认或第一个实体对象，
        /// 无该对象时返回null
        /// </summary>
        T FirstOrDefault();
        #endregion

        #region # 获取默认或第一个子类对象 —— TSub FirstOrDefault<TSub>()
        /// <summary>
        /// 获取默认或第一个子类对象，
        /// 无该对象时返回null
        /// </summary>
        TSub FirstOrDefault<TSub>() where TSub : T;
        #endregion

        #region # 获取实体对象集合 —— IEnumerable<T> FindAll()
        /// <summary>
        /// 获取实体对象集合
        /// </summary>
        /// <returns>实体对象集合</returns>
        IEnumerable<T> FindAll();
        #endregion

        #region # 获取给定类型子类对象集合 —— IEnumerable<TSub> FindAll<TSub>()
        /// <summary>
        /// 获取给定类型子类对象集合
        /// </summary>
        /// <typeparam name="TSub">子类类型</typeparam>
        /// <returns>子类对象集合</returns>
        IEnumerable<TSub> FindAll<TSub>() where TSub : T;
        #endregion

        #region # 根据关键字获取实体对象集合 —— IEnumerable<T> Find(string keywords)
        /// <summary>
        /// 根据关键字获取实体对象集合
        /// </summary>
        /// <returns>实体对象集合</returns>
        IEnumerable<T> Find(string keywords);
        #endregion

        #region # 根据Id集获取实体对象集合 —— IEnumerable<T> Find(IEnumerable<Guid> ids)
        /// <summary>
        /// 根据Id集获取实体对象集合
        /// </summary>
        /// <returns>实体对象集合</returns>
        IEnumerable<T> Find(IEnumerable<Guid> ids);
        #endregion

        #region # 根据编号集获取实体对象集合 —— IEnumerable<T> Find(IEnumerable<string> nos)
        /// <summary>
        /// 根据编号集获取实体对象集合
        /// </summary>
        /// <returns>实体对象集合</returns>
        IEnumerable<T> Find(IEnumerable<string> nos);
        #endregion

        #region # 根据关键字获取给定类型子类对象集合 —— IEnumerable<TSub> Find<TSub>(string keywords)
        /// <summary>
        /// 根据关键字获取给定类型子类对象集合
        /// </summary>
        /// <typeparam name="TSub">子类类型</typeparam>
        /// <returns>子类对象集合</returns>
        IEnumerable<TSub> Find<TSub>(string keywords) where TSub : T;
        #endregion

        #region # 根据关键字分页获取实体对象集合 + 输出记录条数与页数
        /// <summary>
        /// 根据关键字获取实体对象集合 + 分页 + 输出记录条数与页数
        /// </summary>
        /// <param name="keywords">关键字</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">记录条数</param>
        /// <param name="pageCount">页数</param>
        /// <returns>实体对象集合</returns>
        /// <exception cref="ArgumentNullException">条件表达式为空</exception>
        /// <exception cref="NotSupportedException">无法将表达式转换SQL语句</exception>
        IEnumerable<T> FindByPage(string keywords, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion

        #region # 根据关键字分页获取子类对象集合 + 输出记录条数与页数
        /// <summary>
        /// 根据关键字分页获取子类对象集合 + 分页 + 输出记录条数与页数
        /// </summary>
        /// <typeparam name="TSub">子类类型</typeparam>
        /// <param name="keywords">关键字</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">记录条数</param>
        /// <param name="pageCount">页数</param>
        /// <returns>实体对象集合</returns>
        /// <exception cref="ArgumentNullException">条件表达式为空</exception>
        /// <exception cref="NotSupportedException">无法将表达式转换SQL语句</exception>
        IEnumerable<TSub> FindByPage<TSub>(string keywords, int pageIndex, int pageSize, out int rowCount, out int pageCount) where TSub : T;
        #endregion

        #region # 获取总记录条数 —— int Count()
        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns>总记录条数</returns>
        int Count();
        #endregion

        #region # 获取子类记录条数 —— int Count<TSub>()
        /// <summary>
        /// 获取子类记录条数
        /// </summary>
        /// <returns>总记录条数</returns>
        int Count<TSub>() where TSub : T;
        #endregion

        #region # 判断是否存在给定Id的实体对象 —— bool Exists(Guid id)
        /// <summary>
        /// 判断是否存在给定Id的实体对象
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>是否存在</returns>
        /// <exception cref="ArgumentNullException">id为空</exception>
        bool Exists(Guid id);
        #endregion

        #region # 判断是否存在给定Id的子类对象 —— bool Exists<TSub>(Guid id)
        /// <summary>
        /// 判断是否存在给定Id的子类对象
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>是否存在</returns>
        /// <exception cref="ArgumentNullException">id为空</exception>
        bool Exists<TSub>(Guid id) where TSub : T;
        #endregion

        #region # 判断是否存在给定编号的实体对象 —— bool Exists(string no)
        /// <summary>
        /// 判断是否存在给定编号的实体对象
        /// </summary>
        /// <param name="no">编号</param>
        /// <returns>是否存在</returns>
        /// <exception cref="ArgumentNullException">编号为空</exception>
        bool Exists(string no);
        #endregion

        #region # 判断是否存在给定编号的子类对象 —— bool Exists<TSub>(string no)
        /// <summary>
        /// 判断是否存在给定编号的子类对象
        /// </summary>
        /// <param name="no">编号</param>
        /// <returns>是否存在</returns>
        /// <exception cref="ArgumentNullException">编号为空</exception>
        bool Exists<TSub>(string no) where TSub : T;
        #endregion

        #region # 判断是否存在给定名称的实体对象 —— bool ExistsName(string name)
        /// <summary>
        /// 判断是否存在给定名称的实体对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>是否已存在</returns>
        bool ExistsName(string name);
        #endregion

        #region # 判断是否存在给定名称的子类对象 —— bool ExistsName<TSub>(string name)
        /// <summary>
        /// 判断是否存在给定名称的子类对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>是否已存在</returns>
        bool ExistsName<TSub>(string name) where TSub : T;
        #endregion

        #region # 执行SQL查询 —— IEnumerable<T> ExecuteSqlQuery(string sql, params object[] parameters)
        /// <summary>
        /// 执行SQL查询
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体对象数组</returns>
        /// <exception cref="ArgumentNullException">SQL语句为空</exception>
        IEnumerable<T> ExecuteSqlQuery(string sql, params object[] parameters);
        #endregion
    }
}