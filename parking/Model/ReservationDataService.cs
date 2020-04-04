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
    public class ReservationDataService : BaseModelDataService
    {


        public ObservableCollection<Reservation> GetReservation()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Reservation order by Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Reservation> reservations = db.Query<Reservation>(sql).ToObservableCollection();

            return reservations;
        }


        public ParkPlace GetNewParkPlaces(Reservation reservation, String location)
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select TOP 1 PERCENT pa.* from Reservation res" +
                "RIGHT JOIN ParkPlace pa ON pa.id = res.parkPlaceId" +
                "JOIN Building bu ON pa.buildingId = bu.Id" +
                "Where" +
                "bu.location ='" + location + "'"+
                "AND" +
                "(" +
                "    res.beginTime NOT BETWEEN CONVERT(datetime, '"+ reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "')" +
                "OR" +
                "res.beginTime IS NULL" +
                ")" +
                "AND" +
                "(" +
                "res.endTime NOT BETWEEN CONVERT(datetime, '" + reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "')" +
                "OR" +
                "res.endTime IS NULL" +
                ")" +
                "AND" +
                "pa.Id NOT IN(" +
                "Select pa.Id from Reservation res" +
                "RIGHT JOIN ParkPlace pa ON pa.id = res.parkPlaceId" +
                "JOIN Building bu ON pa.buildingId = bu.Id" +
                "Where" +
                "bu.location ='" + location + "'" +
                "AND" +
                "res.beginTime BETWEEN CONVERT(datetime, '" + reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "')" +
                "OR" +
                "res.endTime BETWEEN CONVERT(datetime, '" + reservation.BeginTime + "') AND CONVERT(datetime, '" + reservation.EndTime + "')" +
                ")" +
                "ORDER by res.Id";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen

            List<ParkPlace> parkPlaces = db.Query<ParkPlace>(sql).ToList();

            ParkPlace parkplace;


            if (parkPlaces.Count == 0)
            {
                parkplace = null;
            }
            else
            {
                parkplace = parkPlaces.First();
            }

            return parkplace;
        }

        public void UpdateReservation(Reservation reservation)
        {
            // SQL statement update 
            string sql = "Update Reservation set userId=@userId, parkPlaceId=@parkPlaceId, status=@status, date=@date, beginTime=@beginTime, endTime=@endTime where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { reservation.UserId, reservation.ParkPlaceId, reservation.Status, reservation.Date, reservation.BeginTime, reservation.EndTime, reservation.Id });
        }

        public void DeletReservation(Reservation reservation)
        {
            // SQL statement delete 
            string sql = "Delete Reservation where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { reservation.Id });
        }

        public void InsertReservation(Reservation reservation)
        {
            // SQL statement Insert 
            string sql = "Insert Reservation(userId,parkPlaceId,status,date,beginTime,endTime) values(@userId,@parkPlaceId,@status,@date,@beginTime,@endTime)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { reservation.UserId, reservation.ParkPlaceId, reservation.Status, reservation.Date, reservation.BeginTime, reservation.EndTime });
        }
    }
}
