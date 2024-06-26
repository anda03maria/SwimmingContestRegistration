﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;


namespace SwimmingPersistence.factory
{
    public class SqliteConnectionFactory: ConnectionFactory
    {
        public override IDbConnection CreateConnection(IDictionary<string, string> props)
        {
            String connectionString = props["ConnectionString"];
            Console.WriteLine("SQLite -- Se deschide o conexiune la ... {0}", connectionString);
            return new SQLiteConnection(connectionString);
        }
    }
}