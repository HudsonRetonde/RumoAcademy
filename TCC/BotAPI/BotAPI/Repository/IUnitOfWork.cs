namespace BotAPI.Repository
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }

        void Commit();
    }
}
