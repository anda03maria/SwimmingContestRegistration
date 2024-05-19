﻿using System;
using System.Collections.Generic;
using System.Data;
using SwimmingPersistence.factory;

namespace SwimmingPersistence
{
    public class DBUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection(IDictionary<string, string> props)
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = GetNewConnection(props);
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection GetNewConnection(IDictionary<string, string> props)
        {
            return ConnectionFactory.GetInstance().CreateConnection(props);
            
        }
    }
}