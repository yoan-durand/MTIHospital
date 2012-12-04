using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace colle_tMedecine.Helper
{
    class BindingHelper : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingHelper();
        }

        #endregion

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingHelper), new UIPropertyMetadata(null));
    }
}
