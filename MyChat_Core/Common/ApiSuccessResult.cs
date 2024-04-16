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
			Message = "Đăng Nhập Thành công";
			ResultObj = resultObj;
		}

		public ApiSuccessResult()
		{
			IsSuccessed = true;
			Message = "Đăng Nhập Thành công";

		}
	}
}
