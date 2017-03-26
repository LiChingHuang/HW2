using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HW1_1.Models
{   
	public  class 客戶資料關聯表Repository : EFRepository<客戶資料關聯表>, I客戶資料關聯表Repository
	{

	}

	public  interface I客戶資料關聯表Repository : IRepository<客戶資料關聯表>
	{

	}
}