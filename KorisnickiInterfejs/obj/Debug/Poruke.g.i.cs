﻿#pragma checksum "..\..\Poruke.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F8DEAA8A5230C3D67038F4BB858C11314CA16C8"
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
    /// Poruke
    /// </summary>
    public partial class Poruke : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtRadnici;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbRadnici;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbPosaljiSvima;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPoruka;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrimljenePoruke;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPosaljiPoruku;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Poruke.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiPoruke;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/poruke.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Poruke.xaml"
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
            
            #line 8 "..\..\Poruke.xaml"
            ((KorisnickiInterfejs.Poruke)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRadnici = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.cmbRadnici = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbPosaljiSvima = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.tbPoruka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbPrimljenePoruke = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnPosaljiPoruku = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\Poruke.xaml"
            this.btnPosaljiPoruku.Click += new System.Windows.RoutedEventHandler(this.BtnPosaljiPoruku_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnObrisiPoruke = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\Poruke.xaml"
            this.btnObrisiPoruke.Click += new System.Windows.RoutedEventHandler(this.BtnObrisiPoruke_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

