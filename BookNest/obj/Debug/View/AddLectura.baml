   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.AddLectura   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  
AddLectura��5   	   $	��650��6   $	��480��6)    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6    j� Stretch$
 None=�6>   6O   ._�5   
   �� $ 25��6   ���#ddd5c1���#b3964f$��15q�6O    J� Opacity$
 0.90Q�6d   ._�5      � -   5        	 �Name$	 gridPrincipal��5      ���	#FFEDE5D1$��0,0,-5,0q�6A   
 � RowDefinitions
 5      �� 5      $��0.35* �6$   �� 5      $��0.35* �6$   �� 5      $
��2.7* �6$   �� 5      $
��0.5* �6$   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��66   ���#b3964f.+�5      �� -   5         ��Name$ labelTitulo��5      $��ELEGIR LECTURA��61   $
��Bold"�6J   
�������$��30(�6o   ���	#FFB39F4F$��0��6�   $��Center=�6�   $��Center=�6�   $��
110,0,-5,5q�6�   5      �� 5      $ 
Horizontal=�6   $��1��66   $��Center=�6C   $��0,0,0,5q�6`   .+�5      �� -   5         ��Name$ txtBusqueda��5      $	��300��63   $��30��6?   $��16(�6K   �� 5       -   5         ��Name$ botonBusqueda��5       $��27��64   $��29��6?   ���	#FFD1A55E.��5!      �� $��/Images/search.png��6     J� OpacityMask
 �����6R   5"      5#      �� 5$      -   5         ��Name$ scrollLibros��5$      $
��Auto=�65   $��Hidden=�6Z   $��
10,23,10,0q�6   $��2��6�   .��5%      �� -   5         ��Name$ panelLibros��5%   !   $ Vertical=�66   5&      �� 5'      $ 
Horizontal=�6   $��Right=�66   $��3��6R   $��Center=�6_   .+�5(      �� -   5        $ botonVolver��5(      $��40��62   $��Volver��6>   $��Italic$�6O   $
��Bold"�6b   $��20(�6t   $��0,0,20,0q�6�   ���	#FF51370C
�������$	��142��6�   6�   5)      5*      5+      5,      5-      