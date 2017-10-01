class CDB
    {
        static string serverName = "127.0.0.1";                                          //localhost
        static string port = "5432";                                                            //porta default
        static string userName = "name";                                               //nome do administrador
        static string password = "password";                                             //senha do administrador
        static string databaseName = "yourdatabase";                                       //nome do banco de dados
        NpgsqlConnection myConn = null;
        string connString = null;

        #region[1 - CONSTRUTOR]
        public CDB()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                serverName, port, userName, password, databaseName);
        }
        #endregion

        #region[2 - CONECTAR BANCO DE DADOS]
        public bool OpenDB()
        {
            string erro = string.Empty;

            try
            {
                myConn = new NpgsqlConnection(connString);

                myConn.Open();
            }
            catch (Exception Ex)
            {
                erro = Ex.Message.ToString();
            }

            if (myConn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region[3 - DESCONECTAR BANCO DE DADOS]
        public bool CloseDB()
        {

            string erro = string.Empty;

            myConn = new NpgsqlConnection(connString);

            myConn.Close();

            if (myConn.State == ConnectionState.Open)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region[4 - INSERIR PAGAMENTOS]
        public bool inserirDados(string nome_conta, int qtde_parcela)
        {
            bool erro;
            erro = OpenDB();

            NpgsqlCommand myCommand = myConn.CreateCommand();

            // transaction = myConn.BeginTransaction();

            myCommand.Connection = myConn;

            try
            {
                string query = "INSERT INTO tb_contas(nome_conta, qtde_parcelas, fg_ativo) " +
                               "VALUES(@nome_conta, @qtde_parcela, 1);";

                NpgsqlCommand npgsql;
                npgsql = new NpgsqlCommand(query, myConn);

                npgsql.Parameters.Add(new NpgsqlParameter("@nome_conta", nome_conta));
                npgsql.Parameters.Add(new NpgsqlParameter("@qtde_parcelas", qtde_parcela));
                npgsql.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {

                return false;

            }
            finally
            {
                CloseDB();
            }

        }
        #endregion
	}