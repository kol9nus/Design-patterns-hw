using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.Models.Interfaces;

namespace Homework4.FirstOrmLibrary
{
    public class FirstOrm<TDbEntity> : IFirstOrm<TDbEntity> where TDbEntity : IDbEntity
    {
        private List<TDbEntity> entities = new List<TDbEntity>();

        public void Create(TDbEntity entity)
        {
            entities.Add(entity);
        }

        TDbEntity IFirstOrm<TDbEntity>.Read(int id)
        {
            if (entities.Count != 0)
                return entities.First(entity => entity.Id == id);
            return default(TDbEntity);
        }

        public void Update(TDbEntity entity)
        {
            int entityIndex = entities.FindIndex(e => e.Id == entity.Id);
            entities[entityIndex] = entity;
        }

        public void Delete(TDbEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
