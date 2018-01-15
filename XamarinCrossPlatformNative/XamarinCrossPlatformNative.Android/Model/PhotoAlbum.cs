using System;

namespace XamarinCrossPlatformNative.Droid.Model
{
    public class PhotoAlbum
    {
        private static Photo[] mBuiltInPhotos =
        {
            new Photo { mPhotoID = Resource.Drawable.buckingham_guards,mCaption = "Buckingham Palace" },
            new Photo { mPhotoID = Resource.Drawable.la_tour_eiffel,mCaption = "The Eiffel Tower" },
            new Photo { mPhotoID = Resource.Drawable.louvre_1,mCaption = "The Louvre" },
            new Photo { mPhotoID = Resource.Drawable.before_mobile_phones,mCaption = "Before mobile phones" },
            new Photo { mPhotoID = Resource.Drawable.big_ben_1,mCaption = "Big Ben skyline" },
            new Photo { mPhotoID = Resource.Drawable.big_ben_2,mCaption = "Big Ben from below" },
            new Photo { mPhotoID = Resource.Drawable.london_eye,mCaption = "The London Eye" },
            new Photo { mPhotoID = Resource.Drawable.eurostar,mCaption = "Eurostar Train" },
            new Photo { mPhotoID = Resource.Drawable.arc_de_triomphe,mCaption = "Arc de Triomphe" },
            new Photo { mPhotoID = Resource.Drawable.louvre_2,mCaption = "Inside the Louvre" },
            new Photo { mPhotoID = Resource.Drawable.modest_accomodations,mCaption = "Modest accomodations" },
            new Photo { mPhotoID = Resource.Drawable.inside_notre_dame,mCaption = "Inside Notre Dame" },
            new Photo { mPhotoID = Resource.Drawable.champ_elysees,mCaption = "The Avenue des Champs-Elysees" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_castle_2,mCaption = "Edinburgh Castle" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_castle_1,mCaption = "Edinburgh Castle up close" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_from_on_high,mCaption = "Edinburgh from on high" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_station,mCaption = "Edinburgh station" },
            new Photo { mPhotoID = Resource.Drawable.heres_lookin_at_ya,mCaption = "Here's Lookin' at Ya!" },
        };

        private Random mRandom;
        private Photo[] mPhotos;

        public PhotoAlbum()
        {
            mRandom=new Random();
            mPhotos = mBuiltInPhotos;
        }

        public int NumPhotos
        {
            get { return mPhotos.Length; }
        }

        public Photo this[int i]
        {
            get { return mPhotos[i]; }
        }

        public int RandomSwap()
        {
            Photo tempPhoto = mBuiltInPhotos[0];
            int random = mRandom.Next(0, mPhotos.Length-1);
            mPhotos[0] = mPhotos[random];
            mPhotos[random] = tempPhoto;

            return random;
        }

        public void Shuffle()
        {
            for (int idx=0;idx<mPhotos.Length;++idx)
            {
                Photo tempPhoto = mPhotos[idx];
                int rnd = mRandom.Next(idx, mPhotos.Length);
                mPhotos[idx] = mPhotos[rnd];
                mPhotos[rnd] = tempPhoto;
            }
        }
    }
}