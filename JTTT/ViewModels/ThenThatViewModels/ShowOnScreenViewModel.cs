using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JTTT.Views;

namespace JTTT.ViewModels.ThenThatViewModels
{
    public class ShowOnScreenViewModel : ThenThatViewModel
    {
        public override bool IsValid()
        {
            return true;
        }

        public override void Act(DataCI data)
        {
            var htmlContent = data.Images.Aggregate("", (current, image) => current + ("<img src=\"" + image + "\" /><br />"));

            var viewModel = new ShowConditionViewModel(data.Title, data.Text, htmlContent);
            WindowService.ShowWindow(viewModel);
        }
    }

    public static class WindowService
    {
        public static void ShowWindow(object viewModel)
        {
            var win = new ShowConditionView();
            win.DataContext = viewModel;
            win.Show();
        }
    }
}
