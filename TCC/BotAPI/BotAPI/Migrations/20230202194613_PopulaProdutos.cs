using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            //mb.Sql("Insert into produtos(Valor, Descricao, DataDaCaptura) Values(10000.45, 'Tagima WD 45', '2023/02/02')");
            //mb.Sql("Insert into produtos(Valor, Descricao, DataDaCaptura) Values(1200.00, 'Stringberg X 17', '2023/02/02')");
            //mb.Sql("Insert into produtos(Valor, Descricao, DataDaCaptura) Values(19000.99, 'Fender Classic 78', '2023/02/02')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
