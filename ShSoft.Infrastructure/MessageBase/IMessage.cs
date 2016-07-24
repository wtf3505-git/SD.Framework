﻿using System;

namespace ShSoft.Infrastructure.MessageBase
{
    /// <summary>
    /// 消息基接口
    /// </summary>
    public interface IMessage
    {
        #region # 属性

        #region 标识 —— Guid Id
        /// <summary>
        /// 标识
        /// </summary>
        Guid Id { get; }
        #endregion

        #region 是否已处理 —— bool Handled
        /// <summary>
        /// 是否已处理
        /// </summary>
        bool Handled { get; }
        #endregion

        #region 会话Id —— Guid SessionId
        /// <summary>
        /// 会话Id
        /// </summary>
        Guid SessionId { get; }
        #endregion

        #region 触发时间 —— DateTime? TriggerTime
        /// <summary>
        /// 触发时间
        /// </summary>
        DateTime? TriggerTime { get; }
        #endregion

        #region 添加时间 —— DateTime AddedTime
        /// <summary>
        /// 添加时间
        /// </summary>
        DateTime AddedTime { get; }
        #endregion

        #endregion
    }
}