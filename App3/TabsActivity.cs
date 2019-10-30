using Android.App;
using Android.OS;
using Android.Widget;
using static Android.Support.V7.App.ActionBar;

namespace App3
{
    [Activity(Label = "Régénération", Theme = "@style/AppTheme")]
    public class TabsActivity : BaseActivity, ITabListener
    {
        #region Attributs
        private TextView tv1;
        private TextView tv2;
        private TextView tv3;
        private TextView tv4;
        private TextView tv5;
        private TextView tv6;
        private TextView tv7;
        private TextView tv8;
        private TextView tv9;
        private TextView tv10;
        private Button btnValidate;
        #endregion
        
        #region OverridedMethods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SupportActionBar.Title = "Placette 1 - Rayon 22.5";
            this.SupportActionBar.NavigationMode = (int)ActionBarNavigationMode.Tabs;
            this.SupportActionBar.SetDisplayShowHomeEnabled(true);
            this.SupportActionBar.SetDisplayShowTitleEnabled(true);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.SupportActionBar.SetHomeButtonEnabled(true);
            this.SetupTabs();
        }

        public override int GetContentView()
        {
            return Resource.Layout.activity_tabs;
        }

        protected override void InitComponents()
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
            this.btnValidate = this.FindViewById<Button>(Resource.Id.btn_validate);
        }

        protected override void InitEvents()
        {
            this.btnValidate.Click += (sender, e) =>
            {
                this.Finish();
            };
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
        #endregion

        #region Methods
        #region Private
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
        #endregion

        #region Public
        public void OnTabReselected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {

        }

        public void OnTabSelected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {   
            switch (tab.Position)
            {
                case 0:
                    #region SetValueCase0
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
                    #endregion
                    break;
                case 1:
                    #region SetValuesCase1
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
                    #endregion
                    break;
                case 2:
                    #region SetValueCase2
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
                    #endregion
                    break;
                case 3:
                    #region SetValueCase3
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
                    #endregion
                    break;
            }
        }

        public void OnTabUnselected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {

        }
        #endregion
        #endregion
    }
}
