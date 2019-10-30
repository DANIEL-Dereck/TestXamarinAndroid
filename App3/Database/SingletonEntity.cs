using System;
using System.Collections.Generic;

namespace App3.Database
{
    public class SingletonEntity
    {
        #region Attributs
        private static SingletonEntity instance;
        private static List<Entity> items;
        #endregion

        #region Properties
        /// <summary>
        /// Create or use instance of SingletonEntity.
        /// </summary>
        public static SingletonEntity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonEntity();
                    items = new List<Entity>();
                }
                return instance;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Private constructor. Singleton way.
        /// </summary>
        private SingletonEntity()
        {

        }
        #endregion

        #region Methods

        #region CRUD
        public SingletonEntity InsertOrUpdate(Entity entity)
        {
            bool isInsert = true;
            int? num = -1;

            foreach (Entity item in items)
            {
                if (isInsert && item.Num == entity.Num)
                {
                    num = item.Num;
                    isInsert = false;
                    break;
                }
            }

            if (!isInsert && num != null)
            {
                items.Find(x => x.Num == num).Ess = entity.Ess;
                items.Find(x => x.Num == num).Diam1 = entity.Diam1;
                items.Find(x => x.Num == num).Diam2 = entity.Diam2;
            }
            else
            {
                items.Add(entity);
            }

            return this;
        }

        public SingletonEntity Insert(Entity item)
        {
            items.Add(item);
            return this;
        }

        public SingletonEntity Delete(Entity item)
        {
            items.Remove(item);
            return this;
        }

        public Entity Find(int? num)
        {
            return items.Find(x => x.Num == num);
        }

        public List<Entity> FindAll()
        {
            return items;
        }
        #endregion

        #region UtilsMethods
        /// <summary>
        /// GenerateFixtures.
        /// </summary>
        /// <param name="max">Number of row we want to generate.</param>
        public void GenerateFixtures(int max)
        {
            if (items.Count <= 0)
            {
                items = new List<Entity>();

                for (int i = 0; i < max; i++)
                {
                    Random ran = new Random();

                    items.Add(new Entity(i, $"Ess{i}", (int)(ran.Next(i, 100) * 3.14159265f), (int)(ran.Next(i, 100) * 3.14159265f)));
                }
            }
        }

        /// <summary>
        /// Simulation of ClearTable.
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }
        #endregion
        #endregion
    }
}
