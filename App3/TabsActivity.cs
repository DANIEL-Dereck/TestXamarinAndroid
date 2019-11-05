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

        bool btn5State;
        #endregion

        #region OverridedMethods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.InitSupportActionBar();
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

            this.btn5.Click += (sender, e) => {
                this.btn5State = !this.btn5State;
                this.btn5.Text = (this.btn5State ? "OUI" : "NON");
            };
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
        #endregion

        #region Methods
        #region Private
        #region ActionBar
        private void InitSupportActionBar()
        {
            this.SupportActionBar.NavigationMode = (int)ActionBarNavigationMode.Tabs;
            this.SupportActionBar.SetDisplayShowHomeEnabled(true);
            this.SupportActionBar.SetDisplayShowTitleEnabled(true);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.SupportActionBar.SetHomeButtonEnabled(true);

            this.SupportActionBar.AddTab(
                this.SupportActionBar.NewTab()
                .SetText("Placeau 1")
                .SetTabListener(this),
                0, true);

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

        #endregion

        #region Public
        public void OnTabReselected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {

        }

        public void OnTabSelected(Tab tab, Android.Support.V4.App.FragmentTransaction ft)
        {
            this.et1.Text = "3";
            this.et2.Text = "3";
            this.et3.Text = "8";
            this.et4.Text = "3";
            this.et6.Text = "3";
            this.btn5State = true;

            this.btn5.Text = (this.btn5State ? "OUI" : "NON");

            switch (tab.Position)
            {
                case 0:
                    this.SupportActionBar.Title = "Plac.1 - Placeau 1 - Rayon 22.5";
                    #region SetValueCase0
                    #endregion
                    break;
                case 1:
                    this.SupportActionBar.Title = "Plac.2 - Placeau 2 - Rayon 23.5";
                    #region SeetaluesCase1
                    #endregion
                    break;
                case 2:
                    this.SupportActionBar.Title = "Plac.3 - Placeau 3 - Rayon 24.5";
                    #region SeetalueCase2
                    #endregion
                    break;
                case 3:
                    this.SupportActionBar.Title = "Sous-étage - Rayon 25.5";
                    #region SeetalueCase3
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
