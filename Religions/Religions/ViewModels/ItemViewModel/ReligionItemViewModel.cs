using System;
using System.Collections.Generic;
using System.Text;
using Religions.Backend.Models;

namespace Religions.ViewModels.ItemViewModel
{
    class ReligionsItemViewModel : ViewModels.Abstract.ViewModel
    {
        private Religion model;

        public ReligionsItemViewModel(Religion Religions)
        {
            this.model = Religions;
        }

        public byte[] Picture { get; set; }

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
                    this.OnPropertyChanged();
                }
            }
        }

        public string Subtitle
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
                    this.OnPropertyChanged(nameof(this.Subtitle));
                }
            }
        }
    }
}
