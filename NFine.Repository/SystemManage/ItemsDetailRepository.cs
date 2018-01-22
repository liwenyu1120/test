/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 
*********************************************************************************/
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace NFine.Repository.SystemManage
{
    public class ItemsDetailRepository : RepositoryBase<ItemsDetailEntity>, IItemsDetailRepository
    {
        public List<ItemsDetailEntity> GetItemList(string enCode, string itemCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  d.*");
            strSql.Append(@"FROM Sys_ItemsDetail d");
            strSql.Append(@" INNER JOIN Sys_Items i ON i.F_Id = d.F_ItemId");
            strSql.Append(@" WHERE 1 = 1");
            strSql.Append(@" AND i.F_EnCode = '" + enCode + "'");
            strSql.Append(@" AND d.F_EnabledMark = 1");
            if (itemCode != "")
                strSql.Append(@" AND d.F_ItemCode ='" + itemCode + "'");
            strSql.Append(@" ORDER BY d.F_SortCode ASC");
            //DbParameter[] parameter = 
            //{
            //     new SqlParameter("@enCode",enCode)
            //};
            return this.FindList(strSql.ToString());
        }
    }
}
