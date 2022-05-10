﻿#pragma checksum "..\..\..\Notification\ToastPopUp.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36D71D46AA070D0E9E7F5BA9F271B18F2E2FFAED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ERP_MVVM.Notification;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ERP_MVVM.Notification {
    
    
    /// <summary>
    /// ToastPopUp
    /// </summary>
    public partial class ToastPopUp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderBackground;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageLeft;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageClose;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxTitle;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxShortDescription;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonView;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard StoryboardLoad;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\Notification\ToastPopUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard StoryboardFade;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ERP_MVVM;component/notification/toastpopup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Notification\ToastPopUp.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.borderBackground = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.imageLeft = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.imageClose = ((System.Windows.Controls.Image)(target));
            
            #line 94 "..\..\..\Notification\ToastPopUp.xaml"
            this.imageClose.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageMouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBoxShortDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.buttonView = ((System.Windows.Controls.Button)(target));
            
            #line 127 "..\..\..\Notification\ToastPopUp.xaml"
            this.buttonView.Click += new System.Windows.RoutedEventHandler(this.ButtonViewClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StoryboardLoad = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 8:
            
            #line 137 "..\..\..\Notification\ToastPopUp.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.DoubleAnimationCompleted);
            
            #line default
            #line hidden
            return;
            case 9:
            this.StoryboardFade = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 10:
            
            #line 152 "..\..\..\Notification\ToastPopUp.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.DoubleAnimationCompleted);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

