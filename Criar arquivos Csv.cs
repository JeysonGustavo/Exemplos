using SegurancaLicitacao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCRotinaRepasseBanco.Util
{
    public class Csv
    {
        public string exportarTable(DataTable dt)
        {
            CDB cdb = new CDB();

            dt = cdb.returnRepasse();

            StringBuilder sb = new StringBuilder();

                //adicionando as colunas
                for (int coluna = 0; coluna < dt.Columns.Count; coluna++)
                {
                    sb.Append(dt.Columns[coluna].ColumnName);
                    if(coluna != dt.Columns.Count - 1)
                    {
                        sb.Append(";");
                    }
                else
                {
                    sb.AppendLine();
                }
            }

            //Escreve os dados
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                for (int coluna = 0; coluna <= dt.Columns.Count; coluna++)
                {
                    if (coluna <= dt.Columns.Count - 1){
                        //Se ainda não chegou na ultima coluna, significa que tem dados, entao escreve os dados e concatena com um separador (;)
                        sb.Append(dt.Rows[row][coluna]);
                        sb.Append(";");
                    }
                    else
                    {
                        //Se chegar no final das colunas, adc uma quebra de linhas
                        sb.AppendLine();
                    }
                }

            }
            string caminhoArquivo = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) +
                                    "\\RepasseFacilitador" + DateTime.Now.Year.ToString() + "-" +
                                    DateTime.Now.Month.ToString("D2") + "-" + DateTime.Now.Day.ToString("D2") + ".csv";

            File.WriteAllText(caminhoArquivo, sb.ToString());

            return sb.ToString();

           
        }
    }
}
