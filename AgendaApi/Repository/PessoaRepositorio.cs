using AgendaApi.Interfaces;
using AgendaApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AgendaApi.Repository
{
    public class PessoaRepositorio : IRepository<Pessoa, int>
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=agenda;Integrated Security = True";

        public void Delete(int id)
        {
            string deleteQuery = "DELETE FROM tb_pessoas WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Pessoa excluída com sucesso.");
                }
                catch (Exception ex)
                {
                   throw new Exception(ex.Message);
                }
            }
        }

        public Pessoa Get(int id)
        {
            string selectQuery = "SELECT Id, Nome, Email, Fone FROM tb_pessoas WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pessoa
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Fone = reader.GetString(reader.GetOrdinal("Fone"))
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return null;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            string selectQuery = "SELECT Id, Nome, Email, Fone FROM tb_pessoas";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pessoas.Add(new Pessoa
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Fone = reader.GetString(reader.GetOrdinal("Fone"))
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return pessoas;
        }

        public Pessoa Save(Pessoa entity)
        {
            string insertQuery = "INSERT INTO tb_pessoas (Nome, Email, Fone) VALUES (@Nome,@Email, @Fone); SELECT SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Nome", entity.Nome);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@Fone", entity.Fone);
                try

                {
                    connection.Open();
                    entity.Id = Convert.ToInt32(command.ExecuteScalar());
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return entity;
        }

        public void Update(Pessoa entity)
        {
            string updateQuery = "UPDATE tb_pessoas SET Nome = @Nome, Email = @Email, Fone = @Fone WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Nome", entity.Nome);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@Fone", entity.Fone);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
