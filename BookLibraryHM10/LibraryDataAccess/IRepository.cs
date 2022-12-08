namespace LibraryDataAccess;

public interface IRepository<TEntity>
{
    public List<TEntity> GetAll();

    public TEntity? Get(int id);
    
    public void Insert(TEntity entity);
}