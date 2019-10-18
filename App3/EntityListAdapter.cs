using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using static Android.Support.V7.Widget.RecyclerView;

namespace App3.Resources
{
    /**
     * Check https://blog.jakelee.co.uk/using-stickylayoutmanager-to-give-your-recyclerview-sticky-headers/ for sticky header.
     * Fix the first line on the top and other element can scroll.
     */


    public class EntityListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<EntityListAdapterClickEventArgs> ItemClick;
        public event EventHandler<EntityListAdapterClickEventArgs> ItemLongClick;
        List<Entity> items;

        public EntityListAdapter(List<Entity> data)
        {
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
            ViewHolder vh = new EntityListAdapterViewHolder(itemView, OnClick, OnLongClick);

            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as EntityListAdapterViewHolder;
            var item = items[position];

            int titelSize = 20;
            int itemSize = 18;

            Color txtColor = new Color(0, 0, 0);
            Color color = new Color(255, 255, 255);

            // if Num is null, we display the header.
            if (item.Num == null)
            {
                txtColor = new Color(255, 255, 255);
                color = new Color(8, 55, 99);

                holder.TVId.Text = "Num";
                holder.TVName.Text = "Ess";
                holder.TVAge.Text = "DIAM1";
                holder.TVDesc.Text = "DIAM2";

                holder.TVId.SetTextSize(ComplexUnitType.Sp, titelSize);
                holder.TVName.SetTextSize(ComplexUnitType.Sp, titelSize);
                holder.TVAge.SetTextSize(ComplexUnitType.Sp, titelSize);
                holder.TVDesc.SetTextSize(ComplexUnitType.Sp, titelSize);
            }
            else
            {
                txtColor = new Color(0, 0, 0);

                if (item.Num % 2 == 1)
                {
                    color = new Color(237, 237, 237);
                }

                holder.TVId.Text = item.Num.ToString();
                holder.TVName.Text = item.Ess.ToString();
                holder.TVAge.Text = item.Diam1.ToString();
                holder.TVDesc.Text = item.Diam2.ToString();

                holder.TVId.SetTextSize(ComplexUnitType.Sp, itemSize);
                holder.TVName.SetTextSize(ComplexUnitType.Sp, itemSize);
                holder.TVAge.SetTextSize(ComplexUnitType.Sp, itemSize);
                holder.TVDesc.SetTextSize(ComplexUnitType.Sp, itemSize);
            }

            holder.ItemView.SetBackgroundColor(color);
            holder.TVId.SetTextColor(txtColor);
            holder.TVName.SetTextColor(txtColor);
            holder.TVAge.SetTextColor(txtColor);
            holder.TVDesc.SetTextColor(txtColor);
        }

        public override int ItemCount => items.Count;

        void OnClick(EntityListAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(EntityListAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class EntityListAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView TVId { get; set; }
        public TextView TVName { get; set; }
        public TextView TVAge { get; set; }
        public TextView TVDesc { get; set; }

        public EntityListAdapterViewHolder(
            View itemView, 
            Action<EntityListAdapterClickEventArgs> clickListener,
            Action<EntityListAdapterClickEventArgs> longClickListener
            ) : base(itemView)
        {
            TVId = itemView.FindViewById<TextView>(Resource.Id.tv_num);
            TVName = itemView.FindViewById<TextView>(Resource.Id.tv_ess);
            TVAge = itemView.FindViewById<TextView>(Resource.Id.tv_dim1);
            TVDesc = itemView.FindViewById<TextView>(Resource.Id.tv_dim2);

            itemView.Click += (sender, e) => clickListener(new EntityListAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new EntityListAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class EntityListAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}