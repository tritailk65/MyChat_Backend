using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Common
{
	public class ApiResult<T>
	{
		public bool IsSuccessed { get; set; }
		public string Message { get; set; }
		public string Exception { get; set; }	
		public T Data { get; set; }
	}
}
