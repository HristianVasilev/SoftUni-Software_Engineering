namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }


        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return this.entities.Contains(entity);
        }

        public IEntity Extract(int id)
        {
            IEntity entity = this.entities.Find(x => x.Id.Equals(id));
            this.entities.Remove(entity);

            return entity;
        }

        public IEntity Find(IEntity entity)
        {
            IEntity element = this.entities.Find(x => x.Equals(entity));

            return element;
        }

        public List<IEntity> GetAll()
        {
            return this.entities;
        }


        public void RemoveSold()
        {
            this.entities.RemoveAll(x => x.Status.Equals(BaseEntityStatus.Sold));
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            if (!this.entities.Contains(oldEntity) )
            {
                throw new InvalidOperationException("Entity not found");
            }

            int index = this.entities.IndexOf(oldEntity);
            this.entities[index] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            return this.entities.Where(x => x.Status >= lowerBound && x.Status <= upperBound).ToList();
        }

        public void Swap(IEntity first, IEntity second)
        {
            int firstIndex = this.entities.IndexOf(first);
            int secondIndex = this.entities.IndexOf(second);

            if (firstIndex == -1 || secondIndex == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }

            this.entities[firstIndex] = second;
            this.entities[secondIndex] = first;
        }

        public IEntity[] ToArray()
        {
            return this.entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            foreach (var entity in this.entities)
            {
                if (entity.Status.Equals(oldStatus))
                {
                    entity.Status = newStatus;
                }
            }
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            foreach (var entity in this.entities)
            {
                yield return entity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
