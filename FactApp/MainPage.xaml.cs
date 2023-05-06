using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace FactApp
{
    public partial class MainPage : ContentPage
    {
        readonly FactDbContext db;

        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydb.db3");
            db = new FactDbContext(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var Items = await db.GetItemsAsync();
            if (Items.Count == 0)
            {
                var factList = populate();
                foreach (var fact in factList)
                {
                    await db.SaveItemAsync(fact);
                }
            }
            factList.ItemsSource = await db.GetItemsAsync();
        }

        private async void OnFactSelected(object sender, EventArgs e)
        {
            var selectedFact = (FactData)((ViewCell)sender).BindingContext;
            await PopupNavigation.Instance.PushAsync(new FactCard(selectedFact));
        }

        public List<FactData> populate()
        {
            return new List<FactData>
            {
                new FactData
                {
                    Title = "Tug is a skilled juggler",
                    Description = "Tug can juggle up to 5 balls at once with ease. He's even been known to juggle flaming bowling pins while riding a unicycle.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101633229414473728/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_67870ec9-3ba4-4f70-8c8a-a0602df07bb6.png"
                },
                new FactData
                {
                    Title = "Tug has a photographic memory",
                    Description = "Tug can remember every detail of a book he read years ago, including the page numbers and font styles. He's even memorized the entire Oxford English Dictionary.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101633175958077470/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_78c9e65f-dd17-49e7-b3cf-82f66bc6fafb.png"
                },
                new FactData
                {
                    Title = "Tug has climbed Mount Everest",
                    Description = "Tug climbed to the summit of Mount Everest in record time, wearing nothing but a pair of shorts and a tank top. He even took a selfie at the top while doing a handstand.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101633150930669712/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_e528f32f-fc6e-4165-9dc5-90513c8c5f12.png"
                },
                new FactData
                {
                    Title = "Tug is a master chef",
                    Description = "Tug can cook up a delicious meal using only 3 ingredients, and he's even invented his own cuisine called 'fusion Cajun-Thai-Mexican'. His signature dish is a spicy peanut butter and jelly sandwich.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101640753161175090/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_843ff2ba-c017-4dc2-a854-3cab204d7d3e.png"
                },
                new FactData
                {
                    Title = "Tug is a world-renowned pianist",
                    Description = "Tug has performed at prestigious concert halls around the world, and he once played a 24-hour piano marathon without taking a break. He's also the only person in history to play a piano duet with a gorilla.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101634566067855410/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_bdcedaa5-7644-4f9a-8c81-53065b2e9938.png"
                },
                new FactData
                {
                    Title = "Tug can hold his breath for 5 minutes",
                    Description = "Tug is an accomplished free diver and can hold his breath for an incredibly long time.He once swam the length of the English Channel without taking a single breath, and he can even perform CPR on himself if he ever gets into trouble underwater.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101638100914024508/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_c40fdd03-3334-4aae-a894-831867928fe4.png"
                },
                new FactData
                {
                    Title = "Tug has won several Olympic medals",
                    Description = "Tug is a talented athlete and has won gold medals in various Olympic events, including the 100-meter dash, the pole vault, and the synchronized swimming competition. He also holds the world record for the longest backflip on a pogo stick.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101636017062170654/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_a8762f97-6d51-45f4-81ca-47ca9e0ce8da.png"
                },
                new FactData
                {
                    Title = "Tug is a successful entrepreneur",
                    Description = "Tug started his own business from scratch and it is now a multimillion-dollar company. He invented a revolutionary product called the 'self-cleaning toaster', which uses advanced nanotechnology to clean itself after every use. He's also the world's first billionaire superhero.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101638084434604032/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_b92eaf66-dbbc-4ad9-a939-94e5385f9ddb.png"
                },
                new FactData
                {
                    Title = "Tug can speak 7 languages fluently",
                    Description = "Tug is a polyglot and can communicate effectively in 7 different languages, including Klingon and Elvish. He's even created his own language called 'Tugish', which is a combination of English, Spanish, and dolphin noises.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101638487758864475/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_070cafd8-6962-4ebf-9508-7669121856c1.png"
                },
                new FactData
                {

                    Title = "Tug is a skilled archer",
                    Description = "Tug has won archery competitions at both national and international levels, and he once shot an apple off his own head while blindfolded. He's also invented his own type of bow called the 'Tug-O-Matic', which shoots arrows made of chocolate.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101640908534980618/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_27ecd4a7-3db2-415e-bd18-a3909a906add.png"
                },
                new FactData
                {
                    Title = "Tug is a published author",
                    Description = "Tug has written a bestselling novel and it has been translated into 15 languages. The book is a thrilling adventure story about a bear who learns to fly airplanes and saves the world from an alien invasion.Tug also wrote a cookbook called 'Bear Grills', which features recipes for cooking food over an open flame.",
                    Image = "https://cdn.discordapp.com/attachments/1095445265290383491/1101638954098360400/LilTugboat_a_man_with_thick_black_hair__bushy_medium-sized_bear_ce24dbb0-2e1a-488e-91c2-5c2bcc7872e0.png"
                }
            };
        }
    }
}
