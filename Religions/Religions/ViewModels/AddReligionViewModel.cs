using System;
using System.Collections.Generic;
using System.Text;
using Religions.Backend.Managers;
using Religions.Backend.Models;
using Religions.DependencyServices;
using Religions.ViewModels.Abstract;
using Xamarin.Forms;

namespace Religions.ViewModels
{
    class AddReligionsViewModel : ViewModel
    {
        private Religion model;

        private byte[] imageData;



        public AddReligionsViewModel()
        {
            this.model = new Religion();
            this.SaveCommand = new Command(this.SaveCommand_Execute);
            this.AddPictureCommand = new Command(this.AddPictureCommand_Execute);
        }


        private async void SaveCommand_Execute(object obj)
        {
            var manager = new ReligionsManager();
            if (await manager.AddReligions(this.model))
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "Víru se nepodařilo uložit:(", "OK");
        }


        private async void AddPictureCommand_Execute(object obj)
        {
            var gallery = "Fotogalerie";
            var camera = "Vyfotit";
            var result = await App.Current.MainPage.DisplayActionSheet("Vložit fotografii", null, null, gallery, camera);
            var picturePicker = DependencyService.Get<IPicturePicker>();

            if (string.Equals(gallery, result))
            {
                ImageData = await picturePicker.GetPictureFromGallery();
            }

            else if (string.Equals(camera, result))
            {
                ImageData = await picturePicker.GetPictureFromCamera();
            }


        }


        public string Title
        {
            get
            {
                return this.model.Title;
            }
            set
            {
                if (this.model.Title != value)
                {
                    this.model.Title = value;
                    this.OnPropertyChanged(nameof(this.Title));
                }
            }
        }

        public string Description
        {
            get
            {
                return this.model.Description;
            }
            set
            {
                if (this.model.Description != value)
                {
                    this.model.Description = value;
                    this.OnPropertyChanged(nameof(this.Description));
                }
            }
        }

        public byte[] ImageData
        {
            get
            {
                return this.imageData;
            }
            set
            {
                if (this.imageData != value)
                {
                    this.imageData = value;
                    this.OnPropertyChanged(nameof(ImageData));
                }
            }
        }

        public Command SaveCommand { get; set; }

        public Command AddPictureCommand { get; set; }
    }
}
