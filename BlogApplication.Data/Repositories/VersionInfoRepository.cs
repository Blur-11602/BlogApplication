using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.Data.Models;

namespace BlogApplication.Data.Repositories
{
    public class VersionInfoRepository
    {
        private readonly DbSet<VersionInfo> _entities = new BlogApplicationEntities().VersionInfo;

        public VersionInfoRepository()
        {

        }

        public List<VersionInfo> GetVersions()
        {
            return _entities.ToList();
        }
    }
}
