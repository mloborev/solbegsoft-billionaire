using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Billionaire.Models
{
    public class GetData
    {
        private readonly IConfiguration _configuration;
        private string connectionString;

        public GetData(IConfiguration configuration)
        {
            _configuration = configuration;

            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        [HttpGet]

        public static GameLogicModel GetDataFromDB(int id)
        {

            GameLogicModel questions = new();

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-I8RHPFS;Initial Catalog=Billionaire;Persist Security Info=True;Integrated Security=SSPI"))
            {
                connection.Open();

                    using (SqlCommand command = new SqlCommand($"SELECT * FROM dbo.Questions WHERE id = {id}", connection))
                    {
                        using var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            questions.Id = (int)reader["Id"];
                            questions.Question = (string)reader["Question"];
                            questions.Answer1 = (string)reader["Answer1"];
                            questions.Answer2 = (string)reader["Answer2"];
                            questions.Answer3 = (string)reader["Answer3"];
                            questions.Answer4 = (string)reader["Answer4"];
                            questions.TrueAnswer = (int)reader["TrueAnswer"];
                        }
                    }
                /*Random rnd = new Random();
                questions = Enumerable.Range(1, id).OrderBy(x => rnd.Next()).ToArray();*/
                return questions;
            }
        }
    }
}