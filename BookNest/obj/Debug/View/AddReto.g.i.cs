﻿#pragma checksum "..\..\..\View\AddReto.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "568E0FF9771960C9CE66AA3CF98E06E3D67546F5634C554BB73F4523F134C716"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MyReads.View;
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


namespace MyReads.View {
    
    
    /// <summary>
    /// AddReto
    /// </summary>
    public partial class AddReto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\View\AddReto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderNumero;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\View\AddReto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTotal;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\AddReto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker fechaPicker;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\View\AddReto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonCancelar;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\AddReto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonAddReto;
        
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
            System.Uri resourceLocater = new System.Uri("/MyReads;component/view/addreto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AddReto.xaml"
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
            
            #line 11 "..\..\..\View\AddReto.xaml"
            ((MyReads.View.AddReto)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sliderNumero = ((System.Windows.Controls.Slider)(target));
            
            #line 40 "..\..\..\View\AddReto.xaml"
            this.sliderNumero.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliderNumero_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.labelTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.fechaPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.botonCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\View\AddReto.xaml"
            this.botonCancelar.Click += new System.Windows.RoutedEventHandler(this.botonVolver_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.botonAddReto = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\View\AddReto.xaml"
            this.botonAddReto.Click += new System.Windows.RoutedEventHandler(this.botonAddReto_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

