﻿#pragma checksum "..\..\PretragaPraznika.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2192988945ABC90DC7B0D54E6B3323DF0AA444A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KorisnickiInterfejs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace KorisnickiInterfejs {
    
    
    /// <summary>
    /// PretragaPraznika
    /// </summary>
    public partial class PretragaPraznika : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDatumPraznika;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPretragaPraznika;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPregledPraznika;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiPraznik;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\PretragaPraznika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajPraznik;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/pretragapraznika.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PretragaPraznika.xaml"
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
            
            #line 8 "..\..\PretragaPraznika.xaml"
            ((KorisnickiInterfejs.PretragaPraznika)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbDatumPraznika = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnPretragaPraznika = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\PretragaPraznika.xaml"
            this.btnPretragaPraznika.Click += new System.Windows.RoutedEventHandler(this.BtnPretragaPraznika_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnPregledPraznika = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\PretragaPraznika.xaml"
            this.btnPregledPraznika.Click += new System.Windows.RoutedEventHandler(this.BtnPregledPraznika_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnObrisiPraznik = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\PretragaPraznika.xaml"
            this.btnObrisiPraznik.Click += new System.Windows.RoutedEventHandler(this.BtnObrisiPraznik_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDodajPraznik = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\PretragaPraznika.xaml"
            this.btnDodajPraznik.Click += new System.Windows.RoutedEventHandler(this.BtnDodajPraznik_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

