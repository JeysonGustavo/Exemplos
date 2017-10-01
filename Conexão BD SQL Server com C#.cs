 private SqlConnection Myconn;
        private SqlCommand Mycmd;

        #region[1 - STRING DE CONEXÃO COM O BANCO]
        public SqlConnection returnMyconn()
        {
            string conexao = ("user id=userreadonly; " +
                              "password=28-0bHnv*C;Network Address=189.90.130.95; " +
                              "Persist Security Info=true; " +
                              "database=DIRECTFACIL; " +
                              "connection timeout=300");

            //LOCAL
            //string conexao = ("Data Source=(local);Initial Catalog=DIRECTFACIL;Integrated Security=True");

            this.Myconn = new SqlConnection(conexao);

            return this.Myconn;
        }
        #endregion

        #region[2 - CONEXÃO COM O BANCO DE DADOS]
        public bool OpenDB()
        {
            Log.CreateFileLog();

            string erro = string.Empty;
            this.Myconn = returnMyconn();

            try
            {
                Myconn.Open();
            }
            catch (Exception e)
            {
                erro = e.ToString();
            }

            if (Myconn.State == ConnectionState.Open)
            {
                Log.WriteInLog("=== Conexão com o banco Aberta");
                return true;
            }
            else
            {
                Log.WriteInLog("=== Erro de Conexão com o banco.");
                return false;
            }
        }
        #endregion

        #region[3 - DESCONCTAR BANCO DE DADOS]
        public bool CloseDB()
        {
           // Log.CreateFileLog();

            string erro = string.Empty;
            this.Myconn = returnMyconn();

            if (Myconn.State == ConnectionState.Open)
            {
                Log.WriteInLog("=== Erro ao desconctar banco de dados");
                return false;
            }
            else
            {
                Log.WriteInLog("=== Banco desconectado");
                return true;
            }
        }
        #endregion