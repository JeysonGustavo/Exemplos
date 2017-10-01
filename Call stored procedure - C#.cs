//Exemplo de chamada de stored procedure do postgresql com C#

con.Conn.Open();
con.Comando.CommandType = CommandType.StoredProcedure;
con.Comando.CommandText = "inserefuncionario";

comando.Parameters.AddWithValue("nome", obj.Nome);
comando.Parameters.AddWithValue("datanasc", obj.Datanasc);
comando.Parameters.AddWithValue("rg", obj.Rg);
(...)

int retorno = (int)con.Comando.ExecuteScalar();

//exemplo de uso
#region[5 - STORED PROCEDURE]
		public bool storedProcedure()
		{
			bool erro;
            erro = OpenDB();
			
			NpgsqlCommand myCommand = myConn.CreateCommand();
			
			NpgsqlTransaction tran = myConn.BeginTransaction();
			
			NpgsqlCommand npgsql;
			npgsql = new NpgsqlCommand("storedProcedureDB", myConn);
			myConn.CommandType = CommandType.StoredProcedure;
			
			myConn.Parameters.AddWithValue("nome", obj.Nome);
			myConn.Parameters.AddWithValue("datanasc", obj.Datanasc);
			myConn.Parameters.AddWithValue("rg", obj.Rg);
			
			/*execute escalar para insert, update e delete
			  para select mudar o comando ExecuteScalar por
			  ExecuteReader e usar o comando: 
			  NpgsqlDataReader dr = command.ExecuteReader();.
			*/
			int retorno = (int)con.Comando.ExecuteScalar();
			
			if(retorno > 0)
			{
				tran.Commit();
				return true;
			}
			else
			{
				tran.Rollback();
				return false;
			}
		}
		
		#endregion