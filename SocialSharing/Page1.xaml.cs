using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;

namespace SocialSharing
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get a dictionary of query string keys and values.
            IDictionary<string, string> queryStrings = this.NavigationContext.QueryString;

            // Ensure that there is at least one key in the query string, and check
            // whether the "FileId" key is present.
            if (queryStrings.ContainsKey("FileId"))
            {
                // Retrieve the picture from the media library using the FileID
                // passed to the application.
                MediaLibrary library = new MediaLibrary();
                Picture picture = library.GetPictureFromToken(queryStrings["FileId"]);

                // Create a WriteableBitmap object and add it to the Image control Source property.
                BitmapImage bitmap = new BitmapImage();
                bitmap.CreateOptions = BitmapCreateOptions.None;
                bitmap.SetSource(picture.GetImage());

                WriteableBitmap picLibraryImage = new WriteableBitmap(bitmap);
                retrievePic.Source = picLibraryImage;
            }
        }

        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            ShareStatusTask task = new ShareStatusTask();
            task.Status = ShareMessage.Text;
            task.Show();
        }
    }
}