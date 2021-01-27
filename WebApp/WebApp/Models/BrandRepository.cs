using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApp.Models
{
    public class BrandRepository : BaseRepository

    {
        public BrandRepository(IConfiguration configuration) : base(configuration)
        {

        }
        static Brand Fetch(IDataReader reader)
        {
            return new Brand
            {
                Id = (short)reader["BrandId"],
                Name = (string)reader["BrandName"]
            };
        }
        public Brand GetBrandById(int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select *from production.Brand  where BrandId=@Id";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@Id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            return Fetch(reader);
                          

                        }
                        return null;
                    }
                }
            }
        }
      
        public int Save(Brand obj)
        {
            Parameter[] parameters = {
             new Parameter
            {
                Name = "@Name",
                Value = obj.Name
            },
             new Parameter
             {
                 Name="@Id",
                 Value=obj.Id
             }
            };
            string sql = "SaveBrand";
            return Save(sql, parameters, CommandType.StoredProcedure);
        }
      
        public List<Brand> GetBrands()
        {
            using(IDbConnection connection=new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select *from production.Brand ";
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Brand> list = new List<Brand>();
                        while (reader.Read())
                        {
                            list.Add(Fetch(reader));

                        }
                        return list;
                    }
                }
            }
        }
    }
}
