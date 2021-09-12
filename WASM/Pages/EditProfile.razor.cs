using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackRegistration.Models;
using HackRegistration.HttpRepository;
using Microsoft.AspNetCore.Components.Forms;

namespace HackRegistration.Pages
{
    public partial class EditProfile : ComponentBase
    {
        public List<Hacks> listHacks { get; set; }
        public Hacks Hacks { get; set; } = new Hacks();

        [Inject]
        public NavigationManager Navmanager { get; set; }

        [Inject]
        public IHacksHttpRepository repository { get; set; }

        private EditContext editContext { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (Id != "0")
            {
                Hacks = await repository.GetHacksById(int.Parse(Id));
            }
            else
            {
                Hacks = new Hacks();
            }

            editContext = new EditContext(Hacks);
        }

        public async Task UpdateProfile(int id, Hacks hacks)
        {
            //if (editContext.Validate())
            //{
                string response = string.Empty;
                if (id != 0)
                {
                    response = await repository.UpdateHacks(id, hacks);
                }
                else
                {
                    response = await repository.InsertHacks(hacks);
                }
                if (response != "Success")
                {
                    toastservice.ShowToast("UnSuccessful Transaction", ToastLevel.Error);
                }
                else
                {
                    Navmanager.NavigateTo("Registration");
                }
            //}
        }
    }
}
