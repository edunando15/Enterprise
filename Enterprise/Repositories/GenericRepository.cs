using Microsoft.EntityFrameworkCore;
using Model.Context;

namespace Model.Repositories
{
    public class GenericRepository<T> where T : class
    {

        protected MyDbContext _context;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method used to obtain a certain entity.
        /// </summary>
        /// <param name="id"> The Id of the Entity. </param>
        /// <returns>The Entity if it exists, null otherwise. </returns>
        public virtual async Task<T?> Get(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Method used to insert an entity.
        /// </summary>
        /// <param name="entity"> The entity to add. </param>
        public virtual async void Insert(T entity)
        {
            await _context.AddAsync(entity);
        }

        /// <summary>
        /// Method used to modify an entity.
        /// </summary>
        /// <param name="entity"> The entity that will be modified o </param>
        public virtual void Modify(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }


    }
}
