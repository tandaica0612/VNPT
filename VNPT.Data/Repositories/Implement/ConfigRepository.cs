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
    }
}
