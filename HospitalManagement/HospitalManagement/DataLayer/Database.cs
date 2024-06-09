﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataLayer
{
    class Database
    {
        public static OleDbConnection OpenConnection //Veritabanı bağlantısı kuruluyor.
        {
            get
            {
                string conString = Properties.Settings.Default.HospitalConnectionString;
                OleDbConnection connection = new OleDbConnection(conString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    return connection;
                }
                else
                    return connection;
            }
        }

        public static OleDbCommand SqlCommand(string c) //SQL sorgusu geriye dönen method.
        {
            OleDbCommand command = new OleDbCommand(c, OpenConnection);
            return command;
        }
    }
}

