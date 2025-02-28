﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AddressBookLINQ
{
    public class AddressBookManagement
    {
        public DataTable dataTable = new DataTable();
        public AddressBookManagement()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(double));
            dataTable.Columns.Add("PhoneNumber", typeof(double));
            dataTable.Columns.Add("Email", typeof(string));

            // Creating rows and adding data into row
            dataTable.Rows.Add("Sumit", "Patel", "Ugwa", "Akola", "Maharashtra", 444006, 9890989065, "Sumit121@gmail.com");
            dataTable.Rows.Add("Viraj", "Patel", "Akola", "Vidarbha", "Maharshtra", 444008, 9565956263, "Viraj11@gmail.com");
            dataTable.Rows.Add("Rohit", "Sharma", "Mumbai", "NaviMumbai", "MH", 111004, 8546365412, "Rohit10@gmail.com");
            dataTable.Rows.Add("Virat", "Kohli", "Mall", "Delhii", "Dehli", 555645, 9874562635, "Virat14@gmail.com");
            dataTable.Rows.Add("Rahul", "Kl", "PHmall", "Pune", "Maharashtra", 444008, 9896562635, "Rahul005@gmail.com");
            dataTable.Rows.Add("Sachin", "Singh", "PNP", "Vai", "Goa", 444056, 9856362563, "Sachin10@gmail.com");
        }

        public void getAllData()
        {
            foreach (var data in dataTable.AsEnumerable())
            {
                Console.WriteLine("FirstName: " + data.Field<string>("Firstname") + ","
                    + "LastName: " + data.Field<string>("LastName") + ","
                    + "Address: " + data.Field<string>("Address") + ","
                    + "City: " + data.Field<string>("City") + ","
                    + "State: " + data.Field<string>("State") + ","
                    + "Zip: " + data.Field<double>("Zip") + ","
                    + "PhoneNumber: " + data.Field<double>("PhoneNumber") + ","
                    + "Email: " + data.Field<string>("Email"));
                Console.WriteLine("\n");
            }
        }
        public void UpdatePersonByName()
        {
            Console.WriteLine("Enter FirstName : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter columnName : ");
            string columnName = Console.ReadLine();
            Console.WriteLine("Enter Upadated Value : ");
            string Updatedvalue = Console.ReadLine();
            DataRow updatedperson = dataTable.Select("FirstName = '" + firstName + "'").FirstOrDefault();
            updatedperson[columnName] = Updatedvalue;
            Console.WriteLine("Contanted is Updated ");
            getAllData();
        }
        public void DeletePersonByName()
        {
            Console.WriteLine("Enter Firstname: ");
            string firstName = Console.ReadLine();
            var data = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName") == firstName);

            foreach (var rows in data.ToList())
            {
                rows.Delete();
            }
            getAllData();
        }
        public void displayContactUsingCityOrState()
        {
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State : ");
            string state = Console.ReadLine();
            var Record = from record in dataTable.AsEnumerable()
                         where record.Field<string>("City").Equals(city) || record.Field<string>("State").Equals(state)
                         select record;

            foreach (var record in Record)
            {
                Console.WriteLine("FirstName :" + record.Field<string>("Firstname") + "," + "City :" + record.Field<string>("City") + "," +
                    "State : " + record.Field<string>("State"));
            }
        }
        public void displayCountByCityAndState()
        {
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State : ");
            string state = Console.ReadLine();
            var Record = from record in dataTable.AsEnumerable()
                         where record.Field<string>("City").Equals(city) && record.Field<string>("State").Equals(state)
                         select record;
            Console.WriteLine("No.of Records persent in dataTable is " + Record.Count());

        }
        public void OrderedByFirstnameWithGivenCity()
        {
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();

            var Records = from person in dataTable.AsEnumerable()
                          where person.Field<string>("City").Equals(city)
                          orderby person.Field<string>("FirstName")
                          select person;
            /* var Records = from record in dataTable.AsEnumerable()
                           where record.Field<string>("City").Equals(city)
                           orderby record.Field<string>("FirstName")
                           select record;*/

            foreach (var record in Records)
            {
                getAllData();
            }

        }
    }
}