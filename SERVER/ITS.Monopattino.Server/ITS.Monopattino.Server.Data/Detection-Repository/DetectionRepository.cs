using Dapper;
using Dapper.Contrib.Extensions;
using ITS.Monopattino.Server.Data;
using ITS.Monopattino.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Monopattino.Server.Data
{
    public class DetectionRepository : IDetectionRepository
    {
        private readonly string _connectionString;

        public DetectionRepository(IConfiguration configuration)
        { 
            this._connectionString = configuration.GetConnectionString("ValleProject");
        }
        public IEnumerable<Detection> GetDetections()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * From Detections";
                return connection.Query<Detection>(query);
            }
        }

        public IEnumerable<Detection> GetDetectionsByScooter(int scooterId)
        {
            throw new NotImplementedException();
        }


        public void InsertDetection(Detection detection)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(detection);
            }
        }
    }
}
