using VNPT.Data.DataTransferObject;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace VNPT.Data.Repositories
{
    public class ConfigRepository : Repository<Config>, IConfigRepository
    {
        private readonly VNPTContext _context;

        public ConfigRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public Config GetByGroupNameAndCodeAndTitle(string groupName, string code, string title)
        {
            Config item = _context.Set<Config>().FirstOrDefault(item => item.GroupName.Equals(groupName) && item.Code.Equals(code) && item.Title.Equals(title));
            return item;
        }
        public List<Config> GetByGroupNameAndCodeToList(string groupName, string code)
        {
            return _context.Config.Where(item => item.GroupName.Equals(groupName) && item.Code.Equals(code)).OrderBy(item => item.SortOrder).ToList();
        }
        public List<Config> GetByGroupNameAndCodeAndParentIDToList(string groupName, string code, int parentID)
        {
            return _context.Config.Where(item => item.GroupName.Equals(groupName) && item.Code.Equals(code) && item.ParentID == parentID).OrderBy(item => item.Title).ToList();
        }
        public List<Config> GetSQLByGroupNameAndCodeAndParentIDToList(string groupName, string code, int parentID)
        {
            List<Config> list = new List<Config>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@GroupName",groupName),
                new SqlParameter("@Code",code),
                new SqlParameter("@ParentID",parentID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ConfigSelectByGroupNameAndCodeAndParentID", parameters);
                list = SQLHelper.ToList<Config>(dt);
            }
            return list;
        }
        public List<Config> GetSQLWardByGroupNameAndCodeAndParentIDToList(string groupName, string code, int parentID)
        {
            List<Config> list = new List<Config>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@GroupName",groupName),
                new SqlParameter("@Code",code),
                new SqlParameter("@ParentID",parentID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ConfigSelectWardByGroupNameAndCodeAndParentID", parameters);
                list = SQLHelper.ToList<Config>(dt);
            }
            return list;
        }
        public List<Config> GetSQLByGroupNameAndCodeToList(string groupName, string code)
        {
            List<Config> list = new List<Config>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@GroupName",groupName),
                new SqlParameter("@Code",code),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ConfigSelectByGroupNameAndCode", parameters);
            list = SQLHelper.ToList<Config>(dt);
            return list;
        }
        public List<Config> GetSQLProductByGroupNameAndCodeToList(string groupName, string code)
        {
            List<Config> list = new List<Config>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@GroupName",groupName),
                new SqlParameter("@Code",code),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ConfigSelectProductByGroupNameAndCode", parameters);
            list = SQLHelper.ToList<Config>(dt);
            return list;
        }
    }
}
