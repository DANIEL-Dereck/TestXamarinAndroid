using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace App3
{
    public class StickyItemRecyclerDecoration : RecyclerView.ItemDecoration
    {
        private readonly Predicate<int> _isSectionPredicate;
        private readonly Func<int, int?> _findPreviousHeaderToDisplay;
        private readonly Func<RecyclerView, ViewHolder> _viewHolderCreation;

        public StickyItemRecyclerDecoration(
            Predicate<int> isSectionPredicate,
            Func<int, int?> findPreviousHeaderToDisplay,
            Func<RecyclerView, ViewHolder> viewHolderCreation)
        {
            _isSectionPredicate = isSectionPredicate;
            _findPreviousHeaderToDisplay = findPreviousHeaderToDisplay;
            _viewHolderCreation = viewHolderCreation;
        }
        public override void OnDrawOver
           (Canvas c, RecyclerView parent, RecyclerView.State state)
        {
            base.OnDrawOver(c, parent, state);
        }
    }
}