using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Religions.Backend.Managers;
using Religions.ViewModels.Abstract;
using Religions.ViewModels.ItemViewModel;

namespace Religions.ViewModels
{
    class ReligionsListViewModel : ViewModel
    {
        private List<ReligionsItemViewModel> religions;

        public async Task LoadData()
        {
            var manager = new ReligionsManager();
            var list = new List<ReligionsItemViewModel>();
            var data = manager.GetReligions();

            foreach (var d in data)
            {
                list.Add(new ReligionsItemViewModel(d));
            }

            this.Religions = list;
        }

        public List<ReligionsItemViewModel> Religions
        {
            get { return this.religions; }
            set
            {
                if (this.religions != value)
                {
                    this.religions = value;
                    this.OnPropertyChanged(nameof(this.Religions));
                }
            }
        }
    }
}
