﻿#pragma checksum "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15E1DFCD08C8EEC122C30B7254F44500EC0A598408939001AA380F5687DB957A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using RootLibrary.WPF.Localization;
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
using proyecto.VideoClub.Frontend.ControlUsuario;


namespace proyecto.VideoClub.Frontend.ControlUsuario {
    
    
    /// <summary>
    /// UCAlquiler
    /// </summary>
    public partial class UCAlquiler : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkDevuelto;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbApellido;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgListaAlquiler;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem itemDevuelto;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem itemEntregado;
        
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
            System.Uri resourceLocater = new System.Uri("/proyecto.VideoClub;component/frontend/controlusuario/ucalquiler.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
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
            this.checkDevuelto = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
            this.checkDevuelto.Checked += new System.Windows.RoutedEventHandler(this.checkDevuelto_Checked);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
            this.checkDevuelto.Unchecked += new System.Windows.RoutedEventHandler(this.checkDevuelto_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbApellido = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
            this.tbApellido.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbApellido_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgListaAlquiler = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.itemDevuelto = ((System.Windows.Controls.MenuItem)(target));
            
            #line 102 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
            this.itemDevuelto.Click += new System.Windows.RoutedEventHandler(this.itemDevuelto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.itemEntregado = ((System.Windows.Controls.MenuItem)(target));
            
            #line 108 "..\..\..\..\Frontend\ControlUsuario\UCAlquiler.xaml"
            this.itemEntregado.Click += new System.Windows.RoutedEventHandler(this.itemEntregado_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

