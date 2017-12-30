using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using XamarinCrossPlatformNative.Droid.Adapter;
using XamarinCrossPlatformNative.Droid.Model;
using Android.Views;
using XamarinCrossPlatformNative.Droid.Activities;

namespace XamarinCrossPlatformNative.Droid
{
	[Activity (Label = "Android1",Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
		
        List<ColorItem> colorItems=new List<ColorItem>();
	    private ListView listView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		    SetContentView(Resource.Layout.Main);
            
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
		    ActionBar.Title = "My Toolbar";

		    var editToolbar = FindViewById<Toolbar>(Resource.Id.edit_toolbar);
		    editToolbar.Title = "Editing";
            editToolbar.InflateMenu(Resource.Menu.edit_menus);
		    editToolbar.MenuItemClick += (sender, e) => {
		        Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();
		    };

		    FindViewById<Button>(Resource.Id.GoToDetailPage).Click += (sender, e) =>
		    {
		        StartActivity(typeof(DetailActivity));
		    };

		    /*listView = FindViewById<ListView>(Resource.Id.myListView);

            colorItems.Add(new ColorItem(){Color = Color.DarkRed,ColorName = "Dark red",Code = "8B0000"});
            colorItems.Add(new ColorItem(){Color = Color.SlateBlue,ColorName = "slate blue",Code = "6A5ACD"});
            colorItems.Add(new ColorItem(){Color = Color.ForestGreen,ColorName = "forest green",Code = "228B22"});
            listView.Adapter=new ColorAdapter(this,colorItems);*/
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus,menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}


