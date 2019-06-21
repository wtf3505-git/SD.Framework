﻿using SD.Infrastructure.CrontabBase.Tests.StubCrontabs;
using System;
using System.Diagnostics;

namespace SD.Infrastructure.CrontabBase.Tests.StubCrontabExecutors
{
    public class AlarmCrontabExecutor : CrontabExecutor<AlarmCrontab>
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="crontab">定时任务</param>
        public override void Execute(AlarmCrontab crontab)
        {
            Trace.WriteLine(crontab.Word);

            crontab.Rung = true;
            crontab.Count++;

            base._logAppender.Append("［测试日志］" + 1
            + Environment.NewLine + "［测试日志］" + 2
            + Environment.NewLine + "［测试日志］" + 3
            + Environment.NewLine + "［测试日志］" + 4
            );
        }
    }
}
