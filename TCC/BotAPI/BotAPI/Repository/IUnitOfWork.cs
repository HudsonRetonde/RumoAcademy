namespace BotAPI.Repository
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }

        Task Commit();
    }
}
