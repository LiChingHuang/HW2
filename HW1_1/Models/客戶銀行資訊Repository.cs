using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HW1_1.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public 客戶銀行資訊 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(c => false == c.是否已刪除);
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.是否已刪除 = true;
            //base.Delete(entity);
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}