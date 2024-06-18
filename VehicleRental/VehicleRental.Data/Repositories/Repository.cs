﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Domain.Repositories;

namespace VehicleRental.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        protected DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbSet = dbContext.Set<T>();
        }

        public void Add (T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        public void Update(int id, T entity)
        {
            var existingEntity = _dbSet.Find(id);
            if (existingEntity != null)
            {
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var newValue = property.GetValue(entity);
                    var oldValue = property.GetValue(existingEntity);
                    var propertyName = property.Name; // Obtém o nome da propriedade

                    // Verifica se o novo valor não é nulo e é diferente do valor existente
                    if (newValue != null && !newValue.Equals(oldValue))
                    {
                        // Verifica se o novo valor não é zero (para tipos numéricos)
                        if (!IsZero(newValue))
                        {
                            property.SetValue(existingEntity, newValue);
                            _dbContext.Entry(existingEntity).Property(propertyName).IsModified = true;
                        }
                    }
                }
                _dbContext.SaveChanges();
            }
        }


        public void Delete (int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A entidade com o ID fornecido não foi encontrado.");
            }
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public T GetByName(string name) => _dbSet.SingleOrDefault(entity => EF.Property<string>(entity, "name") == name);

        public T GetByPlate(string plate) => _dbSet.SingleOrDefault(entity => EF.Property<string>(entity, "plate") == plate);

        public T GetByDocument(string document) => _dbSet.SingleOrDefault(entity => EF.Property<string>(entity, "document") == document);

        public T GetByCnh(string cnh) => _dbSet.SingleOrDefault(entity => EF.Property<string>(entity, "cnh") == cnh);

        public async Task<List<T>> FindByConditionAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression) =>
                                                        await _dbSet.Where(expression).ToListAsync();

        private bool IsZero(object value)
        {
            if (value is int intValue)
            {
                return intValue == 0;
            }
            else if (value is double doubleValue)
            {
                return doubleValue == 0.0;
            }

            return false;
        }

    }
}
