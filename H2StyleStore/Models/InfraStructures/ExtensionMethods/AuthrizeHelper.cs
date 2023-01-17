using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace H2StyleStore.Models.Infrastructures.ExtensionMethods
{
	public class AuthrizeHelper
	{
		public bool IsAuthenticated(List<int> permissions)
		{
			
				var test = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
				if (test == null) { return false; }
				var roles = FormsAuthentication.Decrypt(System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;  //抓出cookie  跟  roles比較
				return permissions.Contains(Convert.ToInt32(roles));//用來判斷權限
			
			
			
		}
	}
}