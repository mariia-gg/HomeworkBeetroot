using LibraryEntities;
using Newtonsoft.Json;

namespace LibraryDataAccess;

internal class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
{
    private const string FilePathTemplate = @"C:\LibraryDbFolder\lib.json_{0}";

    private readonly string _filePath = string.Format(FilePathTemplate, nameof(TEntity));
    private readonly List<TEntity> _storage;

    public Repository() => _storage = ReadStorage();

    public List<TEntity> GetAll() => _storage;
    
    public TEntity? Get(int id) => _storage.FirstOrDefault(ent => ent.Id == id);

    public void Insert(TEntity entity)
    {
        entity.Id = _storage.Count;

        _storage.Add(entity);
        SaveStorage(_storage);
    }

    private List<TEntity> ReadStorage()
    {
        try
        {
            var text = File.ReadAllText(_filePath);

            var entities = JsonConvert.DeserializeObject<List<TEntity>>(text);

            return entities ?? new List<TEntity>();
        }
        catch
        {
            return new List<TEntity>();
        }
    }

    private void SaveStorage(List<TEntity> entities)
    {
        var text = JsonConvert.SerializeObject(entities);

        File.WriteAllText(_filePath, text);
    }
}