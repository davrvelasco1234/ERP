﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP_Components;
using ERP_MVVM.BaseMVVM;
using Microsoft.Toolkit.Mvvm.Input;

using System.Linq;
using System.ComponentModel;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using System.Windows;

namespace ERP_SettingsCom.ViewModels
{
    public class SettingsViewModel : BaseViewModel, IComponentView
    {

        #region Fields
        private const string FontSmallger = "smallger";
        private const string FontSmall = "small";
        private const string FontMedium = "medium";
        private const string FontBig = "big";
        private const string FontBigger = "bigger";

        private const string FontLarge = "large";

        private const string PaletteMetro = "metro";
        private const string PaletteWP = "windows phone";


        // 9 accent colors from metro design principles
        private Color[] metroAccentColors = new Color[]{
            Color.FromRgb(0x33, 0x99, 0xff),   // blue
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x33, 0x99, 0x33),   // green
            Color.FromRgb(0x8c, 0xbf, 0x26),   // lime
            Color.FromRgb(0xf0, 0x96, 0x09),   // orange
            Color.FromRgb(0xff, 0x45, 0x00),   // orange red
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xff, 0x00, 0x97),   // magenta
            Color.FromRgb(0xa2, 0x00, 0xff),   // purple            
        };

        // 20 accent colors from Windows Phone 8
        private Color[] wpAccentColors = new Color[]{
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
            Color.FromRgb(0x87, 0x79, 0x4e),   // taupe
        };

        private string selectedPalette = PaletteWP;

        private Color selectedAccentColor;
        private LinkCollection themes = new LinkCollection();
        private Link selectedTheme;
        private string selectedFontSize;
        #endregion


        #region Properties
        
        #endregion


        #region Commands
        public ICommand LoadedCommand => new Microsoft.Toolkit.Mvvm.Input.RelayCommand(Loaded);
        #endregion


        #region Services

        #endregion

        #region Contructors
        public SettingsViewModel()
        {
            // add the default themes
            this.themes.Add(new Link { DisplayName = "dark", Source = AppearanceManager.DarkThemeSource });
            this.themes.Add(new Link { DisplayName = "light", Source = AppearanceManager.LightThemeSource });

            // add additional themes
            //this.themes.Add(new Link { DisplayName = "bing image", Source = new Uri("/ModernUIDemo;component/Assets/ModernUI.BingImage.xaml", UriKind.Relative) });
            //this.themes.Add(new Link { DisplayName = "hello kitty", Source = new Uri("/ModernUIDemo;component/Assets/ModernUI.HelloKitty.xaml", UriKind.Relative) });
            //this.themes.Add(new Link { DisplayName = "love", Source = new Uri("/ModernUIDemo;component/Assets/ModernUI.Love.xaml", UriKind.Relative) });
            //this.themes.Add(new Link { DisplayName = "snowflakes", Source = new Uri("/ModernUIDemo;component/Assets/ModernUI.Snowflakes.xaml", UriKind.Relative) });
            this.SelectedTheme = this.themes.FirstOrDefault();
            //this.SelectedFontSize = AppearanceManager.Current.FontSize == FontSize.Large ? FontLarge : FontSmall;
            this.SelectedFontSize = FontMedium;
            SyncThemeAndColor();

            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;

        }
        #endregion


        #region Loaded
        public void Loaded()
        {

        }
        #endregion


        #region Methods


        private void SyncThemeAndColor()
        {
            // synchronizes the selected viewmodel theme with the actual theme used by the appearance manager.
            this.SelectedTheme = this.themes.FirstOrDefault(l => l.Source.Equals(AppearanceManager.Current.ThemeSource));

            // and make sure accent color is up-to-date
            this.SelectedAccentColor = AppearanceManager.Current.AccentColor;
        }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                SyncThemeAndColor();
            }
        }

        public LinkCollection Themes
        {
            get { return this.themes; }
        }

        

        public string[] FontSizes
        {
            get { return new string[] { FontSmallger, FontSmall, FontMedium, FontBig, FontBigger }; }
        }

        public string[] Palettes
        {
            get { return new string[] { PaletteMetro, PaletteWP }; }
        }

        public Color[] AccentColors
        {
            get { return this.selectedPalette == PaletteMetro ? this.metroAccentColors : this.wpAccentColors; }
        }

        public string SelectedPalette
        {
            get { return this.selectedPalette; }
            set
            {
                if (this.selectedPalette != value)
                {
                    this.selectedPalette = value;
                    OnPropertyChanged("AccentColors");

                    this.SelectedAccentColor = this.AccentColors.FirstOrDefault();
                }
            }
        }

        public Link SelectedTheme
        {
            get { return this.selectedTheme; }
            set
            {
                if (this.selectedTheme != value)
                {
                    this.selectedTheme = value;
                    OnPropertyChanged("SelectedTheme");

                    // and update the actual theme
                    AppearanceManager.Current.ThemeSource = value.Source;
                }
            }
        }

        /// <summary>
        /// The resource key for the default font size.
        /// </summary>
        public const string KeyDefaultFontSize = "DefaultFontSize";
        /// <summary>
        /// The resource key for the fixed font size.
        /// </summary>
        public const string KeyFixedFontSize = "FixedFontSize";
        public string SelectedFontSize
        {
            get { return this.selectedFontSize; }
            set
            {
                if (this.selectedFontSize != value)
                {
                    this.selectedFontSize = value;
                    OnPropertyChanged("SelectedFontSize");

                    if (this.selectedFontSize == FontSmallger)
                    {
                        Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmallger;
                        Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmallger;
                    }
                    else if (this.selectedFontSize == FontSmall)
                    {
                        Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;
                        Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;
                    }
                    else if (this.selectedFontSize == FontMedium)
                    {
                        Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeMedium;
                        Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeMedium;
                    }
                    else if (this.selectedFontSize == FontBig)
                    {
                        Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeBig;
                        Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeBig;
                    }
                    else if (this.selectedFontSize == FontBigger)
                    {
                        Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeBigger;
                        Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeBigger;
                    }
                }
            }
        }

        public Color SelectedAccentColor
        {
            get { return this.selectedAccentColor; }
            set
            {
                if (this.selectedAccentColor != value)
                {
                    this.selectedAccentColor = value;
                    OnPropertyChanged("SelectedAccentColor");

                    AppearanceManager.Current.AccentColor = value;
                }
            }
        }

        #endregion

    }
}
