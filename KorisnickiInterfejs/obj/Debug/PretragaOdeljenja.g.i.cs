﻿#pragma checksum "..\..\PretragaOdeljenja.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02452AAA9E28BD2B73FF675D2681D8F2650AA5AF"
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
    /// PretragaOdeljenja
    /// </summary>
    public partial class PretragaOdeljenja : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSefOdeljenja;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBrojZaposlenih;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPretraziOdeljenje;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPregledOdeljenja;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiOdeljenje;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\PretragaOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajOdeljenje;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/pretragaodeljenja.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PretragaOdeljenja.xaml"
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
            
            #line 8 "..\..\PretragaOdeljenja.xaml"
            ((KorisnickiInterfejs.PretragaOdeljenja)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbSefOdeljenja = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbBrojZaposlenih = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnPretraziOdeljenje = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\PretragaOdeljenja.xaml"
            this.btnPretraziOdeljenje.Click += new System.Windows.RoutedEventHandler(this.BtnPretraziOdeljenje_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btnPregledOdeljenja = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\PretragaOdeljenja.xaml"
            this.btnPregledOdeljenja.Click += new System.Windows.RoutedEventHandler(this.BtnPregledOdeljenja_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnObrisiOdeljenje = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\PretragaOdeljenja.xaml"
            this.btnObrisiOdeljenje.Click += new System.Windows.RoutedEventHandler(this.BtnObrisiOdeljenje_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDodajOdeljenje = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\PretragaOdeljenja.xaml"
            this.btnDodajOdeljenje.Click += new System.Windows.RoutedEventHandler(this.BtnDodajOdeljenje_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
