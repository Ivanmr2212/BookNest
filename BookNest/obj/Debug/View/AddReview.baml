   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.AddReview   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  	AddReview��5   	   $	��700��6   $	��500��6(    � WindowStyle$
 None=�67    � 
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
�������$��Center=�6U   $��24(�6r   $��Crear Review��6�   $y�	Collapsed=�6�   6�   �� 5%      -   5        $ labelModificar��5%      $
��Bold"�64   
�������$��Center=�6Y   $��24(�6v   $��Cambiar Review��6�   $y�	Collapsed=�6�   6�   �� 5&      $ Vertical=�6!   $��	40,20,0,0q�68   $
��Left=�6K   .+�5'      �� $��Libro:��6    $��Italic$�61   $
��Bold"�6D   $��24(�6V   
�������$	��324��6w   6�   �� 5(      -   5         ��Name$ 	txtTitulo��5(   "   $��16(�65   $
��Bold"�6C   $��Italic$�6U   
������  �� 
CaretBrush
 �   �
���   �$��0,0,0,1q�6�   $��28��6�   $��Center=�6�   $��0,0,0,0q�6�    �� 
IsReadOnly . 6  5)      �� 5*      $ Vertical=�6!   $��	30,20,0,0q�69   $
��Left=�6L   .+�5+      �� $ 
Horizontal=�6%   .+�5,      �� $��Puntuación:��6$   $��Italic$�6:   $
��Bold"�6M   $��24(�6_   
�������6�   �� 5-      -   5         ��Name$ star1��5-   %   
 � Tag$ 1��64   $��40��6<   $��40��6H   $��0q�6S   ��5.   "   �� 5/   &   $ /Images/starEmpty.png��61   51      �� 52      -   5        $ star2��52   %   $ 2��64   $��40��6<   $��40��6H   $��0q�6S   ��53   "   �� 54   &   $ /Images/starEmpty.png��61   56      �� 57      -   5        $ star3��57   %   $ 3��64   $��40��6<   $��40��6H   $��0q�6S   ��58   "   �� 59   &   $ /Images/starEmpty.png��61   5;      �� 5<      -   5        $ star4��5<   %   $ 4��64   $��40��6<   $��40��6H   $��0q�6S   ��5=   "   �� 5>   &   $ /Images/starEmpty.png��61   5@      �� 5A      -	   5        $ star5��5A   %   $ 5��64   $��40��6<   $��40��6H   $��0q�6S   ��5B   "   �� 5C   &   $ /Images/starEmpty.png��61   5E      5F      �� 5G      -
   5         ��Name$ panelCatActual��5G   %   $ 
Horizontal=�6=   $y�	Collapsed=�6V   .+�5H      �� $��Actual: ��6$   $��Italic$�67   $
��Bold"�6J   $��24(�6\   
�������6   �� 5I      -   5        $ labelCatActual��5I   $   $��Italic$�6<   $
��Bold"�6O   $��24(�6a   
�������6�   5J      5K      �� 5L      $ Vertical=�6!   $��0,20,0,0q�68   $��Center=�6J   .+�5M      �� -   5        $ txtContenido��5M   "   $��16(�68   $
��Bold"�6F   $��Italic$�6X   $	��324��6k   $	��324��6w    �� TextWrapping$
 Wrap=�6�   5N      �� 5O      $ 
Horizontal=�6!   $��0,20,0,0q�6:   $��Center=�6L   .+�5P      �� -   5        $ botonCancelar��5P   !   $��Cancelar��68   ���	#FF51370C
�������$��30(�6u   $��0,0,5,0q�6�   $	��120��6�   6�   �� 5Q      -   5        $ botonAddReview��5Q   !   $��Aceptar��69   ���	#FF51370C
�������$��30(�6u   $��5,0,0,0q�6�   $	��120��6�   $y�	Collapsed=�6�   6�   �� 5R      -   5        $ botonModReview��5R   !   $��	Modificar��69   ���	#FF51370C
�������$��30(�6w   $��5,0,0,0q�6�   $	��120��6�   $y�	Collapsed=�6�   6�   5S      5T      5U      5V      5W      5X      