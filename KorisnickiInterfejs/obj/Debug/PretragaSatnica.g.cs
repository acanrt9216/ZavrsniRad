﻿#pragma checksum "..\..\PretragaSatnica.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2E0D08DFA70752780282CF269C40E7CBD21EC264"
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
    /// PretragaSatnica
    /// </summary>
    public partial class PretragaSatnica : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbOpis;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBrojSati;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPretragaSatnica;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPregledSatnice;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiSatnicu;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\PretragaSatnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajSatnicu;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/pretragasatnica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PretragaSatnica.xaml"
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
            
            #line 8 "..\..\PretragaSatnica.xaml"
            ((KorisnickiInterfejs.PretragaSatnica)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
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
            this.tbBrojSati = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnPretragaSatnica = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\PretragaSatnica.xaml"
            this.btnPretragaSatnica.Click += new System.Windows.RoutedEventHandler(this.BtnPretragaSatnica_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btnPregledSatnice = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\PretragaSatnica.xaml"
            this.btnPregledSatnice.Click += new System.Windows.RoutedEventHandler(this.BtnPregledSatnice_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnObrisiSatnicu = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\PretragaSatnica.xaml"
            this.btnObrisiSatnicu.Click += new System.Windows.RoutedEventHandler(this.BtnObrisiSatnicu_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDodajSatnicu = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\PretragaSatnica.xaml"
            this.btnDodajSatnicu.Click += new System.Windows.RoutedEventHandler(this.BtnDodajSatnicu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

