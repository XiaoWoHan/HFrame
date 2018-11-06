using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.DAL
{
    public class Data_User: DbBase<Data_User>
    {
        private string ID { get; set; }
        public string OID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
