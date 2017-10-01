public DataTable returnRepasse()
        {
            //Log.CreateFileLog();

            DataTable dt = new DataTable();
            string erro = string.Empty;

            StringBuilder sql = new StringBuilder();

            /*
           SELECT QUE RETORNA OS DADOS DA VIEW DO BD
            */
            sql.AppendLine(" SELECT  ");
            sql.AppendLine(" [DATA RELATORIO], ");
            sql.AppendLine(" 'MODO DEB CRED AUT' = ISNULL(LTRIM(RTRIM([MODO DEB CRED AUT])), ' '), ");
            sql.AppendLine(" 'MODO DEB CRED CAD' = ISNULL(LTRIM(RTRIM([MODO DEB CRED CAD])), ' '), ");
            sql.AppendLine(" 'NR REPASSE' = ISNULL(LTRIM(RTRIM([NR REPASSE])), ' '), ");
            sql.AppendLine(" 'CONTA DIRECTFACIL' = ISNULL(LTRIM(RTRIM([CONTA DIRECTFACIL])), ' '), ");
            sql.AppendLine(" 'NOME' = ISNULL(LTRIM(RTRIM([NOME])), ' '), ");
            sql.AppendLine(" 'FANTASIA' = ISNULL(LTRIM(RTRIM([FANTASIA])), ' '), ");
            sql.AppendLine(" 'SOCIAL' = ISNULL(LTRIM(RTRIM([SOCIAL])), ' '), ");
            sql.AppendLine(" 'CIDADE' = ISNULL(LTRIM(RTRIM([CIDADE])), ' '), ");
            sql.AppendLine(" 'UF' = ISNULL(LTRIM(RTRIM([UF])), ' '), ");
            sql.AppendLine(" 'DT SOLICITACAO' = ISNULL(LTRIM(RTRIM([DT SOLICITAÇÃO])), ' '), ");
            sql.AppendLine(" 'DT PREVISAO' = ISNULL(LTRIM(RTRIM([DT PREVISÃO])), ' '), ");
            sql.AppendLine(" 'VALOR' = ISNULL(LTRIM(RTRIM([VALOR])), ' '), ");
            sql.AppendLine(" 'BANCO REP.' = ISNULL(LTRIM(RTRIM([BANCO REP.])), ' '), ");
            sql.AppendLine(" 'AGENCIA REP.' = ISNULL(LTRIM(RTRIM([AGENCIA REP.])), ' '), ");
            sql.AppendLine(" 'CONTA REP.' = ISNULL(LTRIM(RTRIM([CONTA REP.])), ' '), ");
            sql.AppendLine(" 'TIPO CONTA REP.' = ISNULL(LTRIM(RTRIM([TIPO CONTA REP.])), ' '), ");
            sql.AppendLine(" 'DOC FAVORECIDO' = ISNULL(LTRIM(RTRIM('''' + [DOC FAVORECIDO])), ' '), ");
            sql.AppendLine(" 'DADOS ALTERADOS?' = CASE ");
            sql.AppendLine(" 					 WHEN (LTRIM(RTRIM([DADOS ALTERADOS?]))) = 'NÃO' ");
            sql.AppendLine(" 					 THEN 'NAO' ");
            sql.AppendLine(" 					 WHEN (LTRIM(RTRIM([DADOS ALTERADOS?]))) = 'SIM' ");
            sql.AppendLine(" 					 THEN 'SIM' ");
            sql.AppendLine(" 					 ELSE 'INDEFINIDO' ");
            sql.AppendLine(" 					 END, ");
            sql.AppendLine(" 'BANCO CAD.' = ISNULL(LTRIM(RTRIM([BANCO CAD.])),' '), ");
            sql.AppendLine(" 'AGENCIA CAD.' = ISNULL(LTRIM(RTRIM([AGENCIA CAD.])), ' '), ");
            sql.AppendLine(" 'CONTA CAD.' = ISNULL(LTRIM(RTRIM([CONTA CAD.])), ' '), ");
            sql.AppendLine(" 'TIPO CONTA CAD.' = ISNULL(LTRIM(RTRIM([TIPO CONTA CAD.])), ' ') ");
            sql.AppendLine(" FROM [DF_Rel_RepassesFacilitador] ");
            sql.AppendLine(" ORDER BY [DT PREVISÃO] DESC, [BANCO REP.] DESC, [CONTA DIRECTFACIL] DESC ");




            if (OpenDB())
            {
                //executando a consulta
                SqlDataAdapter adoDA = new SqlDataAdapter(sql.ToString(), Myconn);

                try
                {
                    //jogando o resultado para o dataTable
                    adoDA.Fill(dt);

                    //Desloca o SqlAdapter
                    adoDA.Dispose();

                    Log.WriteInLog("=== Regitros econtrados");

                    //retorna o resultado do select
                    return dt;
                }
                catch (Exception e)
                {
                    //se der erro retorna mostra o erro e retorna null
                    erro = e.ToString();
                    Log.WriteInLog("=== Falha ao econtrar registros");
                    return null;
                }
                finally
                {
                    //fecha a conexao com o BD independente de erro ou sucesso na conexão
                    CloseDB();
                }

            }
            else
            {
                return null;
            }
