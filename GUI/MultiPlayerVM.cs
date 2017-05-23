using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class MultiPlayerVM : ViewModel
    {
        private MultiPlayerModel model;
        public MultiPlayerVM(MultiPlayerModel model)
        {
            this.model = model;
            model.connect("list");
        }

        private List<string> list;
        public List<string> ListOfGames
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                NotifyPropertyChanged("ListOfGames");
            }

        }
    }
}
