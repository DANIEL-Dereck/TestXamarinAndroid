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
    public class Entity
    {
        private int? num;

        public int? Num
        {
            get { return num; }
            set { num = value; }
        }

        private string ess;

        public string Ess
        {
            get { return ess; }
            set { ess = value; }
        }

        private int diam1;

        public int Diam1
        {
            get { return diam1; }
            set { diam1 = value; }
        }

        private int diam2;

        public int Diam2
        {
            get { return diam2; }
            set { diam2 = value; }
        }
    }
}