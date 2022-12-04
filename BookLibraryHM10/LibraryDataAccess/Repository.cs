using LibraryEntities;
using Newtonsoft.Json;

namespace LibraryDataAccess
{
    public class Repository<TEntity> : LibraryEntity, IRepository<TEntity> where TEntity : IEntity
        {
            private static readonly string DbFilePathTemplate = @"C:\LibraryDbFolder\lib.json_{0}";
            private static readonly string DbFilePath = string.Format(DbFilePathTemplate, typeof(TEntity));
            private List<TEntity> _storage = ReadStorage();


            public IList<TEntity> GetAll()
            {
                return _storage;
            }

            public TEntity Get(int id)
            {
                var storageEntity = _storage.First(ent => ent.Id == id);

                return storageEntity;
            }

            public void Insert(TEntity entity)
            {
                if (entity.Id <= 0)
                    entity.Id = (_storage.OrderByDescending(ent => ent.Id).FirstOrDefault()?.Id ?? 0) + 1;

                _storage.Add(entity);
                SaveStorage(_storage);
            }

            private static List<TEntity> ReadStorage()
            {
                EnsureDbFile();

                var text = File.ReadAllText(DbFilePath);

                var entities = JsonConvert.DeserializeObject<List<TEntity>>(text);

                return entities ?? new List<TEntity>();
            }

            private static void SaveStorage(List<TEntity> entities)
            {
                var text = JsonConvert.SerializeObject(entities);
                File.WriteAllText(DbFilePath, text);
            }

            private static void EnsureDbFile()
            {
                if (!File.Exists(DbFilePath))
                {
                    using (File.Create(DbFilePath))
                    {

                    }
                }
            }
        }
    }




