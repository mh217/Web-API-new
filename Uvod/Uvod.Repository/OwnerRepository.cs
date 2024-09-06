using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;
using Uvod.Repository.Common;

namespace Uvod.Repository
{
    public class OwnerRepository : IOwnerRepository
    {

        private const string connectionString = "Host=localhost:5432;Username=postgres;Password=postgres;Database=WebDatabase";

        public bool CreateOwner(Owner owner)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "INSERT INTO \"Owner\"  VALUES (@id, @firstName, @lastName);";
                var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Uuid, Guid.NewGuid());
                command.Parameters.AddWithValue("@firstName", owner.FirstName);
                command.Parameters.AddWithValue("@lastName", owner.LastName);

                connection.Open();
                var numberOfCommits = command.ExecuteNonQuery();
                connection.Close();

                if (numberOfCommits == 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOwner(Guid id)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "DELETE FROM \"Owner\" WHERE \"Id\" = @id;";
                var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                var numberOfCommits = command.ExecuteNonQuery();

                if (numberOfCommits == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Owner GetOwnerById(Guid id) 
        {
            try
            {
                Owner owner = new Owner();
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT * FROM \"Owner\" WHERE \"Id\" = @id;";
                var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                using NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    owner.Id = Guid.Parse(reader["Id"].ToString());
                    owner.FirstName = reader["FirstName"].ToString();
                    owner.LastName = reader["LastName"].ToString();

                }
                else
                {
                    return null;
                }
                return owner;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Owner> GetOwners() 
        {
            try
            {
                List<Owner> owners = new List<Owner>();
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT * FROM \"Owner\";";

                var command = new NpgsqlCommand(commandText, connection);
                connection.Open();
                using NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Owner owner = new Owner();
                        owner.Id = Guid.Parse(reader["Id"].ToString());
                        owner.FirstName = reader["FirstName"].ToString();
                        owner.LastName = reader["LastName"].ToString();
                        owners.Add(owner);
                    }
                }
                else
                {
                    return null;
                }
                return owners;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateOwner(Guid id, Owner owner)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "UPDATE \"Owner\" SET \"FirstName\" = @firstName  WHERE \"Id\" = @id;";
                var command = new NpgsqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", owner.FirstName);
                connection.Open();

                var numberOfCommits = command.ExecuteNonQuery();

                if (numberOfCommits == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
