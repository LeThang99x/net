using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProductRepository:BaseRepository
    {
        public ProductRepository(IConfiguration confirguration): base(confirguration)
        {

        }
        public int Edit(Product obj)
        {
            Parameter[] paramaters =
           {
                new Parameter{ Name="@Id", Value = obj.Id },
                new Parameter{ Name="@Name", Value = obj.Name },
                new Parameter{ Name="@CategoryId", Value=obj.CategoryId },
                new Parameter{ Name="@BrandId", Value=obj.BrandId },
                new Parameter{ Name="@ModelYear", Value=obj.ModelYear },
                new Parameter{ Name="@Price", Value=obj.Price }

            };
            return Save("EditProduct", paramaters, CommandType.StoredProcedure);
        }
        public Product GetProductById(int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT *FROM production.Product where ProductId=@Id";
                    Add(command, new Parameter { Name = "@Id", Value = id });
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
        static Product Fetch(IDataReader reader)
        {
            /* return new Product
             {
                 Id = (int)reader["ProductId"],
                 Name = (string)reader["ProductName"],
                 BrandId = (short)reader["BrandId"],
                 CategoryId = (short)reader["CategoryId"],
                 ModelYear = (short)reader["ModelYear"],
                 Price = (decimal)reader["Price"],
             }; */
            Product obj = Fetch(reader);
            obj.BrandName = (string)reader["BrandName"];
            obj.BrandName = (string)reader["CategoryName"];
            return obj;
        }
        static Product Fetch2(IDataReader reader)
        {
            return new Product
            {
                Id = (int)reader["ProductId"],
                Name = (string)reader["ProductName"],
                BrandId = (short)reader["BrandId"],
                BrandName=(string)reader["BrandName"],
                CategoryId = (short)reader["CategoryId"],
                CategoryName=(string)reader["CategoryName"],
                ModelYear = (short)reader["ModelYear"],
                Price = (decimal)reader["Price"],
            };
        }
        static List<Product> FetcAll(IDbCommand command)
        {
            List<Product> list = new List<Product>();
            using (IDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    list.Add(Fetch2(reader));

                }

            }
            
            return list;
        }
        public List<Product> GetProducts(int index, int size, out int total)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetProducts";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@Index", Value=index,DbType=DbType.Int32},
                        new Parameter{Name="@Size", Value=size,DbType=DbType.Int32},
                        new Parameter{Name="@Total", Direction=ParameterDirection.Output, DbType=DbType.Int32}
                    };
                    Add(command, parameters);
                    connection.Open();

                    /*
                    List<Product> list = new List<Product>();
                    using (IDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            list.Add(Fetch2(reader));

                        }

                    }*/
                    List<Product> list = FetcAll(command);
                    IDataParameter parameter = (IDataParameter)command.Parameters["@Total"];
                    total = (int)parameter.Value;
                    return list; 
                }
            }
        }
        public List<Product> SearchProducts(string q, int index, int size, out int total)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SearchProducts";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@Q", Value=$"%{q}%"},
                        new Parameter{Name="@Index", Value=index,DbType=DbType.Int32},
                        new Parameter{Name="@Size", Value=size,DbType=DbType.Int32},
                        new Parameter{Name="@Total", Direction=ParameterDirection.Output, DbType=DbType.Int32}

                    };
                    Add(command, parameters);
                    connection.Open();
                    /*  List<Product> list = new List<Product>();
                      using (IDataReader reader = command.ExecuteReader())
                      {

                          while (reader.Read())
                          {
                              list.Add(Fetch2(reader));

                          }

                      } */
                    List<Product> list = FetcAll(command);
                    total = (int)parameters[3].DatatParameter.Value;
                    return list;
                }
            }
        }
        public List<Product> GetProducts(int index, int size)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("BikeStore")))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetProductsNotTotal";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@Index", Value=index,DbType=DbType.Int32},
                        new Parameter{Name="@Size", Value=size,DbType=DbType.Int32}
                    };
                    Add(command, parameters);
                    connection.Open();
                    List<Product> list = new List<Product>();
                    using (IDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            list.Add(Fetch2(reader));

                        }

                    }               
                    return list;
                }
            }
        }
        public int Add(Product obj)
        {
            Parameter[] paramaters =
            {
                new Parameter{ Name="@Name", Value = obj.Name },
                new Parameter{ Name="@CategoryId", Value=obj.CategoryId },
                new Parameter{ Name="@BrandId", Value=obj.BrandId },
                new Parameter{ Name="@ModelYear", Value=obj.ModelYear },
                new Parameter{ Name="@Price", Value=obj.Price }

            };
            return Save("AddProduct", paramaters, CommandType.StoredProcedure);
        }
    }
}
