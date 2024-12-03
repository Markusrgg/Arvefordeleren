using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_WebAPI.Persistance
{
    public class Repository<T> : IRepository<T> where T : Model, ICloneable<T>
    {

        //opretter intern liste til at holde objekter af typen T 
        private List<T> _list = new List<T>();

        public async Task Add(T o) // create operation
        {
            _list.Add(o);
        }

        public async Task Delete(Guid id) 
        {
            var entity = _list.Find(x => x.Id == id); //finder objektet i listen der har det ønskede id 
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
                _list.Remove(entity);//Fjern det gamle objekt fra listen 
                entity = o;//Erstat det gamle objekt med det nye 
                _list.Add(entity);//tilføj det nye objekt til listen 
            }
        }
    }
}
