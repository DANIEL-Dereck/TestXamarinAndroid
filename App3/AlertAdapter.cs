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
    public class AlertAdapter : ArrayAdapter<AlertItem>
    {
        private Context context;
        private AlertItem[] items;


        public AlertAdapter(Context context, AlertItem[] items) : base(context, 0, items)
        {
            this.context = context;
            this.items = items;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.alertItem, parent, false);
            }

            AlertItem currentItem = this.items[position];

            ImageView image = (ImageView)view.FindViewById<ImageView>(Resource.Id.iv_alert);
            image.SetImageResource(currentItem.Icon);

            TextView text = (TextView)view.FindViewById<TextView>(Resource.Id.tv_alert);
            text.Text = currentItem.Text;

            return view;
        }
    }
}