﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;

namespace WorkingWithDatabases.Dal
{
    public class CustomerAdapter
    {
        private string _connectionString = @"Data Source= Chinook_Sqlite_AutoIncrementPKs.sqlite; datetimeformat=CurrentCulture;";

        public List<Customer> GetAll()
        {
            
            List<Customer> returnValue = new List<Customer>();
            
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerId, FirstName, LastName, Country, Email FROM Customer";
                connection.Open();
                
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    Customer customer = GetFromReader(reader);
                    
                    returnValue.Add(customer);
                }
                // return back the results
                return returnValue;
            }
        }

        public Customer GetById(int customerId)
        {
            Customer returnValue = null;
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerId, FirstName, LastName, Country, Email FROM Customer WHERE CustomerId = " + customerId.ToString();
                connection.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    returnValue = GetFromReader(reader);
                }

                return returnValue;
            }
        }

        private Customer GetFromReader(DbDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
            customer.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            customer.LastName = reader.GetString(reader.GetOrdinal("LastName"));
            customer.Country = reader.GetString(reader.GetOrdinal("Country"));
            customer.Email = reader.GetString(reader.GetOrdinal("Email"));
            return customer;
        }
    }
}

