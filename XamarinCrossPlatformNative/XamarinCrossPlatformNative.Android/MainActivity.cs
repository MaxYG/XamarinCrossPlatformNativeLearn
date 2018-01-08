using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using XamarinCrossPlatformNative.Droid.Adapter;
using XamarinCrossPlatformNative.Droid.Model;
using Android.Views;
using XamarinCrossPlatformNative.Droid.Activities;
using Path = Android.Graphics.Path;

namespace XamarinCrossPlatformNative.Droid
{
	[Activity (Icon = "@drawable/icon", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
    {
		
      /*  List<ColorItem> colorItems=new List<ColorItem>();
	    private ListView listView;*/
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            //tab start
            /*RequestWindowFeature(WindowFeatures.ActionBar);
		    this.ActionBar.SetDisplayShowHomeEnabled(false);
		    this.ActionBar.SetDisplayShowTitleEnabled(false);
		    ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
		    AddTab("Tab 1", Resource.Drawable.ic_tab_white, new SampleTabFragment());
		    AddTab("Tab 2", Resource.Drawable.ic_tab_white, new SampleTabFragment2());
		    if (bundle != null)
		    {
		        this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));
		    }*/
		    //tab end

//		    CopyToPublic("monkey.png");
            SetContentView(Resource.Layout.Main);
		    
		    
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
            MenuInflater.Inflate(Resource.Menu.TopMenus,menu);
//            var shareMenuItem = menu.FindItem(Resource.Id.shareMenuItem);
//            var shareActionProvider =(ShareActionProvider) shareMenuItem.ActionProvider;
//            shareActionProvider.SetShareIntent(CreateIntent());
            return true;
        }

        public Intent CreateIntent()
        {
            var sendPictureIntent=new Intent(Intent.ActionSend);
            sendPictureIntent.SetType("image/*");
            var uri = Android.Net.Uri.FromFile(GetFileStreamPath("monkey.png"));
            sendPictureIntent.PutExtra(Intent.ExtraStream, uri);
            return sendPictureIntent;
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

        /*private void AddTab(string tabText,int iconResourceId,Fragment view)
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
        }*/

        public void CopyToPublic(String fileName)
        {
            using (Stream fromStream = Assets.Open(fileName))
            {

                string filePath = System.IO.Path.Combine(new string[] { "data", "data", PackageName, "files", fileName });

                int size = 32 * 1024;

                using (FileStream toStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {

                    int n = -1;
                    byte[] buffer = new byte[size];

                    while ((n = fromStream.Read(buffer, 0, size)) > 0)
                    {
                        toStream.Write(buffer, 0, n);
                    }
                }
            }
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


