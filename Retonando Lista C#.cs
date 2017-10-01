 public List<string> destinatariosEmail()
	{
		string pesquisa = string.Empty;
		bool erro = false;
		erro = OpenDB();
		List<string> adress = new List<string>();

		if (erro != false)
		{
			string sql = "SELECT CRemail AS 'DESTINATARIOS' " +
						 "FROM ContatosRotinas " +
						 "WHERE CRrotina = 'REPASSE BANCO - FAC' " +
						 "AND CRativo = 'S' ";

			SqlCommand Mycmd = new SqlCommand(sql, Myconn);

			using (SqlDataReader read = Mycmd.ExecuteReader())
			{
				while (read.Read())
				{
					pesquisa = read["DESTINATARIOS"].ToString();

					//adicionando cada destinatario da tabela na lista.
					adress.Add(pesquisa);
				}

				CloseDB();

				return adress;
			}

		}
		else
		{
			return null;
		}

	}