﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Exceptions
{
    public static class LogTraceFactory
    {
		private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

		public static void LogDebug(string message)
		{
			logger.Debug(message);
		}

		public static void LogError(string message)
		{
			logger.Error(message);
		}

		public static void LogInfo(string message)
		{
			logger.Info(message);
		}

		public static void LogWarn(string message)
		{
			logger.Warn(message);
		}
	}
}
