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
	[Activity (Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
    {
		
        List<ColorItem> colorItems=new List<ColorItem>();
	    private ListView listView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		    SetContentView(Resource.Layout.Main);

		    ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
//		    this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("Tab 1", Resource.Drawable.ic_tab_white, new SampleTabFragment());
		    AddTab("Tab 2", Resource.Drawable.ic_tab_white, new SampleTabFragment2());

            /*var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
		    SetActionBar(toolbar);
		    ActionBar.Title = "Main Page";

            var editToolbar = FindViewById<Toolbar>(Resource.Id.edit_toolbar);
		    editToolbar.Title = "Editing";
            editToolbar.InflateMenu(Resource.Menu.edit_menus);
		    editToolbar.MenuItemClick += (sender, e) => {
		        Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();
		    };

            FindViewById<Button>(Resource.Id.GoToDetailPage).Click += (sender, e) =>
		    {
		        StartActivity(typeof(DetailActivity));
		    };*/

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

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }

        private void AddTab(string tabText,int iconResourceId,Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(Resource.Drawable.ic_tab_white);

            tab.TabSelected += delegate(object sender, Android.App.ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment!=null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate(object sender, Android.App.ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        class SampleTabFragment : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.Tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "sample fragment text";

                return view;
            }
        }

        class SampleTabFragment2 : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.Tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "sample fragment text 2";

                return view;
            }
        }
    }
}


