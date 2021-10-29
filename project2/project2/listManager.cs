using System;
using System.Collections.Generic;
using System.Text;
using project2.Modals;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace project2
{
    public class listManager
    {
        static public Task<personalList> userInp(INavigation nav, personalList personal)
        {
            var speciDriver = new TaskCompletionSource<personalList>();

            
            if (personal.comments == null)
                personal.comments = "";

            var lblTitle = new Label { Text = "Want to add a Driver?", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblName = new Label { Text = "Full Name: ", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var dName = new Label { Text = personal.fullName, HorizontalOptions = LayoutOptions.Center};
            var lblDob = new Label { Text = "Date Of Birth: ", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var dDob = new Label { Text = personal.dateOfBirth, HorizontalOptions = LayoutOptions.Center };
            var lblUrl = new Label { Text = "Bibliography: ", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var dUrl = new Label { Text = personal.url, HorizontalOptions = LayoutOptions.Center, TextColor = Color.Blue};
            dUrl.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Device.OpenUri(new Uri(dUrl.Text));
                })
            });

            
            var lblMessage = new Label { Text = "Enter a comment:", FontAttributes = FontAttributes.Bold };
            var txtInput = new Entry { Text = personal.comments };
            Console.WriteLine(txtInput.Text + " sssss");
            var btnAdd = new Button
            {
                Text = "Add",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
            };
            btnAdd.Clicked += async (s, e) =>
            {
                var userInput = txtInput.Text;
                personal.comments = userInput;
                Console.WriteLine(personal.comments + " sssssInside");
                await nav.PopModalAsync();
                if(personal != null)
                speciDriver.SetResult(personal);
            };
            var btnResults = new Button
            {
                Text = "Results",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
            };
            btnResults.Clicked += async (s, e) =>
            {
                await nav.PushModalAsync(new driverResults());                
            };
            var btnCancel = new Button
            {
                Text = "Cancel",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
                HorizontalOptions = LayoutOptions.EndAndExpand
                
            };
            btnCancel.Clicked += async (s, e) =>
            {
                await nav.PopModalAsync();
                speciDriver.SetResult(null);
            };



            var slBtn = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnAdd, btnResults, btnCancel },
            };
            var slDName = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblName, dName },
            };
            var slDDob = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblDob, dDob },
            };
            var slDUrl = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblUrl, dUrl },
            };

            var layout = new StackLayout
            {
                // Padding = new Thickness(0, 40, 0, 0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, slDName, slDDob, slDUrl, lblMessage, txtInput, slBtn },
            };

            var newPage = new ContentPage();
            newPage.Content = layout;
            nav.PushModalAsync(newPage);
            txtInput.Focus();

            return speciDriver.Task;
        }
    }
}
