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
    public class PhotoAlbumAdapter
    {
        private PhotoAlbum mPhotoAlbum;

        public PhotoAlbumAdapter(PhotoAlbum mPhotoAlbum)
        {
            this.mPhotoAlbum = mPhotoAlbum;
        }
    }
}