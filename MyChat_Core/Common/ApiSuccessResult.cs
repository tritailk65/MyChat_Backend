using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Common
{
	public class ApiSuccessResult<T> : ApiResult<T>
	{
		public ApiSuccessResult(T resultObj)
		{
			IsSuccessed = true;
			Message = "Thành công";
			Exception = "";
			Data = resultObj;
		}

		public ApiSuccessResult()
		{
			IsSuccessed = true;
			Message = "Thành công";
		}
	}
}
