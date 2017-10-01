 public class TesteController : ApiController
    {
        private CDB cdb;

		//usar sempre o Http e a ActionName, route não é necessário
        [HttpGet]
        [ActionName("Teste")]
        //[Route("Teste")]
		/*exemplo da chamada desse método na URL localhost:63535/Teste/Teste
		o Id é escrito no body em JSON, exemplo escrevendo o parametro no body:
		{
			"Id" : "123"
		}
		
		
		*/
        public PessoaModel Teste([FromBody] int id)//[FromBody] é usado para escrever no corpo
        {
            PessoaModel p = new PessoaModel();
            p.id = id;
            p.nome = "JEYSON";
            p.sobrenome = "GOMES";

            return p;

        }

        [HttpGet]
        [ActionName("Novo")]
        public PessoaModel Novo([FromBody] int id)
        {
            PessoaModel p = new PessoaModel();
            p.id = id;
            p.nome = "GUSTAVO";
            p.sobrenome = "PERES";

            return p;

        }

		//todo POST deverá ser passado no Body[FromBody]
        [HttpPost]
        [ActionName("Inserir")]
        public bool Inserir([FromBody] PessoaModel pessoa)
        {
            cdb = new CDB();

            bool retorno = cdb.InserirPessoa(pessoa);

            if (retorno)
                return true;
            else
                return false;
        }

        [HttpGet]
        [ActionName("ValidarLogin")]
		/*
			método sem o [FromBody] vai ser passado no parametro na URL, exemplo
			
			//nesse exemplo Teste é o nome do controller, ValidarLogin é Action(Método)
			que eu quero chamar, como tenho parametro uso o ?, em seguida coloco o nome
			do parametro=ValorDoParametro, como tenho dois parametros tenho que colocar
			o & para informar o proximo parametro
			localhost:63535/Teste/ValidarLogin?conta=174667&abc=777
		*/
        public DataTable ValidarLogin(string conta, string abc)
        {
            DataTable dt = new DataTable();

            cdb = new CDB();

            dt = cdb.VerificaPermissao(conta);

            return dt;
        }
    }