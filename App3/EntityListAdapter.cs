using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Android.Util;
using static Android.Support.V7.Widget.RecyclerView;
using Android.Content;
using Android.App;
using System;
using Android.Text;
using Android.Text.Style;
using App3.Database;

namespace App3.Resources
{
    /**
     * Check https://blog.jakelee.co.uk/using-stickylayoutmanager-to-give-your-recyclerview-sticky-headers/ for sticky header.
     * Fix the first line on the top and other element can scroll.
     */

    public class EntityListAdapter : RecyclerView.Adapter
    {
        List<Entity> items;
        Context context;

        string[] alertItems = new string[] { "Editer", "Supprimer" };

        public EntityListAdapter(List<Entity> data, Context context)
        {
            this.context = context;
            items = new List<Entity>();

            // add first item and set Num at null for TitleBar
            items.Add(new Entity()
            {
                Num = null,
                Ess = "",
                Diam1 = 0,
                Diam2 = 0,
            });

            items.AddRange(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.entity_item, parent, false);
            ViewHolder vh = new EntityListAdapterViewHolder(itemView);

            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as EntityListAdapterViewHolder;
            holder.IsRecyclable = false;
            var selectedItem = items[viewHolder.AdapterPosition];

            int titelSize = 20;
            int itemSize = 18;

            Color txtColor = new Color(0, 0, 0);
            Color color = new Color(255, 255, 255);

            // if Num is null, we display the header.
            if (selectedItem.Num == null)
            {
                txtColor = new Color(255, 255, 255);
                color = new Color(8, 55, 99);

                holder.TVDelete.Text = "";
                holder.TVNum.Text = "Num";
                holder.TVEss.Text = "Ess";
                holder.TVDiam1.Text = "DIAM1";
                holder.TVDiam2.Text = "DIAM2";

                holder.TVNum.SetTextSize(ComplexUnitType.Sp, titelSize);
                holder.TVEss.SetTextSize(ComplexUnitType.Sp, titelSize);
                holder.TVDiam1.SetTextSize(ComplexUnitType.Sp, titelSize);
                holder.TVDiam2.SetTextSize(ComplexUnitType.Sp, titelSize);
            }
            else
            {
                txtColor = new Color(0, 0, 0);

                if (selectedItem.Num % 2 == 1)
                {
                    color = new Color(237, 237, 237);
                } else
                {
                    color = new Color(255, 255, 255);
                }

                // Set text on TextView.$
                holder.TVNum.Text = selectedItem.Num.ToString();
                holder.TVEss.Text = selectedItem.Ess.ToString();
                holder.TVDiam1.Text = selectedItem.Diam1.ToString();
                holder.TVDiam2.Text = selectedItem.Diam2.ToString();

                // Set size on Textview.
                holder.TVNum.SetTextSize(ComplexUnitType.Sp, itemSize);
                holder.TVEss.SetTextSize(ComplexUnitType.Sp, itemSize);
                holder.TVDiam1.SetTextSize(ComplexUnitType.Sp, itemSize);
                holder.TVDiam2.SetTextSize(ComplexUnitType.Sp, itemSize);

                // Set click event.
                holder.TVNum.Click += (sender, e) =>
                {
                    Toast.MakeText(this.context, "Num", ToastLength.Short).Show();
                };

                holder.TVEss.Click += (sender, e) =>
                {
                    Toast.MakeText(this.context, "Ess", ToastLength.Short).Show();
                };

                holder.TVDiam1.Click += (sender, e) =>
                {
                    Toast.MakeText(this.context, "Diam1", ToastLength.Short).Show();
                };

                holder.TVDiam2.Click += (sender, e) =>
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this.context);
                    alert.SetTitle("Que voulez-vous faire ?");

                    string[] alertItems = new string[] { "Editer", "Supprimer" };
                    alert.SetItems(alertItems, (id, listener) =>
                    {
                        switch (listener.Which)
                        {
                            // Edit
                            case 0:
                                // Start intent
                                Intent intent = new Intent(context, typeof(EditActivity));
                                context.StartActivity(intent);
                                break;
                            // Delete
                            case 1:
                                selectedItem.Diam2 = 0;
                                SingletonEntity.Instance.InsertOrUpdate(selectedItem);
                                this.NotifyDataSetChanged();

                                break;
                            default:
                                break;
                        }
                    });
                    alert.SetNegativeButton("Cancel", (senderAlert, args) => { });
                    alert.Create().Show();
                };

                holder.TVDelete.Click += (sender, e) =>
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this.context);
                    alert.SetTitle("Voulez-vous supprimer la ligne ?");
                    alert.SetPositiveButton("Oui", (senderAlert, args) => {
                        this.items.Remove(selectedItem);
                        SingletonEntity.Instance.Delete(selectedItem);
                        this.NotifyDataSetChanged();
                    });
                    alert.SetNegativeButton("Non", (senderAlert, args) => { });
                    alert.Create().Show();
                };
            }

            // Set color.
            holder.ItemView.SetBackgroundColor(color);
            holder.TVNum.SetTextColor(txtColor);
            holder.TVEss.SetTextColor(txtColor);
            holder.TVDiam1.SetTextColor(txtColor);
            holder.TVDiam2.SetTextColor(txtColor);
        }

        public override int ItemCount => items.Count -1;
    }

    public class EntityListAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView TVDelete { get; set; }
        public TextView TVNum { get; set; }
        public TextView TVEss { get; set; }
        public TextView TVDiam1 { get; set; }
        public TextView TVDiam2 { get; set; }

        public EntityListAdapterViewHolder(View itemView) : base(itemView)
        {
            this.TVDelete = itemView.FindViewById<TextView>(Resource.Id.tv_delete);
            this.TVNum = itemView.FindViewById<TextView>(Resource.Id.tv_num);
            this.TVEss = itemView.FindViewById<TextView>(Resource.Id.tv_ess);
            this.TVDiam1 = itemView.FindViewById<TextView>(Resource.Id.tv_dim1);
            this.TVDiam2 = itemView.FindViewById<TextView>(Resource.Id.tv_dim2);
        }
    }
}