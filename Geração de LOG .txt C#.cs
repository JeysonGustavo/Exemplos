using SegurancaLicitacao.Model;
using System;
using System.IO;

namespace WinCRotinaRepasseBanco.Util
{
    internal class Log
    {
        public static readonly string _caminhoArquivo =
            Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\LogRepasseBanco" +
            DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("D2") + ".txt";

        #region [ Cria arquivo ]

        public static string CreateFileLog()
        {
            //Pega diretorio atual e concatena com o nome do arquivo

            //Se nao existe, cria o arquivo
            if (!System.IO.File.Exists(_caminhoArquivo))
            {
                System.IO.File.Create(_caminhoArquivo).Close();
            }

            //Abre o arquivo para a escrita
            System.IO.TextWriter arquivo = System.IO.File.AppendText(_caminhoArquivo);
            
            arquivo.Close();

            //Retorna o caminho do arquivo de log
            return _caminhoArquivo;
        }

        #endregion

        #region [ Escreve informacoes no arquivo ]

        public static bool WriteInLog(string textoLog)
        {
            try
            {
                //Cria mensagem de log
                var mensagem = DateTime.Now.ToString("G") + " | " + textoLog;

                //Escreve na tela (console)
                System.Console.WriteLine(mensagem);


                //Abre o arquivo para a escrita
                System.IO.TextWriter arquivo = System.IO.File.AppendText(_caminhoArquivo);
                //Escreve no arquivo
                arquivo.WriteLine(mensagem);
                //Fecha o arquivo
                arquivo.Close();

                return true;
            }
            catch (Exception e) //Ocorreu algum erro na escrita do arquivo, portanto retorna false
            {
                return false;
            }
        }

        #endregion

        public static string TestaConexaoBase()
        {
            CDB conexaoCdb = new CDB();
            var statusConexao = conexaoCdb.OpenDB();
            conexaoCdb.CloseDB();
            return statusConexao.ToString();
        }

        internal class DataTable
        {
        }
    }
}