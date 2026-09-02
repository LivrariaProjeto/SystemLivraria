namespace SystemLivraria.data
{


    partial class DataSet2
    {
        partial class UsuariosDataTable
        {
        }
    }
}
//GetData() -> para retornar todos os registros da tabela 
//GetDataBy() -> para retornar um registro específico da tabela -> GetDataBy(@Login, @Senha)
//Fill() -> para preencher um DataTable com todos os registros da tabela -> para incluir algo em uma tabela já existente
//Login -> vamos usar o GetDataBy(), porque queremos receber o resultado da consulta e verificar se encontrou um usuário.
namespace SystemLivraria.data.DataSet2TableAdapters
{


    public partial class UsuariosTableAdapter
    {
    }
}
