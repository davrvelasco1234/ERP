﻿
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ERP_Core.Components;
using ERP_MVVM.Helpers;

namespace ERP_ButtonCom
{
    [Export(typeof(IComponentERP))]
    public class MainComponent : ComponentERP
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.BottomViewModel, Views.BottomControl>();
        }

        public override ComponentInfo ComponentInfo => new ComponentInfo
        {
            ComponentName = "Name",
            ComponentContent = "Content",
            ComponentCode = "Code",
            Title = "Title"
        };


        public override IComponentView GetInstansComponent()
        {
            return new ViewModels.BottomViewModel();
        }
    }
}


