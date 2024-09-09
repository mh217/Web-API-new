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

        public async Task<bool> CreateOwnerAsync(Owner owner)
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
                var numberOfCommits = await command.ExecuteNonQueryAsync();
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

        public async Task<bool> DeleteOwnerAsync(Guid id)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "DELETE FROM \"Owner\" WHERE \"Id\" = @id;";
                var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                var numberOfCommits = await command.ExecuteNonQueryAsync();

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

        public async Task<Owner> GetOwnerByIdAsync(Guid id) 
        {
            try
            {
                Owner owner = new Owner();
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT * FROM \"Owner\" WHERE \"Id\" = @id;";
                var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.ReadAsync();
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
        public async Task<List<Owner>> GetOwnersAsync() 
        {
            try
            {
                List<Owner> owners = new List<Owner>();
                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT * FROM \"Owner\";";

                var command = new NpgsqlCommand(commandText, connection);
                connection.Open();
                using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
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

        public async Task<bool> UpdateOwnerAsync(Guid id, Owner owner)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("UPDATE \"Owner\" SET");

                var command = new NpgsqlCommand(); 
                command.Connection = connection;

                if (owner.FirstName != null)
                {
                    stringBuilder.Append("\"FirstName\" = @firstName, ");
                    command.Parameters.AddWithValue("@firstName", owner.FirstName);
                }
                if (owner.LastName != null) 
                {
                    stringBuilder.Append("\"LastName\" = @lastName, ");
                    command.Parameters.AddWithValue("@lastName", owner.LastName);
                }
                
                stringBuilder.Length -= 2;
                stringBuilder.Append(" WHERE \"Id\" = @id;");

                command.CommandText = stringBuilder.ToString();
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                var numberOfCommits = await command.ExecuteNonQueryAsync();

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
