   M S B A M L   `   `   `  ����M  Iproyecto.VideoClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:proyecto.VideoClub.Frontend.ControlUsuario*proyecto.VideoClub.Frontend.ControlUsuario  5      ?    9proyecto.VideoClub.Frontend.ControlUsuario.UCDatosUsuario   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:proyecto.VideoClub.Frontend.ControlUsuario     5      .��5	      ]� .+�5   
   � $	��Top=�6     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��4��6"   �� 5      $��	MIS DATOS��6   $
��Bold"�6)   $��16(�6;   $��
10,10,0,10q�6I   ���#9a010b6]   �� 5      ���#9a010b$��2��6-   $��Bottom=�6A   $��	10,0,10,0q�6]   6r   5      � 5!   
   .+�5$      &   System.Windows.Controls.DataGrid  -   5          Name$ dgListaUsuarios��5$       �� DisplayMemberPath$ nombre��6Z      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . ��60   �� *listaDatosUsuario+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *nombre+  5*      $ Apellido��6)   	 6;   �� *
apellido_1+  5+      $ 
Apellido 2��6)   	 6=   �� *
apellido_2+  5,      $ 	Direccion��6)   	 6<   �� *	direccion+  5-      $ Correo��6)   	 69   �� *mail+  5.      $ Telf.��6)   	 68   �� *
telefono+  5/      $ 
Fecha nac.��6)   	 6=   �� *fecha_nacimiento+  50      $ Usuario��6)   	 6:   �� *
usuario1+  51      $ Contraseña��6)   	 6=   �� *contraseña+53      54      55      56      