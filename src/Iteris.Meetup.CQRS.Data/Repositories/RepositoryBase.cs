using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Data.Repositories
{
    public class RepositoryBase
    {
        protected const string ConnString = "DataSource=..\\..\\data.db";
    }
}
