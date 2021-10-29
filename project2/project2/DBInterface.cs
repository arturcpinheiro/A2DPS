using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace project2
{
    public interface DBInterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}
