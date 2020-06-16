using System;
using Android.App;
using Android.OS;

namespace TestFragment
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        public override int GetContentView()
        {
            return Resource.Layout.activity_main;
        }

        protected override void InitComponents()
        {
        }

        protected override void InitEvents()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /*
        private void TestFrament()
        {
            FragmentTransaction ft = this.GetFragmentManager().beginTransaction();
            ft.Replace(Resource.Id.ContainerFragment, new Fragment1());
            ft.Commit();
        }
        */
    }
}