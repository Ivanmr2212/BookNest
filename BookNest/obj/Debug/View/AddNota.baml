   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.AddNota   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  AddNota��5   	   $	��700��6   $	��500��6&    � WindowStyle$
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
��0.3* �6'   .+�5      ��  �� Orientation$ Vertical=�6   ���	#FFB3964F$��3��6K   $��	46,0,46,0q�6_   .+�5      �� $ 
Horizontal=�6!   $��0,20,0,0q�6:   $��Center=�6L   $	��242��6i   .+�5      �� $��/Images/logo.png��6    $��51��6:    J� OpacityMask
 �����6[   �� 5       $
��Bold"�6    
�������$��Center=�6E   $��34(�6b   .��5!      �� $��BookNest��6(   $��	Underline{�68   5"      5#      �� 5$      -   5         ��Name$ 
labelCrear��5$      $
��Bold"�60   
�������$��Center=�6U   $��24(�6r   $��
Crear nota��6�   $y�	Collapsed=�6�   6�   �� 5%      -   5        $ labelModificar��5%      $
��Bold"�64   
�������$��Center=�6Y   $��24(�6v   $��Modificar nota��6�   $y�	Collapsed=�6�   6�   �� 5&      $ Vertical=�6!   $��	40,20,0,0q�68   $
��Left=�6K   .+�5'      �� $��Titulo:��6    $��Italic$�62   $
��Bold"�6E   $��24(�6W   
�������$	��324��6x   6�   �� 5(      -   5         ��Name$ 	txtTitulo��5(   "   $��16(�65   $
��Bold"�6C   $��Italic$�6U   
������  �� 
CaretBrush
 �   �
���   �$��0,0,0,1q�6�   $��28��6�   $��Center=�6�   $��0,0,0,0q�6�   6  5)      �� 5*      $ Vertical=�6!   $��	40,20,0,0q�69   $
��Left=�6L   .+�5+      �� $ 
Horizontal=�6%   .+�5,      �� $��	Categoria��6$   $��Italic$�68   $
��Bold"�6K   $��24(�6]   
�������$	��127��6~   6�   �� 5-      -   5         ��Name$ comboBoxCategorias��5-   '   $��0,0,0,0q�6C   $	��148��6T   $��16(�6`   $
��Bold"�6n   $��Italic$�6�   6�   �� 5.      -   5         ��Name$ botonAddCategoria��5.   %   $��46��6@   $��46��6L   $��0q�6W   ��5/   "   �� 50   &   $ /Images/mas.png��61   52      53      �� 54      -   5         ��Name$ panelCatActual��54   %   $ 
Horizontal=�6=   $y�	Collapsed=�6V   .+�55      �� $��Actual: ��6$   $��Italic$�67   $
��Bold"�6J   $��24(�6\   
�������6   �� 56      -   5        $ labelCatActual��56   $   $��Italic$�6<   $
��Bold"�6O   $��24(�6a   
�������6�   57      58      �� 59      $ Vertical=�6!   $��0,20,0,0q�68   $��Center=�6J   .+�5:      �� -	   5        $ txtContenido��5:   "   $��16(�68   $
��Bold"�6F   $��Italic$�6X   $	��324��6k   $	��324��6w    �� TextWrapping$
 Wrap=�6�   5;      �� 5<      $ 
Horizontal=�6!   $��0,20,0,0q�6:   $��Center=�6L   .+�5=      �� -
   5        $ botonCancelar��5=   !   $��Cancelar��68   ���	#FF51370C
�������$��30(�6u   $��0,0,5,0q�6�   $	��120��6�   6�   �� 5>      -   5        $ botonAddNota��5>   !   $��Aceptar��67   ���	#FF51370C
�������$��30(�6s   $��5,0,0,0q�6�   $	��120��6�   $y�	Collapsed=�6�   6�   �� 5?      -   5        $ botonModNota��5?   !   $��	Modificar��67   ���	#FF51370C
�������$��30(�6u   $��5,0,0,0q�6�   $	��130��6�   $y�	Collapsed=�6�   6�   5@      5A      5B      5C      5D      5E      