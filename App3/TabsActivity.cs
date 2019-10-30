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

        private EditText et1;
        private EditText et2;
        private EditText et3;
        private EditText et4;
        private Button btn5;
        private EditText et6;

        private Button btnValidate;
        #endregion
        
        #region OverridedMethods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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

            this.et1 = this.FindViewById<EditText>(Resource.Id.et_1);
            this.et2 = this.FindViewById<EditText>(Resource.Id.et_2);
            this.et3 = this.FindViewById<EditText>(Resource.Id.et_3);
            this.et4 = this.FindViewById<EditText>(Resource.Id.et_4);
            this.btn5 = this.FindViewById<Button>(Resource.Id.btn_5);
            this.et6 = this.FindViewById<EditText>(Resource.Id.et_6);

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
                .SetText("Placeau\n1")
                .SetTabListener(this),
                0);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Placeau\n2")
                .SetTabListener(this),
                1);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Placeau\n3")
                .SetTabListener(this),
                2);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Sous-\nétage")
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
                    this.SupportActionBar.Title = "Placette 1 - Rayon 22.5";

                    #region SetValueCase0
                    this.tv1.Text = "Placeau 1";
                    this.tv2.Text = "Placeau 1";
                    this.tv3.Text = "Placeau 1";
                    this.tv4.Text = "Placeau 1";
                    this.tv5.Text = "Placeau 1";
                    this.tv6.Text = "Placeau 1";
                    #endregion
                    break;
                case 1:
                    this.SupportActionBar.Title = "Placette 1 - Rayon 23.5";

                    #region SetValuesCase1
                    this.tv1.Text = "Placeau 2";
                    this.tv2.Text = "Placeau 2";
                    this.tv3.Text = "Placeau 2";
                    this.tv4.Text = "Placeau 2";
                    this.tv5.Text = "Placeau 2";
                    this.tv6.Text = "Placeau 2";
                    #endregion
                    break;
                case 2:
                    this.SupportActionBar.Title = "Placette 1 - Rayon 24.5";

                    #region SetValueCase2
                    this.tv1.Text = "Placeau 3";
                    this.tv2.Text = "Placeau 3";
                    this.tv3.Text = "Placeau 3";
                    this.tv4.Text = "Placeau 3";
                    this.tv5.Text = "Placeau 3";
                    this.tv6.Text = "Placeau 3";
                    #endregion
                    break;
                case 3:
                    this.SupportActionBar.Title = "Placette 1 - Rayon 25.5";

                    #region SetValueCase3
                    this.tv1.Text = "Sous-étage";
                    this.tv2.Text = "Sous-étage";
                    this.tv3.Text = "Sous-étage";
                    this.tv4.Text = "Sous-étage";
                    this.tv5.Text = "Sous-étage";
                    this.tv6.Text = "Sous-étage";
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
