﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using ShSoft.Framework2015.Infrastructure.IOC.Mediator;
using ShSoft.Framework2015.Infrastructure.IRepository;

namespace ShSoft.Framework2015.Infrastructure.WCF.IOC
{
    /// <summary>
    /// WCF实例提供者
    /// </summary>
    internal class WcfInstanceProvider : IInstanceProvider
    {
        #region # 字段及构造器

        /// <summary>
        /// 服务契约类型
        /// </summary>
        private readonly Type _serviceType;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="serviceType">服务契约类型</param>
        public WcfInstanceProvider(Type serviceType)
        {
            this._serviceType = serviceType;
        }

        #endregion

        #region # 获取服务契约实例 —— object GetInstance(InstanceContext instanceContext, Message message)
        /// <summary>
        /// 获取服务契约实例
        /// </summary>
        /// <param name="instanceContext">WCF上下文对象</param>
        /// <param name="message">消息</param>
        /// <returns>服务契约实例</returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return ResolverMediator.Resolve(this._serviceType);
        }
        #endregion

        #region # 获取服务契约实例 —— object GetInstance(InstanceContext instanceContext)
        /// <summary>
        /// 获取服务契约实例
        /// </summary>
        /// <param name="instanceContext">WCF上下文对象</param>
        /// <returns>服务契约实例</returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }
        #endregion

        #region # 清理实例契约 —— void ReleaseInstance(InstanceContext instanceContext, object instance)
        /// <summary>
        /// 清理实例契约
        /// </summary>
        /// <param name="instanceContext">WCF上下文对象</param>
        /// <param name="instance">服务契约实例</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            //清理WCF上下文
            this.Clean(instanceContext);

            //清理数据库
            IDbCleaner dbCleaner = ResolverMediator.Resolve<IDbCleaner>();
            dbCleaner.Clean();
        }
        #endregion

        #region # 清理WCF上下文 —— void Clean(InstanceContext instanceContext)
        /// <summary>
        /// 清理WCF上下文
        /// </summary>
        /// <param name="instanceContext">WCF上下文对象</param>
        private void Clean(InstanceContext instanceContext)
        {
            if (instanceContext != null)
            {
                instanceContext.CloseChannel();
            }
        }
        #endregion
    }
}