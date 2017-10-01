using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SQLInjection
/// </summary>
public class Injection
{
    public string protegeInjection(string valida)
    {
        
        if (valida == string.Empty || valida == "")
            return valida;

        string trocar = valida;

        //Valores a serem substituidos
        trocar = trocar.Replace("'", "");
        trocar = trocar.Replace("--", "");
        trocar = trocar.Replace("/*", "");
        trocar = trocar.Replace("*/", "");
        trocar = trocar.Replace(" or ", "");
        trocar = trocar.Replace(" OR ", "");
        trocar = trocar.Replace("'or", "");
        trocar = trocar.Replace("'OR", "");
        trocar = trocar.Replace(" and ", "");
        trocar = trocar.Replace(" AND ", "");
        trocar = trocar.Replace("'and'", "");
        trocar = trocar.Replace("'AND'", "");
        trocar = trocar.Replace("update", "");
        trocar = trocar.Replace("UPDATE", "");
        trocar = trocar.Replace("'update'", "");
        trocar = trocar.Replace("'UPDATE'", "");
        trocar = trocar.Replace("-shutdown", "");
        trocar = trocar.Replace("-SHUTDOWN", "");
        trocar = trocar.Replace("'-shutdown'", "");
        trocar = trocar.Replace("'-SHUTDOWN'", "");
        trocar = trocar.Replace("--", "");
        trocar = trocar.Replace("'or'1'='1'", "");
        trocar = trocar.Replace("'OR'1'='1'", "");
        trocar = trocar.Replace("insert", "");
        trocar = trocar.Replace("INSERT", "");
        trocar = trocar.Replace("'insert'", "");
        trocar = trocar.Replace("'INSERT'", "");
        trocar = trocar.Replace("drop", "");
        trocar = trocar.Replace("delete", "");
        trocar = trocar.Replace("DROP", "");
        trocar = trocar.Replace("DELETE", "");
        trocar = trocar.Replace("xp_", "");
        trocar = trocar.Replace("sp_", "");
        trocar = trocar.Replace("select", "");
        trocar = trocar.Replace("SELECT", "");
        trocar = trocar.Replace("1 union select", "");
        trocar = trocar.Replace("1 UNION SELECT", "");
        trocar = trocar.Replace(";","");
        trocar = trocar.Replace(",", "");
        trocar = trocar.Replace("1 = 1", "");
        trocar = trocar.Replace("'1 = 1'","");
        trocar = trocar.Replace("1=1", "");
        trocar = trocar.Replace("'1=1'", "");
        trocar = trocar.Replace("create","");
        trocar = trocar.Replace("alter", "");
        trocar = trocar.Replace("CREATE", "");
        trocar = trocar.Replace("ALTER", "");
        trocar = trocar.Replace("' or '1' = '1", "");
        trocar = trocar.Replace("' OR '1' = '1", "");
        trocar = trocar.Replace("'or'1' = '1", "");
        trocar = trocar.Replace("'OR'1' = '1", "");
        trocar = trocar.Replace(" or '1' = '1'", "");
        trocar = trocar.Replace(" OR '1' = '1'", "");
        trocar = trocar.Replace("or'1' = '1'", "");
        trocar = trocar.Replace("OR'1' = '1'", "");

        //Retorna o valor com as devidas alterações
        return trocar;

    }
}