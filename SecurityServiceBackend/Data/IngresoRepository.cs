using Npgsql;
using SecurityServiceBackend.Models;

namespace SecurityServiceBackend.Data
{
	public class IngresoRepository
	{
		private readonly string _connectionString;


		public IngresoRepository(IConfiguration config)
		{
			_connectionString =
				config.GetConnectionString("PostgreSqlConnection");
		}



		public List<IngresoModel> ObtenerIngresos()
		{

			var lista = new List<IngresoModel>();


			using var connection = new NpgsqlConnection(_connectionString);

			connection.Open();



			string sql = @"
                SELECT
                    pro.car_number AS matricula,

                    pp.pers_person_lastname || ' ' ||
                    pp.pers_person_name AS propietario_oficial,

                    pp.pers_person_pin AS dni,

                    pro.check_in_time AS hora_ingreso,

                    pro.check_out_time AS hora_salida,

                    pro.user_name AS usuario_manejando,

                    pro.parking_area_name AS area_destino

            


                FROM park_recordout pro

                LEFT JOIN park_car_number pcn 
                ON pro.car_number = pcn.car_number

                LEFT JOIN park_person pp 
                ON pcn.person_id = pp.id

                WHERE pro.check_in_time IS NOT NULL

				ORDER BY pro.car_number, pro.check_in_time

				LIMIT 1000;
            ";



			using var cmd = new NpgsqlCommand(sql, connection);


			using var reader = cmd.ExecuteReader();


			while (reader.Read())
			{

				lista.Add(new IngresoModel
				{

					Matricula =
					reader["matricula"]?.ToString(),


					PropietarioOficial =
					reader["propietario_oficial"]?.ToString(),


					DNI =
					reader["dni"]?.ToString(),


					HoraIngreso =
					Convert.ToDateTime(reader["hora_ingreso"]),


					HoraSalida =
					reader["hora_salida"] == DBNull.Value
					? null
					: Convert.ToDateTime(reader["hora_salida"]),


					UsuarioManejando =
					reader["usuario_manejando"]?.ToString(),


					AreaDestino =
					reader["area_destino"]?.ToString()


					

				});

			}


			return lista;

		}

	}
}
