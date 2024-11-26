using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_WebAPI.Persistance
{
    public class Repository<T> : IRepository<T> where T : Model, ICloneable<T>
    {
        private List<T> _list = new List<T>();
        public async Task Add(T o) // create operation
        {
            _list.Add(o);
        }

        public async Task Delete(Guid id) // remove operation
        {
            var entity = _list.Find(x => x.Id == id); 
            if (entity is not null)
            {
                _list.Remove(entity);
            }
        }

        public async Task<List<T>> GetAll() // read all operation
        {
            return _list.Select(x => x.Clone()).ToList();
        }

        public async Task<T> GetById(Guid id) // read specific item by id
        {
            return _list.Find(x => x.Id == id).Clone();
        }

        public async Task Update(T o) // update operation
        {
            var entity = _list.Find(x => x.Id == o.Id);
            if (entity is not null)
            {
                _list.Remove(entity);
                entity = o;
                _list.Add(entity);
            }
        }
    }
}
