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
    public class AlertItem
    {
        private int icon;
        private string text;

        public int Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}