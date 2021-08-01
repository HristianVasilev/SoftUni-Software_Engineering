namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Data : IRepository
    {
        private List<IEntity> entities;

        public Data()
        {
            this.entities = new List<IEntity>();
        }

        public int Size => this.entities.Count;

        public void Add(IEntity entity)
        {
            int parentIndex = ((this.Size - 1) - 1) / 2;

            if (ValidIndex(parentIndex))
            {
                this.entities[parentIndex].AddChild(entity);
            }

            this.entities.Add(entity);

            HeapifyUp(this.Size - 1);
        }


        public IRepository Copy()
        {
            IRepository repository = CopyRepository();

            return repository;
        }

        public List<IEntity> GetAll()
        {
            return this.entities;
        }

        public List<IEntity> GetAllByType(string type)
        {
            Type[] types = typeof(IEntity).Assembly.GetTypes();

            Type currentType = GetTypeIfExists(types, type);

            if (currentType == null)
            {
                throw new InvalidOperationException($"Invalid type: {type}");
            }

            List<IEntity> result = new List<IEntity>();

            foreach (var entity in this.entities)
            {
                if (entity.GetType().Name == type)
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        public IEntity GetById(int id)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Id.Equals(id))
                {
                    return this.entities[i];
                }
            }

            return null;
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Id.Equals(parentId))
                {
                    return this.entities[i].Children;
                }
            }

            return null;
        }

        public IEntity PeekMostRecent()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            return this.entities[0];
        }

        public IEntity DequeueMostRecent()
        {
            IEntity entity = this.PeekMostRecent();

            Swap(0, this.Size - 1);
            this.entities.RemoveAt(this.Size - 1);

            HeapifyDown(0);

            return entity;
        }


        private Type GetTypeIfExists(Type[] types, string searchedType)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(searchedType))
                {
                    return types[i];
                }
            }

            return null;
        }

        private void Swap(int index1, int index2)
        {
            IEntity temp = this.entities[index1];
            this.entities[index1] = this.entities[index2];
            this.entities[index2] = temp;
        }

        private IEntity FindEntityByIndex(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                return null;
            }

            return this.entities[index];
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int paretntIndex = (index - 1) / 2;

            if (paretntIndex < 0)
            {
                return;
            }

            IEntity entity = this.entities[index];
            IEntity parent = this.entities[paretntIndex];

            if (entity.CompareTo(parent) < 0)
            {
                Swap(paretntIndex, index);
            }

            HeapifyUp(index - 1);
        }

        private void HeapifyDown(int index)
        {
            if (index == this.Size - 1)
            {
                return;
            }

            IEntity parent = this.entities[index];

            int leftChildIndex = 2 * index + 1;
            IEntity leftChild = FindEntityByIndex(leftChildIndex);

            if (leftChild == null)
            {
                return;
            }

            int rightChildIndex = 2 * index + 2;
            IEntity rightChild = FindEntityByIndex(rightChildIndex);

            int secondIndex;

            if (rightChild == null)
            {
                secondIndex = leftChildIndex;
            }
            else
            {
                if (leftChild.CompareTo(rightChild) < 0)
                {
                    secondIndex = leftChildIndex;
                }
                else
                {
                    secondIndex = rightChildIndex;
                }
            }

            IEntity other = this.entities[secondIndex];

            if (other.CompareTo(parent) < 0)
            {
                Swap(index, secondIndex);
            }

            HeapifyDown(index + 1);
        }

        private IRepository CopyRepository()
        {
            IRepository repository = new Data();

            foreach (var item in this.entities)
            {
                repository.Add(item);
            }

            return repository;
        }

        private bool ValidIndex(int parentIndex)
        {
            return parentIndex >= 0 && parentIndex < this.Size;
        }

    }
}
