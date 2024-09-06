using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace UvodWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private const string connectionString = "Host=localhost:5432;Username=postgres;Password=postgres;Database=WebDatabase";


        [HttpPost]
        public IActionResult CreateOwner(Owner owner)
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
                    return BadRequest("Not added");
                }
                return Ok("Successfully added");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOwnerById(Guid id)
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
                    return BadRequest("Not found");
                }
                return Ok("Successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
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
                    return BadRequest("Not found");
                }
                return Ok("Successfully Updated");
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request");
            }


        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOwnerById(Guid id)
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
                    return BadRequest("Not found");
                }
                return Ok(owner);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]

        public IActionResult GetOwners()
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
                    return BadRequest("Not found");
                }
                return Ok(owners);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
