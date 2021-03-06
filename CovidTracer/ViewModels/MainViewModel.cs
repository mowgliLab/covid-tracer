﻿// Copyright 2020 Raphael Javaux
//
// This file is part of CovidTracer.
//
// CovidTracer is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// CovidTracer is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with CovidTracer. If not, see<https://www.gnu.org/licenses/>.

using CovidTracer.Services;

namespace CovidTracer.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //
        // Infection status
        //

        ContactDatabase.InfectionStatus status;
        public ContactDatabase.InfectionStatus Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        string statusTitle;
        public string StatusTitle
        {
            get { return statusTitle; }
            set { SetProperty(ref statusTitle, value); }
        }

        string statusText;
        public string StatusText
        {
            get { return statusText; }
            set { SetProperty(ref statusText, value); }
        }

        string statusTextColor;
        public string StatusTextColor
        {
            get { return statusTextColor; }
            set { SetProperty(ref statusTextColor, value); }
        }

        string statusBackgroundColor;
        public string StatusBackgroundColor
        {
            get { return statusBackgroundColor; }
            set { SetProperty(ref statusBackgroundColor, value); }
        }

        // --

        public MainViewModel(ContactDatabase contacts)
        {
            OnInfectionStatusChange(this, contacts.CurrentInfectionStatus);
            contacts.CurrentInfectionStatusChange += OnInfectionStatusChange;
        }

        public void OnInfectionStatusChange(object sender,
            ContactDatabase.InfectionStatus newStatus)
        {
            Status = newStatus;

            switch (newStatus) {
            case ContactDatabase.InfectionStatus.Safe:
                StatusTitle = Resx.Localization.MainStatusSafeTitle;
                StatusText = Resx.Localization.MainStatusSafeText;
                StatusTextColor = "#313a33";
                StatusBackgroundColor = "#d4edda";
                break;
            case ContactDatabase.InfectionStatus.Symptomatic:
                StatusTitle = Resx.Localization.MainStatusSymptomaticTitle;
                StatusText = Resx.Localization.MainStatusSymptomaticText;
                StatusTextColor = "#856404";
                StatusBackgroundColor = "#fff3cd";
                break;
            case ContactDatabase.InfectionStatus.Positive:
                StatusTitle = Resx.Localization.MainStatusPositiveTitle;
                StatusText = Resx.Localization.MainStatusPositiveText;
                StatusTextColor = "#721c24";
                StatusBackgroundColor = "#f8d7da";
                break;
            };
        }
    }
}