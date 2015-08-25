using Alfred.Framework.Data;
using Alfred.Framework.Models;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfred.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private IList<CardInfo> _cards;

        public IFindCardInfoByNameQueryHandler FindCardInfoByNameQueryHandler { get; set; }

        public IList<CardInfo> Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                RaisePropertyChanged("Cards");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainPageViewModel class.
        /// </summary>
        public MainPageViewModel()
        {
            FindCardInfoByNameQueryHandler = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance(
                typeof(IFindCardInfoByNameQueryHandler)) as IFindCardInfoByNameQueryHandler;

            Init();
        }

        private async Task Init()
        {
            Cards = (await FindCardInfoByNameQueryHandler.Handle(
                new FindCardInfoByNameQuery { Name = "Baron Sengir" })).ToList();
        }
    }
}