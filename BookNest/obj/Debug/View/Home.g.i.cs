﻿#pragma checksum "..\..\..\View\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FCCF5972C42A77FB1C115B5CD174491DC9869E2793472E68CEBD4251B51D0685"
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
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonMinimizar;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonCerrar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonBusqueda;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonLibreria;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonClubs;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonUsuarios;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonPerfil;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botonSalir;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelBienvenida;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelNovedades;
        
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
            System.Uri resourceLocater = new System.Uri("/MyReads;component/view/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Home.xaml"
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
            
            #line 12 "..\..\..\View\Home.xaml"
            ((MyReads.View.Home)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BotonMinimizar = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\View\Home.xaml"
            this.BotonMinimizar.Click += new System.Windows.RoutedEventHandler(this.BotonMinimizar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BotonCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\View\Home.xaml"
            this.BotonCerrar.Click += new System.Windows.RoutedEventHandler(this.BotonCerrar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.botonBusqueda = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\View\Home.xaml"
            this.botonBusqueda.Click += new System.Windows.RoutedEventHandler(this.botonBusqueda_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.botonLibreria = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\View\Home.xaml"
            this.botonLibreria.Click += new System.Windows.RoutedEventHandler(this.botonLibreria_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.botonClubs = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\View\Home.xaml"
            this.botonClubs.Click += new System.Windows.RoutedEventHandler(this.botonClubs_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.botonUsuarios = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\View\Home.xaml"
            this.botonUsuarios.Click += new System.Windows.RoutedEventHandler(this.botonUsuarios_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.botonPerfil = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\View\Home.xaml"
            this.botonPerfil.Click += new System.Windows.RoutedEventHandler(this.botonPerfil_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.botonSalir = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\View\Home.xaml"
            this.botonSalir.Click += new System.Windows.RoutedEventHandler(this.BotonCerrar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.labelBienvenida = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.panelNovedades = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

