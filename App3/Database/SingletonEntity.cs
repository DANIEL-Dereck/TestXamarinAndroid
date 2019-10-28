using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App3.Database
{
    public class SingletonEntity
    {
        private static SingletonEntity instance;
        private static List<Entity> items;

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

        private SingletonEntity()
        {

        }

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

            if (isInsert && num != null)
            {
                items.Find(x => x.Num == num).Ess = entity.Ess;
                items.Find(x => x.Num == num).Diam1 = entity.Diam1;
                items.Find(x => x.Num == num).Diam2 = entity.Diam2;
            }
            else { 
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

        public void GenerateFixtures(int max)
        {
            if (items.Count <= 0)
            {
                items = new List<Entity>();

                for (int i = 0; i < max; i++)
                {
                    Entity item = new Entity()
                    {
                        Num = i,
                        Ess = $"Ess{i}",
                        Diam1 = (int)(i + 3.14f * i),
                        Diam2 = (int)(i + 3.14f * i),
                    };

                    items.Add(item);
                }
            }
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}