using System;
using System.Collections.Generic;

public interface IDataRepository<TEntity, TDto>
{
    IEnumerable<TEntity> getAll();
    TEntity Get(long id);
    TDto GetTDto(long id);
    void Add(TEntity entity);
    void Update(TEntity entityToUpdate, TEntity entity);
    void Delete(TEntity entity);
}