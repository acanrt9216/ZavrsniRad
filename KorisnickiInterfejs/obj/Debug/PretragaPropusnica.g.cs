﻿#pragma checksum "..\..\PretragaPropusnica.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BC7228700664408975B1F5A95551ABACB9F5DD3C"
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
    /// PretragaPropusnica
    /// </summary>
    public partial class PretragaPropusnica : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIme;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrezime;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbRazlog;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDatum;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPretragaPropusnice;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPregledPropusnice;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\PretragaPropusnica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiPropusnicu;
        
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
            System.Uri resourceLocater = new System.Uri("/KorisnickiInterfejs;component/pretragapropusnica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PretragaPropusnica.xaml"
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
            
            #line 8 "..\..\PretragaPropusnica.xaml"
            ((KorisnickiInterfejs.PretragaPropusnica)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbRazlog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbDatum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnPretragaPropusnice = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\PretragaPropusnica.xaml"
            this.btnPretragaPropusnice.Click += new System.Windows.RoutedEventHandler(this.BtnPretragaPropusnice_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.btnPregledPropusnice = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\PretragaPropusnica.xaml"
            this.btnPregledPropusnice.Click += new System.Windows.RoutedEventHandler(this.BtnPregledPropusnice_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnObrisiPropusnicu = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\PretragaPropusnica.xaml"
            this.btnObrisiPropusnicu.Click += new System.Windows.RoutedEventHandler(this.BtnObrisiPropusnicu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

