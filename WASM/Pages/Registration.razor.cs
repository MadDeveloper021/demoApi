using HackRegistration.HttpRepository;
using HackRegistration.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HackRegistration.Pages
{
    public partial class Registration
    {
        public List<Hacks> listHacks { get; set; } = new List<Hacks>();

        [Inject]
        public IHacksHttpRepository repository { get; set; }

        [Inject]
        public NavigationManager Navmanager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            listHacks = await repository.GetHacks();
        }

        private void Delete()
        {
            if (selectedIds.Count == 0)
            {
                toastservice.ShowToast("You cannot perform the action if check boxes are not selected", ToastLevel.Error);
            }
            else
            {
                DeleteConfirmation.Show();                
            }
        }

        public void NewProfile()
        {
            Navmanager.NavigateTo("edit/0");
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                StringBuilder sb = new StringBuilder();
                int counter = selectedIds.Count;
                foreach (var item in selectedIds)
                {
                    if (counter == 1)
                    {
                        sb.Append(item.ToString());
                    }
                    else
                    {

                        sb.Append(item.ToString());
                        sb.Append(";");
                        counter--;
                    }

                }

                string response = await repository.DeleteHacks(sb.ToString());
                if (response != "Success")
                {
                    toastservice.ShowToast("UnSuccessful Transaction", ToastLevel.Error);
                }
                else
                {
                    listHacks = await repository.GetHacks();
                    selectedIds = new List<int>();
                }
            }
        }
    }
}
