   M S B A M L   `   `   `  ����M  Iproyecto.VideoClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:proyecto.VideoClub.Frontend.Dialogos$proyecto.VideoClub.Frontend.Dialogos  5   	   2    ,proyecto.VideoClub.Frontend.Dialogos.Reserva   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mat1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >local2clr-namespace:proyecto.VideoClub.Frontend.Dialogos  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Icon$ /Recursos/Img/popcorn.png��5
   	    � Title$ Reserva��5   	   $	��450��6   $	��800��6&   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��4��6   ���#01579a62   �� 5   
   $��RESERVA��6   $��2��6#   $��20q�67   $��28(�6C   
�������$��	ExtraBold"�6d   �� 5   
   $ ��/Recursos/img/reserva2.png��6   $��32��64   $��1��6@   $��Center=�6P   $��60,0,0,0q�6m   �� 5    
   $��1��6   $��2��6!   $2��,Los campos con este formato son obligatorios��61   $��10(�5!      $��
20,10,0,20q�6"   $��2��66   $
��Bold"�5"      $��Italic$�6&   �� 5'   
   $��1��6   $��4��6   $��1��6/   $��10q�6@   $��200px��6L   $��Center=�6Z   $��Center=�6w   ��5(      �� 5)       �� 
TargetType" ��6   .�5+      ��  �� Property �@J�Effect �� Value 5,      3  -System.Windows.Media.Effects.DropShadowEffect  5-         Color$ Black��6/   	   ShadowDepth$	 5Q�6=   
   Opacity$	
 0.3Q�6N   5/      50      ._�52      �� -   5         ��Name$ ReservaPortada��52      53      �� 57   
   $��3��6   $��2��6!   $��Fecha��61   $��
20,10,20,0q�6>   $��Center=�6R   $
��Bold"�58      $��Italic$�6&   (  "System.Windows.Controls.DatePicker  5:   
   -   5          Name$ txtFechaAlq��5:   3   $��3��6   $��4��6"   $��30��6H   $��
20,10,20,0q�6T    � Language$ es-Es�6h      MaterialDesignDatePicker#��[  5;      $	��200��6D      SelectedDate 5<      �� *alquilerNuevo.fecha_alquiler+ �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=��� 5@   
   $��2��6   $��Unidad disponible��6!   $��
20,10,20,0q�6:   $��Center=�6N   $
��Bold"�5A      $��Italic$�6&   $��2��69   �� 5B   
   -   5         ��Name$ cbItem��5B   0   $��4��6   $��2��6#   $��30��6@   $��
20,10,20,0q�6L     MaterialDesignComboBox#��[ 5C      $	��200��6B    �� DisplayMemberPath$ id_item��5D   G   ��6   �� *listaItemsDisponiblesProducto+6G   �� 5M   
   -   5         ��Name$ 
btnReserva��5N      $��3��5M      $��4��6!    �� 	IsDefault . $��20,20,20,20q�6?   $��Reservar��6T   $
��Left=�6g   ���#01579a
������ 5N   T   �� 5O   
   -   5        $ btnCancelar��5P      $��3��5O      $��4��6!    �� IsCancel . $��20,20,20,20q�6>   $��Cancelar��6S   $��Right=�6f   ���#9a010b  MaterialDesignFlatButton#��[ 5Q      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6C   5R      5S      