using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IConfigRepository : IRepository<Config>
    {
        public Config GetByGroupNameAndCodeAndTitle(string groupName, string code, string title);
        public List<Config> GetByGroupNameAndCodeToList(string groupName, string code);
    }
}
