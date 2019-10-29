using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Support.V7.App.ActionBar;

namespace App3
{
    [Activity(Label = "Régénération", Theme = "@style/AppTheme")]
    public class TabsActivity : BaseActivity, ITabListener
    {
        TextView tv1;
        TextView tv2;
        TextView tv3;
        TextView tv4;
        TextView tv5;
        TextView tv6;
        TextView tv7;
        TextView tv8;
        TextView tv9;
        TextView tv10;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SupportActionBar.Title = "Placette 1 - Rayon 22.5";
            SetupTabs();
        }

        private void SetupTabs()
        {
            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Placeau 1")
                .SetTabListener(this),
                0);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Placeau 2")
                .SetTabListener(this),
                1);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Placeau 3")
                .SetTabListener(this),
                2);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Sous-étage")
                .SetTabListener(this),
                3);
        }

        public override int GetContentView()
        {
            return Resource.Layout.activity_tabs;
        }

        public override void InitComponents()
        {
            this.tv1 = this.FindViewById<TextView>(Resource.Id.tv_1);
            this.tv2 = this.FindViewById<TextView>(Resource.Id.tv_2);
            this.tv3 = this.FindViewById<TextView>(Resource.Id.tv_3);
            this.tv4 = this.FindViewById<TextView>(Resource.Id.tv_4);
            this.tv5 = this.FindViewById<TextView>(Resource.Id.tv_5);
            this.tv6 = this.FindViewById<TextView>(Resource.Id.tv_6);
            this.tv7 = this.FindViewById<TextView>(Resource.Id.tv_7);
            this.tv8 = this.FindViewById<TextView>(Resource.Id.tv_8);
            this.tv9 = this.FindViewById<TextView>(Resource.Id.tv_9);
            this.tv10 = this.FindViewById<TextView>(Resource.Id.tv_10);

            this.SupportActionBar.NavigationMode = (int)ActionBarNavigationMode.Tabs;
            this.SupportActionBar.SetDisplayShowHomeEnabled(true);
            this.SupportActionBar.SetDisplayShowTitleEnabled(true);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.SupportActionBar.SetHomeButtonEnabled(true);
        }

        public override void InitEvents()
        {

        }

        public void OnTabReselected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {

        }

        public void OnTabSelected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {   
            switch (tab.Position)
            {
                case 0:
                    this.tv1.Text = "Placeau 1";
                    this.tv2.Text = "Placeau 1";
                    this.tv3.Text = "Placeau 1";
                    this.tv4.Text = "Placeau 1";
                    this.tv5.Text = "Placeau 1";
                    this.tv6.Text = "Placeau 1";
                    this.tv7.Text = "Placeau 1";
                    this.tv8.Text = "Placeau 1";
                    this.tv9.Text = "Placeau 1";
                    this.tv10.Text = "Placeau 1";
                    break;
                case 1:
                    this.tv1.Text = "Placeau 2";
                    this.tv2.Text = "Placeau 2";
                    this.tv3.Text = "Placeau 2";
                    this.tv4.Text = "Placeau 2";
                    this.tv5.Text = "Placeau 2";
                    this.tv6.Text = "Placeau 2";
                    this.tv7.Text = "Placeau 2";
                    this.tv8.Text = "Placeau 2";
                    this.tv9.Text = "Placeau 2";
                    this.tv10.Text = "Placeau 2";
                    break;
                case 2:
                    this.tv1.Text = "Placeau 3";
                    this.tv2.Text = "Placeau 3";
                    this.tv3.Text = "Placeau 3";
                    this.tv4.Text = "Placeau 3";
                    this.tv5.Text = "Placeau 3";
                    this.tv6.Text = "Placeau 3";
                    this.tv7.Text = "Placeau 3";
                    this.tv8.Text = "Placeau 3";
                    this.tv9.Text = "Placeau 3";
                    this.tv10.Text = "Placeau 3";
                    break;
                case 3:
                    this.tv1.Text = "Sous-étage";
                    this.tv2.Text = "Sous-étage";
                    this.tv3.Text = "Sous-étage";
                    this.tv4.Text = "Sous-étage";
                    this.tv5.Text = "Sous-étage";
                    this.tv6.Text = "Sous-étage";
                    this.tv7.Text = "Sous-étage";
                    this.tv8.Text = "Sous-étage";
                    this.tv9.Text = "Sous-étage";
                    this.tv10.Text = "Sous-étage";
                    break;
            }
        }

        public void OnTabUnselected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {

        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}