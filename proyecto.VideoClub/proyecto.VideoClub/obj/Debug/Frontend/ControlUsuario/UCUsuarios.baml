   M S B A M L   `   `   `  ����M  Iproyecto.VideoClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:proyecto.VideoClub.Frontend.ControlUsuario*proyecto.VideoClub.Frontend.ControlUsuario  5      ;    5proyecto.VideoClub.Frontend.ControlUsuario.UCUsuarios   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:proyecto.VideoClub.Frontend.ControlUsuario     5      .��5	      ]� .+�5   
   � $	��Top=�6     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��4��6"   �� 5      $��USUARIOS��6   $
��Bold"�6(   $��16(�6:   $��
10,10,0,10q�6H   ���#9a010b6\   �� 5      $ ��/Recursos/img/usuarios.png��6   $��32��68   $��0��6D   $
��Left=�6T   $��	150,0,0,0q�6o   �� 5      ���#9a010b$��2��6-   $��Bottom=�6A   $��	10,0,10,0q�6]   6r   �� 5"      $��Buscar por apellido: ��6   $��DemiBold"�65   $��14(�6K   $��0��6Y   $
��Left=�6i   $��1��5#      $��20q�6%   $��Center=�61   ���#01579a6L   �� 5$      -   5         ��Name$ 
tbApellido��5$      $��1��6*   $��0��67   $	��180��6G   $��	-40,0,0,0q�6S   ���#444$��Center=�6x   $��Center=�5%      ��5&      �� *apellidoUsuario+ �� UpdateSourceTrigger$ PropertyChanged=�5'      �� 5)      ���#9a010b$��1��6-   $��2��6:   $��Bottom=�6N   $��	10,0,10,0q�6j   6   5*      � 5.   
   .+�50      &   System.Windows.Controls.DataGrid  -   5          Name$ dgListaUsuarios��50         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    SelectionMode$ Single=�52      	   AlternatingRowBackground	 �#eee��50   0   �� *listaUsuarios+
   Columns
 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *nombre+  57      $ Apellido��6)    6;   �� *
apellido_1+  58      $ 
Apellido 2��6)    6=   �� *
apellido_2+  59      $ 	Direccion��6)    6<   �� *	direccion+  5:      $
 Mail��6)    67   �� *mail+  5;      $ Telefono��6)    6;   �� *
telefono+  5<      $ Usuario��6)    6:   �� *
usuario1+ � ContextMenu 5B      �� 5C      .@�5D      m� -   5         m�Name$ 
itemEditar��5D   3   $��Editar��6#    m� Icon 5E      �� 5F   "   $��/Recursos/Img/edit.png��6)   5H      �� 5I      m� 5J      -   5        $ 
itemBorrar��5J   3   $��Borrar��6#   ���#9a010b 5K      �� 5L   "   $��/Recursos/Img/delete3.png��6)   5N      5Q      5S      5T      5U      5V      