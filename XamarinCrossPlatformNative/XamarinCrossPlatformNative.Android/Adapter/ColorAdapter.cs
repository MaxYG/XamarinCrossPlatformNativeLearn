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
using XamarinCrossPlatformNative.Droid.Model;

namespace XamarinCrossPlatformNative.Droid.Adapter
{
    public class ColorAdapter : BaseAdapter<ColorItem>
    {
        private List<ColorItem> items;
        private Android.App.Activity activityContext;
        private Context context;

        public ColorAdapter(Android.App.Activity activityContext,List<ColorItem> items):base()
        {
            this.activityContext = activityContext;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ColorItem this[int position]
        {
            get { return items[position]; }
        }
        
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView ?? activityContext.LayoutInflater.Inflate(Resource.Layout.ListItem, null);
            
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.ColorName;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetBackgroundColor(item.Color);

            return view;
        }
        
    }
    
}