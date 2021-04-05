using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Shared
{
    public class BaseViewModel<T>
    {
        public T ViewModel { get; set; }
        public bool CutScript { get; set; }

        public BaseViewModel(T viewModel, bool cutScript)
        {
            ViewModel = viewModel;
            CutScript = cutScript;
        }
    }
}
