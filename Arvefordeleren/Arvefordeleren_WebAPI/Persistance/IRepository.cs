using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_WebAPI.Persistance
{
    public interface IRepository<T> where T : Model
    {
        public Task Add(T o);
        public Task<List<T>> GetAll();
        public Task<T> GetById(Guid id);
        public Task Update(T o);
        public Task Delete(Guid id);
    }
}
