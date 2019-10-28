using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App3
{
    public abstract class BaseActivity: AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(this.GetContentView());
            this.InitComponents();
            this.InitEvents();
        }

        public abstract void InitComponents();

        public abstract void InitEvents();

        public abstract int GetContentView();
    }
}