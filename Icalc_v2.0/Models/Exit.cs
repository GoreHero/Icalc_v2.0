using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Icalc_v2._0.Models
{
    internal class Exit
    {
        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e) //кнопка выхода
        {
            Application.Current.Shutdown();
        }
    }
}
