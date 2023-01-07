using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Extensions
{
	public class OrderStatus : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			Dictionary<string, int> Status =

			new Dictionary<string, int>()

			{
				{"待處理", 0}, {"已結案", 1},{"已取消", 2}
			 };

			int val1 = Status[x];

			int val2 = Status[y];

			return val1 - val2;
		}
	}
}