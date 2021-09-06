using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControlX
{
    static class Conn
    {
        private const string server = "localhost";
        private const string database = "finance-control";
        private const string user = "root";
        private const string password = "root";

        static public string connectionString = $"server={server};User Id={user};database={database};password={password}";
    }
}
