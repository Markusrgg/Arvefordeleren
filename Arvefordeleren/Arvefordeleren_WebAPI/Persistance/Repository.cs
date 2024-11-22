﻿using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_WebAPI.Persistance
{
    public class Repository<T> : IRepository<T> where T : Model
    {
        private List<T> _list = new List<T>();
        public async Task Add(T o) // create operation
        {
            _list.Add(o);
        }

        public async Task Delete(T o) // remove operation
        {
            var entity = _list.Find(x => x.Id == o.Id); 
            if (entity is not null)
            {
                _list.Remove(entity);
            }
        }

        public async Task<List<T>> GetAll() // read all operation
        {
            return _list;
        }

        public async Task<T> GetById(Guid id) // read specific item by id
        {
            return _list.Find(x => x.Id == id);
        }

        public async Task Update(T o) // update operation
        {
            var entity = _list.Find(x => x.Id == o.Id);
            if (entity is not null)
            {
                entity = o;
            }
        }
    }
}