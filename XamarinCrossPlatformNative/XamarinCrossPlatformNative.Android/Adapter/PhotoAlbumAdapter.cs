using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using XamarinCrossPlatformNative.Droid.Model;
using XamarinCrossPlatformNative.Droid.Tool;

namespace XamarinCrossPlatformNative.Droid.Adapter
{
    public class PhotoAlbumAdapter:RecyclerView.Adapter
    {
        private PhotoAlbum mPhotoAlbum;

        public PhotoAlbumAdapter(PhotoAlbum mPhotoAlbum)
        {
            this.mPhotoAlbum = mPhotoAlbum;
        }

       
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);
            PhotoViewHolder photoViewHolder = new PhotoViewHolder(itemView);
            return photoViewHolder;
        }

        public override int ItemCount {
            get { return mPhotoAlbum.NumPhotos; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder photoViewHolder = holder as PhotoViewHolder;

            photoViewHolder.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
            photoViewHolder.Caption.Text = mPhotoAlbum[position].Caption;
        }
    }
}