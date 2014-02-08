using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHost
{
	/// <summary>
	/// 定义当前工程用到的所有常量或者只读变量。
	/// </summary>
	internal class Constants
	{
		// 定义系统中用到的连接字符串的键
		// public const string ConnectionStringKey = "XXXDB";

		// 普通常量定义示例

		// 缓存常量定义
		// 如果工程中包含有 CacheHelper 类，那么缓存相关的常量可定义在 CacheHelper 里
		// 缓存名称、缓存分区名定义，分区名定义必须符合“缓存名_分区名”的格式
		// 缓存名及其分区名定义示例：
		// public const string Cache_XXX = "XXX";
		// public const string Cache_XXX_YYY = "XXX_YYY";
		// public const string Cache_XXX_ZZZ = "XXX_ZZZ";


		// 其它常量定义
		public const string DefaultServiceName = "SSqianService";
		public const string DefaultServiceDisplayName = "上上签Rest服务";
        public const string DefaultServiceDescription = "上上签Rest服务";
	}
}
