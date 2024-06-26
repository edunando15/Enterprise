﻿using Microsoft.EntityFrameworkCore;
using Model.Context;

namespace Model.Repositories
{
    public class GenericRepository<T> where T : class
    {

        protected LibraryContext _context;

        public GenericRepository(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method used to obtain a certain entity.
        /// </summary>
        /// <param name="id"> The Id of the Entity. </param>
        /// <returns>The Entity if it exists, null otherwise. </returns>
        public virtual T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T? Get(T entity)
        {
            return _context.Set<T>().Find(entity);
        }

        /// <summary>
        /// Method used to insert an entity.
        /// </summary>
        /// <param name="entity"> The entity to add. </param>
        public virtual void Insert(T entity)
        {
            _context.Add(entity);
        }

        /// <summary>
        /// Method used to modify an entity.
        /// </summary>
        /// <param name="entity"> The entity that will be modified o </param>
        public virtual void Modify(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            _context.Entry(id).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual bool Exists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }


    }
}
