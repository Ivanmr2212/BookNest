   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.modReto   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  modReto��5   	   $	��410��6   $	��450��6&    � WindowStyle$
 None=�65    � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterScreen=�5
      
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6    j� Stretch$
 None=�6>   6O   ._�5   
   �� $ 20��6   ���#ddd5c1���#b3964f$��5q�6O    J� Opacity$
 0.95Q�6c   ._�5      � 	 � RowDefinitions	 5      �� 5      
 � ColumnDefinitions
 5      �� 5      $
��0.3* �6'   �� 5      �� 5      $
��0.3* �6'   .+�5      ��  �� Orientation$ Vertical=�6   $��1��64   ���	#FFB3964F.+�5      �� $ 
Horizontal=�6!   $��0,20,0,0q�6:   $��Center=�6L   $	��242��6i   .+�5      �� $��/Images/logo.png��6    $��51��6:    J� OpacityMask
 �����6[   �� 5       $
��Bold"�6    
�������$��Center=�6E   $��34(�6b   .��5!      �� $��BookNest��6(   $��	Underline{�68   5"      5#      �� 5$      $
��Bold"�6   
�������$��Center=�6A   $��24(�6^   $��Actualizar reto��6l   $��Italic$�6�   6�   �� 5%      $ 
Horizontal=�6!   $��0,40,0,0q�6:   $��Center=�6L   .+�5&      �� $��Libros leidos:��6    $��Italic$�69   $
��Bold"�6L   $��24(�6^   
�������$	��156��6   �� 5'      $ Vertical=�6%   $��10,0,0,0q�6<   .+�5(      �� -   5         ��Name$ sliderNumero��5(   %    � Minimum$ 0Q�6;    � Maximum$ 50Q�6G    �� TickFrequency$ 1Q�5)       �� IsSnapToTickEnabled . $	��100��6:   �� 5*      -   5         ��Name$ 
labelTotal��5*   $   $��0,10,0,0q�68   $��16(�6J   $��0��6X   $��Italic$�6d   $
��Bold"�6w   
�������6�   5+      5,      �� 5-      $ Vertical=�6!   $��0,10,0,0q�68   $��Center=�6J   .+�5.      �� $��Fin del reto:��6    $��Italic$�68   $
��Bold"�6K   $��24(�6]   
�������$	��156��6~   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ fechaPicker��5/   %   $	��249��6e      SelectedDate 6:   �� *FechaSeleccionada+6e   50      �� 51      $ 
Horizontal=�6!   $��0,20,0,0q�6:   $��Center=�6L   .+�52      �� -   5         ��Name$ botonCancelar��52   !   $��Cancelar��68   ���	#FF51370C
�������$��30(�6u   $��0,0,5,0q�6�   $	��120��6�   6�   �� 53      -   5        $ botonModReto��53   !   $��Aceptar��67   ���	#FF51370C
�������$��30(�6s   $��5,0,0,0q�6�   $	��120��6�   6�   54      55      56      57      58      59      