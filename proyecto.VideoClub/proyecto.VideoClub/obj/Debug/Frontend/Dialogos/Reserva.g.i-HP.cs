﻿#pragma checksum "..\..\..\..\Frontend\Dialogos\Reserva.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F7F5DC71423254FB7C7779A1AB29736D491C72F7B224AE82B696B38BED7C3987"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using proyecto.VideoClub.Frontend.Dialogos;


namespace proyecto.VideoClub.Frontend.Dialogos {
    
    
    /// <summary>
    /// Reserva
    /// </summary>
    public partial class Reserva : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ReservaPortada;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtFechaAlq;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbItem;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReserva;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/proyecto.VideoClub;component/frontend/dialogos/reserva.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
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
            this.ReservaPortada = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.txtFechaAlq = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.cbItem = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnReserva = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
            this.btnReserva.Click += new System.Windows.RoutedEventHandler(this.btnReserva_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\Frontend\Dialogos\Reserva.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.btnCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
