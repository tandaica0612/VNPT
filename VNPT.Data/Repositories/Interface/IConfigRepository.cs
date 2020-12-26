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
        public List<Config> GetByGroupNameAndCodeAndParentIDToList(string groupName, string code, int parentID);
        public List<Config> GetSQLByGroupNameAndCodeAndParentIDToList(string groupName, string code, int parentID);
        public List<Config> GetSQLByGroupNameAndCodeToList(string groupName, string code);
        public List<Config> GetSQLWardByGroupNameAndCodeAndParentIDToList(string groupName, string code, int parentID);
        public List<Config> GetSQLProductByGroupNameAndCodeToList(string groupName, string code);
        public List<Config> GetSQLCityByGroupNameAndCodeToList(string groupName, string code);
    }
}
