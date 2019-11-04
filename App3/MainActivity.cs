using Android.App;
using Android.Content;
using Android.OS;
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
        #region Attributs
        private ImageButton btnEdit;
        private ImageButton btnRemove;

        private Button btnCancel;
        private Button btnValidate;
        private RecyclerView rvItems;
        private EntityListAdapter listAdapter;
        #endregion

        #region OverridedMethods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SingletonEntity.Instance.GenerateFixtures(30);

            base.OnCreate(savedInstanceState);

            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            rvItems.SetLayoutManager(layoutManager);
            rvItems.SetAdapter(listAdapter);
            rvItems.SetItemViewCacheSize(0);

            this.btnEdit.Visibility = Android.Views.ViewStates.Gone;
            this.btnRemove.Visibility = Android.Views.ViewStates.Gone;

            listAdapter.NotifyDataSetChanged();
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (listAdapter != null)
            {
                listAdapter.NotifyDataSetChanged();
            }
        }

        protected override void InitComponents()
        {
            this.btnEdit = this.FindViewById<ImageButton>(Resource.Id.btn_edit);
            this.btnRemove = this.FindViewById<ImageButton>(Resource.Id.btn_remove);
            this.btnCancel = this.FindViewById<Button>(Resource.Id.btn_cancel);
            this.btnValidate = this.FindViewById<Button>(Resource.Id.btn_validate);
            this.rvItems = this.FindViewById<RecyclerView>(Resource.Id.rv_items);
            this.listAdapter = new EntityListAdapter(SingletonEntity.Instance.FindAll(), this);
        }

        protected override void InitEvents()
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

            this.btnEdit.Click += (sender, e) =>
            {
                this.btnEdit.Visibility = Android.Views.ViewStates.Gone;
                this.btnRemove.Visibility = Android.Views.ViewStates.Gone;

                if (this.listAdapter.SelectedEntity != null)
                {
                    Intent intent = new Intent(this, typeof(EditActivity));
                    intent.PutExtra(EditActivity.EXTRA_ID, this.listAdapter.SelectedEntity.Num.Value);
                    intent.PutExtra(EditActivity.EXTRA_EDIT_CODE, -1);
                    this.StartActivity(intent);
                }
            };

            this.btnRemove.Click += (sender, e) =>
            {
                if (this.listAdapter.SelectedEntity != null)
                {
                    this.listAdapter.SelectedEntity.Num = -1;
                    SingletonEntity.Instance.InsertOrUpdate(this.listAdapter.SelectedEntity);
                    this.listAdapter.NotifyDataSetChanged();
                }


                this.btnEdit.Visibility = Android.Views.ViewStates.Gone;
                this.btnRemove.Visibility = Android.Views.ViewStates.Gone;
            };

            this.listAdapter.NumClickEvent = (sender, e) => {
                this.btnEdit.Visibility = Android.Views.ViewStates.Visible;
                this.btnRemove.Visibility = Android.Views.ViewStates.Visible;
            };
        }

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            bool result = base.DispatchTouchEvent(ev);

            if (this.btnEdit.Visibility == Android.Views.ViewStates.Visible
                && this.btnRemove.Visibility == Android.Views.ViewStates.Visible)
            {
                this.btnEdit.Visibility = Android.Views.ViewStates.Gone;
                this.btnRemove.Visibility = Android.Views.ViewStates.Gone;
            }

            return result;
        }

        public override int GetContentView()
        {
            return Resource.Layout.activity_main;
        }
        #endregion
    }
}
