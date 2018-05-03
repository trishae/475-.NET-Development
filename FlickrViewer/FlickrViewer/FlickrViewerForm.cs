using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlickrViewer
{
    public partial class FlickrViewerForm : Form
    {
        // Flickr API key
        private const string KEY = "5d07e5f58a358cd51c325e0a518af32c";

        // Create an WebClient object to invoke Flickr web service 
        private WebClient flickrClient = new WebClient();

        // Initialize a Task<String> object called flickrTask to null
        // Task<string> queries Flickr
        Task<string> flickrTask = null;

        /// <summary>
        /// Constructor initializes viewer form
        /// </summary>
        public FlickrViewerForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Initiates the asynchronous Flickr search query and displayes results when query completes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void searchButton_Click( object sender, EventArgs e )
        {
            // Check whether user started a search previously
            if ( flickrTask != null && flickrTask.Status != TaskStatus.RanToCompletion )
            {
                var result = MessageBox.Show( 
                   "Cancel the current Flickr search?",
                   "Are you sure?", MessageBoxButtons.YesNo, 
                   MessageBoxIcon.Question );

                // If user clicks No, the event handler returns
                if (result == DialogResult.No)
                    return;
                else
                    flickrClient.CancelAsync(); // cancel current search
            }

            // Create a URL for invoking the Flickr web service's method flickr.photos.search
            var flickrURL = string.Format("https://api.flickr.com/services" +
                "/rest/?method=flickr.photos.search&api_key={0}&tags={1}" +
                "&tag_mode=all&per_page=500&privacy_filter=1", KEY,
                inputTextBox.Text.Replace(" ", ","));

            imagesListBox.DataSource = null;
            imagesListBox.Items.Clear(); // clear imagesListBox
            pictureBox.Image = null; // clear pictureBox
            imagesListBox.Items.Add( "Loading..." ); // display Loading...

            try
            {
                // Call WebClient's DownloadStringTaskAsync method to request information
                flickrTask = flickrClient.DownloadStringTaskAsync(flickrURL);

                // await fickrTask then parse results with XDocument
                XDocument flickrXML = XDocument.Parse(await flickrTask);

                // Gather from each photo element in the XML the id, title, secret, server, and farm attributes
                var flickrPhotos =
                    from photo in flickrXML.Descendants( "photo" )
                    let id = photo.Attribute("id").Value
                    let title = photo.Attribute("title").Value
                    let secret = photo.Attribute("secret").Value
                    let server = photo.Attribute("server").Value
                    let farm = photo.Attribute("farm").Value
                    select new FlickrResult
                    {
                        Title = title,
                        URL = string.Format("http://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg",
                            farm, server, id, secret)
                    };
                imagesListBox.Items.Clear();

                // set ListBox properties only if results were found
                if ( flickrPhotos.Any() )
                {
                    imagesListBox.DataSource = flickrPhotos.ToList();
                    imagesListBox.DisplayMember = "Title";
                }
                else // no matches were found
                    imagesListBox.Items.Add( "No matches" );
            }
            catch ( WebException ) 
            {
                // check whether Task failed
                if ( flickrTask.Status == TaskStatus.Faulted )
                    MessageBox.Show( "Unable to get results from Flickr",
                        "Flickr Error", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error );
                imagesListBox.Items.Clear(); // clear imagesListBox
                imagesListBox.Items.Add( "Error occurred" );
            }
        }

        /// <summary>
        /// Display selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void imagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( imagesListBox.SelectedItem != null )
            {
                string selectedURL = ((FlickrResult)imagesListBox.SelectedItem).URL;

                // use WebClient to get selected image's bytes asynchronously
                WebClient imageClient = new WebClient();
                
                byte[] imageBytes = await imageClient.DownloadDataTaskAsync(selectedURL);
                
                MemoryStream memoryStream = new MemoryStream(imageBytes);
                
                pictureBox.Image = Image.FromStream(memoryStream);
            }
        }
    }
}

