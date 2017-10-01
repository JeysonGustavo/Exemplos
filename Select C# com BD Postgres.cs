 public string verificaUsuario(string nome)
	{
		bool erro;
		erro = OpenDB();
		string pesquisa = String.Empty;

		string query = "SELECT nome_login AS NOME " +
						  "FROM tb_login " +
						  "WHERE nome_login = @nome";

		NpgsqlCommand npgsql = new NpgsqlCommand(query, myConn);

		npgsql.Parameters.Add(new NpgsqlParameter("@nome", nome));

		using (NpgsqlDataReader read = npgsql.ExecuteReader())
		{
			while (read.Read())
			{
				pesquisa = read["NOME"].ToString();
			}

			CloseDB();

			return pesquisa;
		}
	}