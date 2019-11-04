using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using App3.Database;
using static Android.Support.V7.Widget.RecyclerView;

namespace App3.Resources
{
    /**
     * Check https://blog.jakelee.co.uk/using-stickylayoutmanager-to-give-your-recyclerview-sticky-headers/ for sticky header.
     * Fix the first line on the top and other element can scroll.
     */

    public class EntityListAdapter : RecyclerView.Adapter
    {
        #region Attributs
        private List<Entity> items;
        private Context context;
        private ViewHolder viewHolder;
        private string[] alertItems = new string[] { "Editer", "Supprimer" };
        private int[] pictAlertItems = new int[]{ Resource.Drawable.outline_edit_24, Resource.Drawable.outline_clear_24 };
    #endregion

    #region Properties
    public Entity SelectedEntity { get; set; }
        public EventHandler NumClickEvent { get; set; }

        public Dictionary<string, Entity> SelectedCell { get; set; }
        #endregion

        #region Constructors
        public EntityListAdapter(List<Entity> data, Context context)
        {
            this.context = context;
            items = new List<Entity>();

            // add first item and set Num at null for TitleBar
            items.Add(new Entity()
            {
                Num = null,
                Ess = "",
                Diam1 = null,
                Diam2 = 0,
            });

            items.AddRange(data);
        }
        #endregion

        #region OverridedMethods
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.entity_item, parent, false);
            this.viewHolder = new EntityListAdapterViewHolder(itemView);

            return this.viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as EntityListAdapterViewHolder;
            holder.IsRecyclable = false;
            var selectedItem = items[viewHolder.AdapterPosition];

            int titelSize = 24;
            int itemSize = 22;

            Color txtColor = new Color(0, 0, 0);
            Color color = new Color(255, 255, 255);

            // if Num is null, we display the header.
            if (selectedItem.Num == null)
            {
                #region Header
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
                #endregion
            }
            else
            {
                #region Values
                txtColor = new Color(0, 0, 0);

                if (viewHolder.AdapterPosition % 2 == 1)
                {
                    color = new Color(237, 237, 237);
                }
                else
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

                #region TVNumEventEx
                holder.TVNum.Click += (sender, e) =>
                {
                    this.SelectedEntity = selectedItem;
                };
                holder.TVNum.Click += this.NumClickEvent;
                #endregion

                #region TVEssEvent
                // Set click event.
                holder.TVEss.Click += (sender, e) =>
                {
                    Intent intent = new Intent(context, typeof(EditActivity));
                    intent.PutExtra(EditActivity.EXTRA_ID, selectedItem.Num.Value);
                    intent.PutExtra(EditActivity.EXTRA_EDIT_CODE, 0);
                    context.StartActivity(intent);
                };
                #endregion

                #region TVDiam1Event
                holder.TVDiam1.Click += (sender, e) =>
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
                                Intent intent = new Intent(context, typeof(EditActivity));
                                intent.PutExtra(EditActivity.EXTRA_ID, selectedItem.Num.Value);
                                intent.PutExtra(EditActivity.EXTRA_EDIT_CODE, 1);
                                context.StartActivity(intent);
                                break;
                            // Delete
                            case 1:
                                selectedItem.Diam1 = null;
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
                #endregion

                #region TVDiam2Event
                holder.TVDiam2.Click += (sender, e) =>
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this.context);
                    alert.SetTitle("Que voulez-vous faire ?");

                    AlertItem[] alertItems = new AlertItem[] 
                    {
                        new AlertItem() {
                            Icon =  Resource.Drawable.outline_edit_24,
                            Text = "Editer"
                        },
                        new AlertItem()
                        {
                            Icon = Resource.Drawable.outline_clear_24,
                            Text = "Supprimer"
                        }
                    };

                    ListView listView = ((Activity)context).FindViewById<ListView>(Resource.Id.lv_alert);
                    AlertAdapter arrayAdapter = new AlertAdapter(context, alertItems);
                    listView.SetAdapter(arrayAdapter);

                    alert.SetView(listView);
                    alert.SetItems(this.alertItems, (id, listener) =>
                    {
                        switch (listener.Which)
                        {
                            // Edit
                            case 0:
                                Intent intent = new Intent(context, typeof(EditActivity));
                                intent.PutExtra(EditActivity.EXTRA_ID, selectedItem.Num.Value);
                                intent.PutExtra(EditActivity.EXTRA_EDIT_CODE, 2);
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
                    }).SetIcon(Resource.Drawable.outline_edit_24);
                    alert.SetNegativeButton("Cancel", (senderAlert, args) => { });
                    alert.Create().Show();
                };
                #endregion

                #region TVDeleteEvent
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
                #endregion
                #endregion
            }

            #region SetColor
            // Set color.
            holder.ItemView.SetBackgroundColor(color);
            holder.TVNum.SetTextColor(txtColor);
            holder.TVEss.SetTextColor(txtColor);
            holder.TVDiam1.SetTextColor(txtColor);
            holder.TVDiam2.SetTextColor(txtColor);
            #endregion
        }

        public override int ItemCount => items.Count - 1;
    }
    #endregion

    public class EntityListAdapterViewHolder : RecyclerView.ViewHolder
    {
        #region Properties
        public TextView TVDelete { get; set; }
        public TextView TVNum { get; set; }
        public TextView TVEss { get; set; }
        public TextView TVDiam1 { get; set; }
        public TextView TVDiam2 { get; set; }
        #endregion

        public EntityListAdapterViewHolder(View itemView) : base(itemView)
        {
            #region Init
            this.TVDelete = itemView.FindViewById<TextView>(Resource.Id.tv_delete);
            this.TVNum = itemView.FindViewById<TextView>(Resource.Id.tv_num);
            this.TVEss = itemView.FindViewById<TextView>(Resource.Id.tv_ess);
            this.TVDiam1 = itemView.FindViewById<TextView>(Resource.Id.tv_dim1);
            this.TVDiam2 = itemView.FindViewById<TextView>(Resource.Id.tv_dim2);
            #endregion
        }
    }
}
