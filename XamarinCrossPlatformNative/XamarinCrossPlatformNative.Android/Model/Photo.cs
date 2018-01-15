using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinCrossPlatformNative.Droid.Model
{
    public class Photo
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }

        public int PhotoID
        {
            get { return mPhotoID; }
        }

        public string Caption
        {
            get { return mCaption; }
        } 
    }
}