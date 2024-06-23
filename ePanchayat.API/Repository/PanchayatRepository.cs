﻿using ePanchayat.API.Interfaces;
using ePanchayat.API.Models;
using System.Data;

namespace ePanchayat.API.Repository
{
    public class PanchayatRepository : IPanchayatRepository
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PanchayatRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<Panchayat> GetAll()
        {

            var dataset = _sqlDataAccess.GetDataSetByStoredProc("PanchayatGet_sp");
            return Map(dataset);
        }

        public Panchayat GetById(int panchayatId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PanchayatId", panchayatId }
            };
            var dataset = _sqlDataAccess.GetDataSetByStoredProc("PanchayatGet_sp", parameters);

            return Map(dataset).First();
        }

        public bool Remove(Panchayat panchayat)
        {
            throw new NotImplementedException();
        }

        public bool Save(Panchayat panchayat)
        {
            throw new NotImplementedException();
        }

        private List<Panchayat> Map(DataSet dataset)
        {
            if(dataset.Tables.Count == 0 || dataset.Tables[0].Rows.Count == 0)
            {
                return new List<Panchayat>();
            }

            var panchayats = dataset.Tables[0].AsEnumerable().Select(row => new Panchayat()
            {
                PanchayatId = Convert.ToInt32(row["PanchayatId"]),
                PanchayatName = Convert.ToString(row["PanchayatName"]),
                LastModifiedOn = Convert.ToDateTime(row["LastModifiedOn"]),
                LastModifiedBy = Convert.ToInt32(row["LastModifiedBy"]),
                LastModifiedByFullName = Convert.ToString(row["LastModifiedByFullName"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            }).ToList();

            return panchayats;
        }
    }
}