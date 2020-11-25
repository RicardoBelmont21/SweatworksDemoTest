using FFImageLoading.Forms;
using SWDemo.Controls;
using SWDemo.Converters;
using SWDemo.Styles;
using SWDemo.Styles.Keys;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SWDemo.Views.SearchPage.Cell
{
    //Card Cell
    public class BookListCell:ViewCell
    {
        public BookListCell()
        {
            double bgstylesize = Layouts.DisplayXSizePX * .3;
            var sou = (string)App.Current.Resources[IconKeys.BookcardBG];

            //Controls
            Grid cardContainer = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = 0,
                Padding = 0,
                RowDefinitions =
                {
                    new RowDefinition(){Height =new GridLength(1, GridUnitType.Star)},
                    new RowDefinition(){Height =new GridLength(1, GridUnitType.Star)},
                    new RowDefinition(){Height =new GridLength(1, GridUnitType.Star)},
                    new RowDefinition(){Height =new GridLength(1, GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(){ Width= new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition(){ Width= new GridLength(1, GridUnitType.Star)},
                }
            };

            CachedImage bookImage = new CachedImage()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                WidthRequest = bgstylesize,
                HeightRequest = bgstylesize,
                DownsampleHeight= bgstylesize,
                DownsampleToViewSize =true,
                LoadingPlaceholder= "book.png",
                ErrorPlaceholder = "book.png",
                Source= "book.png",
                MinimumHeightRequest = bgstylesize,
                MinimumWidthRequest = bgstylesize,
                Aspect = Aspect.Fill,
            };


            TitleSubtitleItem BookName = new TitleSubtitleItem()
            {
                TitleText = Labels.Labels.Title
            };
            TitleSubtitleItem PublishDate = new TitleSubtitleItem()
            {
                TitleText = Labels.Labels.PublishDate
            };
            TitleSubtitleItem Authors = new TitleSubtitleItem()
            {
                TitleText = Labels.Labels.Authors,
                Margin=Layouts.Margin/2,
                VerticalOptions=LayoutOptions.Start
            };

            BoxView bv = new BoxView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                CornerRadius = Layouts.FrameCornerRadius,
                BackgroundColor = Color.LightGray
            };

            //Grid adds
            cardContainer.Children.Add(bookImage, 0, 1, 0, 2);
            cardContainer.Children.Add(BookName, 0, 1, 2, 3);
            cardContainer.Children.Add(PublishDate, 0, 1, 3, 4);
            cardContainer.Children.Add(bv, 1, 2, 0, 4);
            cardContainer.Children.Add(Authors, 1, 2, 0, 4);


            //Bindings
            bookImage.SetBinding(CachedImage.SourceProperty, "VolumeInfo.ImageLinks.SmallThumbnail");
            BookName.SetBinding(TitleSubtitleItem.SubtitleTextProperty, "VolumeInfo.Title");
            PublishDate.SetBinding(TitleSubtitleItem.SubtitleTextProperty, "VolumeInfo.PublishedDate");
            Authors.SetBinding(TitleSubtitleItem.SubtitleTextProperty, "VolumeInfo.Authors", converter: new ArrayToStringConverter());


            View = new Frame()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor=Color.White,
                HeightRequest=Layouts.DisplayYSizePX*.4,
                MinimumHeightRequest = Layouts.DisplayYSizePX * .4,
                Padding = Layouts.Margin,
                BorderColor = (Color)App.Current.Resources[ColorKeys.TextGreen],
                CornerRadius = Layouts.FrameCornerRadius,
                Margin=Layouts.Margin,
                HasShadow=false,
                IsClippedToBounds=true,
                Content= cardContainer
            };
        }
    }
}
