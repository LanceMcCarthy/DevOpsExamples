using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace MySite.Web
{
    public partial class ListView : System.Web.UI.Page
    {
        public List<Image> Images
        {
            get
            {
                List<Image> data = Session["DataImages"] as List<Image>;

                if (data == null)
                {
                    data = GetImages();
                    Session["DataImages"] = data;
                }

                return data;
            }
        }

        public List<Image> GetImages()
        {
            return new List<Image>() {
            new Image() { ID=1, Name="Chrysanthemum", ImageUrl="~/images/Chrysanthemum.jpg", ThumbnailUrl="~/images/Thumbnails/Chrysanthemum.jpg", Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"},
            new Image() { ID=2, Name="Desert", ImageUrl="~/images/Desert.jpg", ThumbnailUrl="~/images/Thumbnails/Desert.jpg", Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"},
            new Image() { ID=3, Name="Hydrangeas", ImageUrl="~/images/Hydrangeas.jpg", ThumbnailUrl="~/images/Thumbnails/Hydrangeas.jpg", Description="The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English."},
            new Image() { ID=4, Name="Jellyfish", ImageUrl="~/images/Jellyfish.jpg", ThumbnailUrl="~/images/Thumbnails/Jellyfish.jpg", Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"},
            new Image() { ID=5, Name="Koala", ImageUrl="~/images/Koala.jpg", ThumbnailUrl="~/images/Thumbnails/Koala.jpg", Description="The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English"},
            new Image() { ID=6, Name="Lighthouse", ImageUrl="~/images/Lighthouse.jpg", ThumbnailUrl="~/images/Thumbnails/Lighthouse.jpg", Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"},
            new Image() { ID=7, Name="Penguins", ImageUrl="~/images/Penguins.jpg", ThumbnailUrl="~/images/Thumbnails/Penguins.jpg", Description="The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English"},
            new Image() { ID=8, Name="Tulips", ImageUrl="~/images/Tulips.jpg", ThumbnailUrl="~/images/Thumbnails/Tulips.jpg", Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"}
        };
        }

        public List<Article> Articles
        {
            get
            {
                List<Article> data = Session["DataArticles"] as List<Article>;

                if (data == null)
                {
                    data = GetArticles();
                    Session["DataArticles"] = data;
                }

                return data;
            }
        }

        public List<Article> GetArticles()
        {
            return new List<Article>() {
            new Article(){ ID=1, Title="Phasellus auctor nisi dolor", Description="Donec aliquam turpis sed nisl mattis sagittis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut vitae sapien metus. In hac habitasse platea dictumst. Aenean velit mauris, lobortis eu lacinia sed, imperdiet quis dui. Vestibulum ut metus sagittis dui lacinia mollis ornare eget urna. Mauris vehicula scelerisque sagittis"},
            new Article(){ ID=1, Title="In magna mi, dapibus ut tortor", Description="Nullam facilisis neque ut aliquet imperdiet. Mauris ut odio augue. Curabitur in mi ac odio vestibulum lobortis. Donec sed mollis nibh, vitae varius lorem. Fusce ac neque lacinia dui facilisis posuere. Fusce pharetra rhoncus vulputate"},
            new Article(){ ID=1, Title="Aenean ut lacus enim", Description="Aenean euismod est tortor, et pharetra mauris ultricies ut. Vivamus fringilla libero nec est tincidunt, sit amet venenatis felis accumsan. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae"},
            new Article(){ ID=1, Title="Aenean luctus bibendum", Description="Mauris blandit sit amet diam eget dictum. Ut sit amet tortor sit amet nibh elementum scelerisque. Nullam felis turpis, suscipit ut nunc at, euismod condimentum massa. Ut finibus odio vitae euismod dapibus. Fusce luctus elit leo, at ultrices orci imperdiet quis"},
            new Article(){ ID=1, Title="Lorem ipsum dolor sit amet", Description="Etiam nisi felis, ullamcorper et sagittis sed, posuere et lorem. Mauris non rutrum tortor. Suspendisse eu leo nec justo facilisis imperdiet sed vel felis. Nullam eros urna, efficitur in eros at, interdum iaculis massa"}
        };
        }

        protected void RadListViewImages_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            RadListViewImages.DataSource = Images;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            RadLightBoxImageDetails.DataSource = Images;
            RadLightBoxImageDetails.DataBind();
        }

        protected void RadListViewImages_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            RadListViewDataItem item = e.Item as RadListViewDataItem;
            string description = (item.DataItem as Image).Description;
            if (description.Length > 100)
            {
                description = description.Substring(0, 97) + "...";
                (item.FindControl("LabelShortDescription") as Literal).Text = description;
            }
        }
        protected void RadListViewArticles_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            RadListViewArticles.DataSource = Articles;
        }
    }
}