using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Dtos;

namespace JTTT.ViewModels.ThenThatViewModels
{
    public class SendMailViewModel : ThenThatViewModel
    {
        public override Type TypeOfAction { get; } = typeof(SendMailViewModel);

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(email);
        }

        public override void Act(IsImageDto imageDto)
        {
            var foundImages = HtmlSearcher.SearchNodes(imageDto.Text, imageDto.Url);
            if (foundImages.Any())
            {
                MailSender.SendAllNodes(foundImages, email);
            }
        }
    }
}
