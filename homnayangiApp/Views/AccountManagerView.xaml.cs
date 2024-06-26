﻿using homnayangiApp.CustomControls;
using homnayangiApp.Models;
using homnayangiApp.ViewModels;
using UraniumUI.Dialogs.Mopups;
using UraniumUI.Material.Controls;

namespace homnayangiApp.Views;

public partial class AccountManagerView : ContentPage
{
	public AccountManagerView()
	{
		InitializeComponent();
        BindingContext = new AccountManagerViewModel();
	}

    private async void PickerField_SelectedValueChanged(object sender, object e)
    {
        var pk = (PickerField)sender;
        var result = (pk.SelectedItem as Province).province_id;
        await dataCity.Instance.getDictricts(result);
        var vm = (ViewModels.AccountManagerViewModel)BindingContext;
        vm.ListDistrict = dataCity.Instance.listDistrict;
        if (vm.CurentUser.City == (pk.SelectedItem as Province).province_name)
        {
            vm.DistrictUser = vm.CurentUser.Dictrict;
        }
        else
        {
            vm.DistrictUser = vm.ListDistrict[0];
        }
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        //var vm = (ViewModels.AccountManagerViewModel)BindingContext;
        //vm.loadImage();
    }
}