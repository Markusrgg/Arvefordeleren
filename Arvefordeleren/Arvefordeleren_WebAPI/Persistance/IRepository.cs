using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_WebAPI.Persistance
{
    //Generisk interface 
    public interface IRepository<T> where T : Model, ICloneable<T>
    {

        //Metode der er ansvarlig for at tilføje objekt af typen T 
        //Returnerer Task = asynkon 
        public Task Add(T o);

        //Returnerer en asynkron opgave indeholder listen 
        public Task<List<T>> GetAll();


        public Task<T> GetById(Guid id);
        public Task Update(T o);
        public Task Delete(Guid id);
    }
}
