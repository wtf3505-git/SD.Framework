﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShSoft.Framework2015.Common.PoweredByLee
{
    /// <summary>
    /// 集合的扩展方法
    /// </summary>
    public static class CollectionExtension
    {
        #region # 遍历ForEach扩展方法 —— static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        /// <summary>
        /// 遍历ForEach扩展方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="enumerable">实现IEnumerable接口的类型</param>
        /// <param name="action">委托</param>
        /// <exception cref="ArgumentNullException">源集合对象为空、操作表达式为空</exception>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            #region # 验证参数

            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable", @"源集合对象不可为空！");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action", @"操作表达式不可为空！");
            }

            #endregion

            foreach (T item in enumerable)
            {
                action(item);
            }
        }
        #endregion

        #region # 判断两个集合中的元素是否相等扩展方法 —— static bool EqualsTo<T>(this IEnumerable<T>...
        /// <summary>
        /// 判断两个集合中的元素是否相等扩展方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="sourceList">源集合</param>
        /// <param name="targetList">目标集合</param>
        /// <returns>是否相等</returns>
        /// <exception cref="ArgumentNullException">源集合对象为空、目标集合对象为空</exception>
        public static bool EqualsTo<T>(this IEnumerable<T> sourceList, IEnumerable<T> targetList)
        {
            #region # 验证参数

            if (sourceList == null)
            {
                throw new ArgumentNullException("sourceList", @"源集合对象不可为空！");
            }

            if (targetList == null)
            {
                throw new ArgumentNullException("targetList", @"目标集合对象不可为空！");
            }

            #endregion

            #region 01.长度对比

            //长度不相等
            if (sourceList.Count() != targetList.Count())
            {
                return false;
            }

            //长度都为0
            if (!sourceList.Any() && !targetList.Any())
            {
                return true;
            }

            #endregion

            #region 02.浅度对比

            //元素对比
            if (!sourceList.Except(targetList).Any() && !targetList.Except(sourceList).Any())
            {
                return true;
            }

            #endregion

            #region 03.深度对比

            //将集合序列化为字符串
            string sourceListStr = sourceList.ToJson().Trim();
            string targetListStr = targetList.ToJson().Trim();

            //先对比字符串是否相同
            if (sourceListStr == targetListStr)
            {
                return true;
            }

            //再对比字符是否相同
            if (!sourceListStr.ToCharArray().Except(targetListStr.ToCharArray()).Any() &&
                !targetListStr.ToCharArray().Except(sourceListStr.ToCharArray()).Any())
            {
                return true;
            }

            #endregion

            return false;
        }
        #endregion

        #region # 判断集合是否为空或null —— static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        /// <summary>
        /// 判断集合是否为空或null
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="enumerable">集合对象</param>
        /// <returns>是否为空或null</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            return !enumerable.Any();
        }
        #endregion

        #region # 根据一个字段去重 —— static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> enumerable...
        /// <summary>
        /// 根据一个字段去重
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="TKey">去重的参照字段</typeparam>
        /// <param name="enumerable">源集合</param>
        /// <param name="keySelector">字段选择委托</param>
        /// <returns>去重后的集合</returns>
        /// <exception cref="ArgumentNullException">源集合对象为空、参照字段表达式为空</exception>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            #region # 验证参数

            if (enumerable == null)
            {
                throw new ArgumentNullException("sourceList", @"源集合对象不可为空！");
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector", @"参照字段表达式不可为空！");
            }

            #endregion

            HashSet<TKey> seenKeys = new HashSet<TKey>();
            return enumerable.Where(item => seenKeys.Add(keySelector(item)));
        }
        #endregion

        #region # AddRange扩展方法 —— static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        /// <summary>
        /// ICollection的AddRange扩展方法
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="enumerable">元素集合</param>
        /// <exception cref="ArgumentNullException">源集合对象为空、添加的集合项为空</exception>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            #region # 验证参数

            if (collection == null)
            {
                throw new ArgumentNullException("collection", @"源集合对象不可为空！");
            }

            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable", @"要添加的集合项不可为空！");
            }

            #endregion

            enumerable.ForEach(collection.Add);
        }
        #endregion

        #region # 分页扩展方法 —— static IEnumerable<T> FindByPage<T, TKeyOne, TKeyTwo>...
        /// <summary>
        /// 分页扩展方法
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <typeparam name="TKeyOne">排序键1</typeparam>
        /// <typeparam name="TKeyTwo">排序键2</typeparam>
        /// <param name="enumerable">集合对象</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelectorOne">排序键选择器1</param>
        /// <param name="keySelectorTwo">排序键选择器2</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">总记录条数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>对象集合</returns>
        public static IEnumerable<T> FindByPage<T, TKeyOne, TKeyTwo>(this IEnumerable<T> enumerable, Func<T, bool> predicate, Func<T, TKeyOne> keySelectorOne, Func<T, TKeyTwo> keySelectorTwo, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            #region # 验证参数

            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable", @"源集合对象不可为空！");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate", @"查询条件对象不可为空！");
            }
            if (keySelectorOne == null || keySelectorTwo == null)
            {
                throw new ArgumentNullException("keySelector", @"参照字段表达式不可为空！");
            }
            if (pageIndex.IsZeroOrMinus())
            {
                throw new ArgumentOutOfRangeException("pageIndex", @"页码不可为0或负数！");
            }
            if (pageSize.IsZeroOrMinus())
            {
                throw new ArgumentOutOfRangeException("pageSize", @"页容量不可为0或负数！");
            }

            #endregion

            IEnumerable<T> list = enumerable.Where(predicate);
            rowCount = list.Count();
            pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
            return list.OrderByDescending(keySelectorOne).ThenByDescending(keySelectorTwo).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        #endregion

        #region # 分页扩展方法 —— static IQueryable<T> FindByPage<T, TKeyOne, TKeyTwo>...
        /// <summary>
        /// 分页扩展方法
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <typeparam name="TKeyOne">排序键1</typeparam>
        /// <typeparam name="TKeyTwo">排序键2</typeparam>
        /// <param name="queryable">集合对象</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelectorOne">排序键选择器1</param>
        /// <param name="keySelectorTwo">排序键选择器2</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="rowCount">总记录条数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>对象集合</returns>
        public static IQueryable<T> FindByPage<T, TKeyOne, TKeyTwo>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate, Expression<Func<T, TKeyOne>> keySelectorOne, Expression<Func<T, TKeyTwo>> keySelectorTwo, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            #region # 验证参数

            if (queryable == null)
            {
                throw new ArgumentNullException("queryable", @"源集合对象不可为空！");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate", @"查询条件对象不可为空！");
            }
            if (keySelectorOne == null || keySelectorTwo == null)
            {
                throw new ArgumentNullException("keySelector", @"参照字段表达式不可为空！");
            }
            if (pageIndex.IsZeroOrMinus())
            {
                throw new ArgumentOutOfRangeException("pageIndex", @"页码不可为0或负数！");
            }
            if (pageSize.IsZeroOrMinus())
            {
                throw new ArgumentOutOfRangeException("pageSize", @"页容量不可为0或负数！");
            }

            #endregion

            IQueryable<T> list = queryable.Where(predicate);
            rowCount = list.Count();
            pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
            return list.OrderByDescending(keySelectorOne).ThenByDescending(keySelectorTwo).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        #endregion
    }
}