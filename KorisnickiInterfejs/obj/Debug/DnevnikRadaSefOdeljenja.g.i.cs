﻿#pragma checksum "..\..\DnevnikRadaSefOdeljenja.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F24F6266B494B2D55DDD7753A5F9EBBE5523DE9"
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
    /// DnevnikRadaSefOdeljenja
    /// </summary>
    public partial class DnevnikRadaSefOdeljenja : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbRadnik;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPonedeljak;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUtorak;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSreda;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCetvrtak;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPetak;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\DnevnikRadaSefOdeljenja.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPotvrdiDnevnik;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/dnevnikradasefodeljenja.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DnevnikRadaSefOdeljenja.xaml"
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
            
            #line 8 "..\..\DnevnikRadaSefOdeljenja.xaml"
            ((KorisnickiInterfejs.DnevnikRadaSefOdeljenja)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\DnevnikRadaSefOdeljenja.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbRadnik = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbPonedeljak = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbUtorak = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbSreda = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbCetvrtak = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbPetak = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnPotvrdiDnevnik = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\DnevnikRadaSefOdeljenja.xaml"
            this.btnPotvrdiDnevnik.Click += new System.Windows.RoutedEventHandler(this.BtnPotvrdiDnevnik_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

