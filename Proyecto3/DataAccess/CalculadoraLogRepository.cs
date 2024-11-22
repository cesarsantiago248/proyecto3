using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto3.DataAccess
{
    public class CalculadoraLog
    {
        public int id { get; set; }
        public double primernum { get; set; }
        public double segundonum { get; set; }
        public string operador { get; set; }
        public double resultado { get; set; }
        public DateTime fecha_reg { get; set; }
    }

    public class CalculadoraLogRepository
    {
        private readonly string connectionString;

        public CalculadoraLogRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CalculadoraDb"].ConnectionString;
        }

        public List<CalculadoraLog> GetAllLogs()
        {
            var logs = new List<CalculadoraLog>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, primernumero, operador, segundonumero, resultado, fecha_hora FROM calculadora_log;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                logs.Add(new CalculadoraLog
                                {
                                    id = reader.GetInt32(0),
                                    primernum = reader.GetDouble(1),
                                    operador = reader.GetString(2),
                                    segundonum = reader.GetDouble(3),
                                    resultado = reader.GetDouble(4),
                                    fecha_reg = reader.GetDateTime(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error (use logging library or write to debug/output)
                Console.WriteLine($"Error: {ex.Message}");
            }

            return logs;
        }

        public CalculadoraLog GetLogById(int id)
        {
            CalculadoraLog log = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, primernumero, operador, segundonumero, resultado, fecha_hora FROM calculadora_log WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            log = new CalculadoraLog
                            {
                                id = reader.GetInt32(0),
                                primernum = reader.GetDouble(1),
                                segundonum = reader.GetDouble(3),
                                operador = reader.GetString(2),
                                resultado = reader.GetDouble(4),
                                fecha_reg = reader.GetDateTime(5)
                            };
                        }
                    }
                }
            }

            return log;
        }

        public List<CalculadoraLog> GetLogsByOperator(string operador)
        {
            var logs = new List<CalculadoraLog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, primernumero, operador, segundonumero, resultado, fecha_hora FROM calculadora_log WHERE operador = @Operador";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Operador", operador);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new CalculadoraLog
                            {
                                id = reader.GetInt32(0),
                                primernum = reader.GetDouble(1),
                                segundonum = reader.GetDouble(3),
                                operador = reader.GetString(2),
                                resultado = reader.GetDouble(4),
                                fecha_reg = reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }

            return logs;
        }



    }
}
