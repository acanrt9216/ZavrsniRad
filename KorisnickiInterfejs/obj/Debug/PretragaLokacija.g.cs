﻿#pragma checksum "..\..\PretragaLokacija.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AF13C1ABA88875E13C5ADA69439372113ECE811C"
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
    /// PretragaLokacija
    /// </summary>
    public partial class PretragaLokacija : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbOpis;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPretragaLokacija;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPregledLokacije;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiLokaciju;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\PretragaLokacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajLokaciju;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/pretragalokacija.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PretragaLokacija.xaml"
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
            
            #line 8 "..\..\PretragaLokacija.xaml"
            ((KorisnickiInterfejs.PretragaLokacija)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\PretragaLokacija.xaml"
            ((KorisnickiInterfejs.PretragaLokacija)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbOpis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnPretragaLokacija = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\PretragaLokacija.xaml"
            this.btnPretragaLokacija.Click += new System.Windows.RoutedEventHandler(this.BtnPretragaLokacija_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnPregledLokacije = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\PretragaLokacija.xaml"
            this.btnPregledLokacije.Click += new System.Windows.RoutedEventHandler(this.BtnPregledLokacije_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnObrisiLokaciju = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\PretragaLokacija.xaml"
            this.btnObrisiLokaciju.Click += new System.Windows.RoutedEventHandler(this.BtnObrisiLokaciju_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDodajLokaciju = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\PretragaLokacija.xaml"
            this.btnDodajLokaciju.Click += new System.Windows.RoutedEventHandler(this.BtnDodajLokaciju_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

