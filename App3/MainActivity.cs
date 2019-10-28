using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using App3.Database;
using App3.Resources;

namespace App3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        private RecyclerView ListItem { get; set; }
        private EntityListAdapter ListAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SingletonEntity.Instance.GenerateFixtures(30);

            base.OnCreate(savedInstanceState);

            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            ListItem.SetLayoutManager(layoutManager);
            ListItem.SetAdapter(ListAdapter);
            ListItem.SetItemViewCacheSize(0);

            ListAdapter.NotifyDataSetChanged();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void InitComponents()
        {
            ListItem = this.FindViewById<RecyclerView>(Resource.Id.rv_items);
            ListAdapter = new EntityListAdapter(SingletonEntity.Instance.FindAll(), this);
        }

        public override void InitEvents()
        {
        }

        public override int GetContentView()
        {
            return Resource.Layout.activity_main;
        }
    }
}

