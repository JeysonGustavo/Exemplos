//fazendo um distinct em um data table do c#

DataTable dt = new DataTable();
            
dt = cdb.seuMetodo();

DataView view = new DataView(dt);

//seta o distinct para TRUE, e passa o CAMPO que deseja fazer o Distict
DataTable dt2 = view.ToTable(true, "CAMPO");