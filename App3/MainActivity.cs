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
using App3.Resources;

namespace App3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public List<Entity> Items { get; set; }
        private RecyclerView ListItem { get; set; }
        private EntityListAdapter ListAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            GenerateFixtures();

            ListItem = this.FindViewById<RecyclerView>(Resource.Id.rv_items);
            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            ListAdapter = new EntityListAdapter(Items);

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

        /// <summary>
        /// Generate fake data and put them into the list.
        /// </summary>
        private void GenerateFixtures()
        {
            this.Items = new List<Entity>();

            for (int i = 0; i < 30; i++)
            {
                Entity item = new Entity()
                {
                    Num = i,
                    Ess = $"Ess{i}",
                    Diam1 = i + 10 * i,
                    Diam2 = i + 10 * i,
                };

                this.Items.Add(item);
            }
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

