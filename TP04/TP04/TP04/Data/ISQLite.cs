using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP04.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConexao();
    }
}
