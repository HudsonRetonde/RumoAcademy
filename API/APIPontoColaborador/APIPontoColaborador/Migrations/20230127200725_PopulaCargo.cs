using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPontoColaborador.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Cargos(DescricaoCargo) Values(Diretoria')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('LiderTecinoco')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('Gestao')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('RH')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('Desenvolvedor')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('Assistente')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('ServicosGerais')");
            mb.Sql("Insert into Cargos(DescricaoCargo) Values('Estagiario')");
        }
        
        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Cargo");
        }
    }
}
