using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WSControl
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSControl : System.Web.Services.WebService {

    CDB cdb = new CDB();

    public WSControl () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region[1 - CADASTRAR NOVO USUARIO]
    [WebMethod]
    public string WScadastrarNovoUsuario(string nome, string cpf, string senha, string email, string ddd, string numTel, string endereco,
                                         Int64 numero, string bairro, string cidade, string estado)
    {
        bool retornoCDB = cdb.InserirNovoUsuario(nome, cpf, senha, email, ddd, numTel, endereco, numero, bairro, cidade, estado);

        if (retornoCDB == true)
        {
            return "OK";
        }
        else
        {
            return "Erro";
        }
    }

    #endregion

    #region[2 - CADASTRAR NOVO LOGIN]
    [WebMethod]
    public string WSCadastrarNovoLogin(string email, string senha, int id_usuario)
    {
        bool retornoCDB = cdb.inserirNovoLogin(email, senha, id_usuario);

        if (retornoCDB == true)
        {
            return "OK";
        }
        else
        {
            return "Erro";
        }
    }
    #endregion

    #region[3 - RETORNAR ID DO USUARIO]
    [WebMethod]
    public int retornaIdUsuario(string email)
    {
        int id_usuario = cdb.retornaIdUsuario(email);

        return id_usuario;
    }
    #endregion

}
