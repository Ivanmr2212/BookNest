   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.Busqueda   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  Busqueda��5   	   $	��450��6   $	��800��6'    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency . .��5      �� ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6    j� Stretch$
 None=�6>   6O   ._�5   
   ��  �� CornerRadius$ 0��6   ���#ddd5c1���#b3964f$��5q�6N    J� Opacity$
 0.95Q�6b   ._�5      � ���	#FFEDE5D1	 � ColumnDefinitions	 5      �� 5      $
��0.3* �6'   �� 5      
 � RowDefinitions
 5      �� 5      $��0.08* �6$   �� 5      $
��0.2* �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��66   $��1��6C   $��Right=�6S   .+�5      �� -   5         ��Name$ BotonMinimizar��5      ���#b3964f$��0q�6J   $��-��6^   
���   �$��20(�6}   $��
Montserrat)�6�    � Cursor$
 Hand��6�   $��0��6�   $��0,0,0,0q�6�   $��30��6�   $��Right=�6�   �� 5      -   5        $ BotonCerrar��5      ���#b3964f$��0q�6H   $��X��6\   
���   �$��20(�6{   $��
Montserrat)�6�   $
 Hand��6�   $��1��6�   $��30��6�   $��Center=�6�   $��3��6�   $��0,0,0,0q�6�   $��30��6%  $��Right=�60  6O  5       �� 5!      $ Vertical=�6   $��3��64   ���	#FFB3964F.+�5"      �� $
��Bold"�6   
�������$��Center=�6A   $��34(�6^   .��5#      �� $��BookNest��6$   $��	Underline{�64   5$      �� 5%      $
��Bold"�6   
�������$��Center=�6A   $��24(�6^   $��Filtros��6l   6�   �� 5&      $��Generos��6   $
��Bold"�6.   
�������$
��Left=�6S   $��20(�6n   $��5,10,0,0q�6|   6�   �� 5'      -   5         ��Name$ comboBoxGeneros��5'      $	��150��68   $��40��6D   $��16(�6P   ���	#FFB3964F���	#FFB3964F
���   �$
��Left=�6�   $��10,0,0,0q�6�   ��5(      �� 5)       �� 
TargetType" ��6$   .�5*   "   ��  �� Property � �� �� Value �	#FF51370C6?   �� 5+   "    � ��
 �����6?   5,      5.      �� 5/      $��Publicacion��6   $
��Bold"�62   
�������$
��Left=�6W   $��20(�6r   $��5,10,0,0q�6�   6�   	� 50      -   5         	�Name$ radioButton2010��50   "   $��2010-Actual��6;   $��16(�6Q   
�������$��20,0,0,0q�6r   $��Center=�6�   6�   	� 51      -   5        $ radioButton2000��51   "   $��	2000-2009��6;   $��16(�6O   
�������$��20,0,0,0q�6p   $��Center=�6�   6�   	� 52      -   5        $ radioButton1999��52   "   $��Anterior-1999��6;   $��16(�6S   
�������$��20,0,0,0q�6t   $��Center=�6�   6�   �� 53      $��Cant. Páginas��6   $
��Bold"�64   
�������$
��Left=�6Y   $��20(�6t   $��5,10,0,0q�6�   6�   �� 54      -   5         ��Name$ check800��54      $��Largo(+800)��61   $��16(�6G   
�������$��20,0,0,0q�6h   $��Center=�6z   6�   �� 55      -	   5        $ check400��55      $��Mediano (400-799)��61   $��16(�6M   
�������$��20,0,0,0q�6n   $��Center=�6�   6�   �� 56      -
   5        $ check399��56      $��Pequeño (-399)��61   $��16(�6J   
�������$��20,0,0,0q�6k   $��Center=�6}   6�   �� 57      -   5        $ botonQuitarFiltro��57      $��Quitar filtros��68   $��Italic$�6Q   $
��Bold"�6d   $��16(�6v   $��0,10,0,0q�6�   ���	#FF51370C
�������$��Center=�6�   6�   58      �� 59      $ Vertical=�6   $��1��64   $��1��6A   .+�5:      �� $
��Bold"�6   $+��%Filtra por titulo, autor o editorial:��6.   $��16(�6^   $��Center=�6l   6�   �� 5;      $ 
Horizontal=�6!   $��Center=�6:   .+�5<      �� -   5         ��Name$ txtBusqueda��5<   "   $	��455��67   $��0,0,0,0q�6C   $��30��6T   6`   �� 5=      $��/Images/search.png��6    $��27��6<    J� OpacityMask
 �����$��39��6[   6i   5>      5?      �� 5@      $ Vertical=�6   $��2��64   $��2��6A   .+�5A      &   System.Windows.Controls.DataGrid  -   5          Name$ gridBusqueda��5A      $��14(�65      
IsReadOnly .    AutoGenerateColumns .     HeadersVisibility$ Column=�6�      RowBackground
 �����   AlternatingRowBackground
 �����
���   �$��2q�6      CanUserAddRows .     CanUserDeleteRows .     CanUserResizeColumns .    SelectionMode$ Single=�6a      SelectionUnit$  FullRow=�6x  !   HorizontalGridLinesBrush
! �����"   VerticalGridLinesBrush
" �����$	��553��6�  $��0,20,0,0q�6�  $	��255��6�  ��6C   �� *Libro+#   ColumnHeaderStyle# 5B      �� 5C      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5D   "   ��  � �� �	#FFB3964F6?   �� 5E   "    � ��
 �����6?   �� 5F   "    � ��$
 Bold"�6?   �� 5G   "    � ��$ 10q�6<   5H      $   Columns$ 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn%   Header$% Titulo��61   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6A   �� *titulo+  5L      $% Autor��61   & 6@   �� *autor+  5M      $% 	Editorial��61   & 6D   �� *	editorial+  5N      $% Publicacion��61   & 6F   �� *year+  5O      $% NumPags��61   & 6B   �� *	numPags+5Q      �� 5R      $ 
Horizontal=�6!   $��0,30,0,0q�6:   $��Center=�6L   .+�5S      �� -   5        $ botonSelect��5S   !   $��Seleccionar Libro��66   $��Italic$�6R   $
��Bold"�6e   $��20(�6w   $��0,0,5,0q�6�   ���	#FF51370C
�������6�   �� 5T      -   5        $ botonCancel��5T   !   $��Cancelar Busqueda��66   $��Italic$�6R   $
��Bold"�6e   $��20(�6w   $��5,0,0,0q�6�   ���	#FF51370C
�������6�   �� 5U      -   5        $ botonGenerateLibros��5U   !   $��Generar Libros��6>   $��Italic$�6W   $
��Bold"�6j   $��20(�6|   $��50,0,0,0q�6�   ���	#FF51370C
�������6�   5V      5W      �� 5X      $
��Left=�6   $��2��67   $	��510��6K   $��3��6X   $��184,-30,0,0q�6i   
���   �$	��Top=�6�   $��2��6�   ' �� RadiusY$' 5��6�   ( J� RenderTransformOrigin$( 0.5,0.5&�6�   $��2��6�   z�5Y      V� 5Z      .~�5[      �� ) �� ScaleX$) -1Q�6-   �� 5\      �� 5]      T� 5^      5_      5a      5b      5c      5d      5e      