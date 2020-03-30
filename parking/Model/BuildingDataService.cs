﻿using Dapper;
using parking.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    class BuildingDataService
    {

        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Aanmaken van een object uit de IDbConnection class en instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public ObservableCollection<Building> GetBuilding()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Building order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Building> buildings = db.Query<Building>(sql).ToObservableCollection();

            return buildings;
        }

        public void UpdateBuilding(Building building)
        {
            // SQL statement update 
            string sql = "Update Building set place = @place, description = @description, location=@location where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { building.Place, building.Description, building.Location, building.Id });
        }

        public void DeleteBuidling(Building building)
        {
            // SQL statement delete 
            string sql = "Delete Building where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { building.Id });
        }

        public void InsertBuilding(Building building)
        {
            // SQL statement delete 
            string sql = "Insert Building(place,description,location) values(@prename,@lastname,@phoneNumber)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { building.Place, building.Description, building.Location});
        }


    }
}