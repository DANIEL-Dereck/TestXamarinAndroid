using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App3
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : BaseActivity
    {
        //private TextView tvLibel;
        //private EditText etValue;
        private Button btnCancel;
        private Button btnValidate;

        //private Entity editedItem;

        public override int GetContentView()
        {
            return Resource.Layout.activity_edit;
        }

        public override void InitComponents()
        {
            //this.tvLibel = this.FindViewById<TextView>(Resource.Id.tv_libel);
            //this.etValue = this.FindViewById<EditText>(Resource.Id.et_value);
            this.btnCancel = this.FindViewById<Button>(Resource.Id.btn_cancel);
            this.btnValidate = this.FindViewById<Button>(Resource.Id.btn_validate);
        }

        public override void InitEvents()
        {
            this.btnCancel.Click += (sender, e) =>
            {
                this.OnBackPressed();
            };

            this.btnValidate.Click += (sender, e) =>
            {

            };
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}