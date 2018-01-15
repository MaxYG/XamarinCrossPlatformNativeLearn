using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace XamarinCrossPlatformNative.Droid.Tool
{
    public class PhotoViewHolder:RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }
      
        public PhotoViewHolder(View itemView,Action<int> action) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            itemView.Click += (ender, e) => action(base.LayoutPosition);
        }
    }
}