using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApp.Models
{
    public class CategoryRepository:BaseRepository
    {
        //public IConfiguration configuration;
        public CategoryRepository(IConfiguration configuration):base(configuration)
        {
            //this.configuration = configuration;
        }
        public Category GetCategoryById(int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select *from production.Category  where CategoryId=@Id";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@Id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        
                     if(reader.Read())
                        {
                            return new Category
                            {
                                Id = (short)reader["CategoryId"],
                                Name = (string)reader["CategoryName"]
                            };

                        }
                        return null;
                    }
                }
            }
        }
        public int Delete(int[] a)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"delete from production.Category where CategoryId IN({string.Join(',', a)})";
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Edit2(Category obj)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "update production.Category set CategoryName=@Name where CategoryId=@Id";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@Name";
                    parameter.Value = obj.Name;
                    command.Parameters.Add(parameter);

                    IDataParameter idparameter = command.CreateParameter();
                    idparameter.ParameterName = "@Id";
                    idparameter.Value = obj.Id;
                    command.Parameters.Add(idparameter);


                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Edit(Category obj)
        {
           string sql = "update production.Category set CategoryName=@Name where CategoryId=@Id";
            Parameter[] parameters =
            {
                new Parameter{Name="@Id",Value=obj.Id},
                new Parameter{Name="@Name",Value=obj.Name}
            };
            return Save(sql, parameters);
        }
        public int Add2(Category obj)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into production.Category (CategoryName) values(@Name) ";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@Name";
                    parameter.Value = obj.Name;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int id)
        {
            string sql = "delete from production.Category where CategoryId=@Id";
            return Save(sql, new Parameter { Name = "@Id", Value = id });
        }
        public int Add(Category obj)
        {
           string sql = "insert into production.Category (CategoryName) values(@Name) ";
          return Save(sql, new Parameter { Name = "@Name", Value = obj.Name });
        }

        public int Delete2(int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "delete from production.Category where CategoryId=@Id";
                    IDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@Id";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<Category> GetCategories()
        {
            using(IDbConnection connection=new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select *from production.Category ";
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Category> list = new List<Category>();
                        while (reader.Read())
                        {
                            list.Add(new Category
                            {
                                Id = (short)reader["CategoryId"],
                                Name = (string)reader["CategoryName"]
                            });
                            
                        }
                        return list;
                    }
                }
            }
        }
    }
}
