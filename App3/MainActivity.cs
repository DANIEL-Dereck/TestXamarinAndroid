using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
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
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        private Button btnCancel;
        private Button btnValidate;
        private RecyclerView rvItems;
        private EntityListAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SingletonEntity.Instance.GenerateFixtures(30);

            base.OnCreate(savedInstanceState);

            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            rvItems.SetLayoutManager(layoutManager);
            rvItems.SetAdapter(listAdapter);
            rvItems.SetItemViewCacheSize(0);

            listAdapter.NotifyDataSetChanged();
        }

        public override void InitComponents()
        {
            this.btnCancel = this.FindViewById<Button>(Resource.Id.btn_cancel);
            this.btnValidate = this.FindViewById<Button>(Resource.Id.btn_validate);
            rvItems = this.FindViewById<RecyclerView>(Resource.Id.rv_items);
            listAdapter = new EntityListAdapter(SingletonEntity.Instance.FindAll(), this);
        }

        public override void InitEvents()
        {
            this.btnCancel.Click += (sender, e) =>
            {
                this.OnBackPressed();
            };

            this.btnValidate.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(TabsActivity));
                this.StartActivity(intent);
            };
        }

        public override int GetContentView()
        {
            return Resource.Layout.activity_main;
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (listAdapter != null)
            {
                listAdapter.NotifyDataSetChanged();
            }
        }
    }
}

