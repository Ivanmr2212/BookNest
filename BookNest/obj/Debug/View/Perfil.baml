   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.Perfil   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  Perfil��5   	   $	��650��6   $	��450��6%    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6    j� Stretch$
 None=�6>   6O   ._�5   
   �� $ 25��6   ���#ddd5c1���#b3964f$��15q�6O    J� Opacity$
 0.90Q�6d   ._�5      � -   5        	 �Name$	 gridPrincipal��5      ���	#FFEDE5D1$��0,0,-5,0q�6A   
 � RowDefinitions
 5      �� 5      $
��0.7* �6$   �� 5      $��0.83* �6$   �� 5      $
��1.5* �6$   �� 5      $��* �6$   �� 5      $
��0.8* �6$   �� 5      $
��0.5* �6$   .+�5      �� $��
VER PERFIL��6   $
��Bold"�6-   
�������$��30(�6R   ���	#FFB39F4F$��0��6w   $��Center=�6�   $��Center=�6�   $��0,0,-5,5q�6�   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��1��66   $��10,0,0,0q�6C   .+�5      �� $ Vertical=�6!   .+�5       �� -   5         ��Name$ botonFotoPerfil��5    !   $��70��6:   $��70��6E   
������ $��0q�6j   .��5!      �� -   5         ��Name$ foto_perfil��5!   $    J� OpacityMask
 �����$	��Top=�6M   $��Uniform=�6e   6y   5"      �� 5#      -   5         ��Name$ labelNombre��5#   $   $��Italic$�69   $
��Bold"�6L   $��14(�6^   $
��Wrap=�6l   $��Center=�6�   5$      �� 5%      $ Vertical=�6!   $��20,0,0,0q�68   $��Center=�6J   .+�5&      �� $ 
Horizontal=�6%   .+�5'      �� $��LIBROS LEÍDOS:��6$   $��Italic$�6=   $
��Bold"�6P   $��14(�6b   �� 5(      -   5         ��Name$ labelLibrosLeidos��5(   $   $��Italic$�6?   $
��Bold"�6R   $��14(�6d   5)      �� 5*      $ 
Horizontal=�6%   .+�5+      �� $��AMIGOS:��6$   $��Italic$�66   $
��Bold"�6I   $��14(�6[   �� 5,      -   5        $ labelAmigos��5,   $   $��Italic$�69   $
��Bold"�6L   $��14(�6^   5-      5.      5/      �� 50      $ Vertical=�6   $��2��64   $��0,0,10,0q�6A   .+�51      �� $��COLECCIONES:��6   $��Italic$�63   $
��Bold"�6F   $��16(�6X   $��10,5,0,0q�6f   6z   �� 52      $ 
Horizontal=�6!   $��0,0,10,0q�6:   $	��127��6L   .+�53      �� -   5         ��Name$ 
scrollHijo��53   '   $
��Auto=�6;   $
��Auto=�6`   $��
10,10,0,10q�6�   $	��403��6�   .��54      �� -	   5         ��Name$ panelColecciones��54   )   $ 
Horizontal=�6C   6^   55      56      57      �� 58      $ Vertical=�6   $��2��64   $��0,155,10,88q�6A   $��3��6V   .+�59      �� $��AMIGOS:��6   $��Italic$�6.   $
��Bold"�6A   $��16(�6S   $��10,5,0,0q�6a   6u   �� 5:      $ 
Horizontal=�6!   $��0,0,10,0q�6:   $	��101��6L   $	��413��6Y   .+�5;      �� $
��Auto=�6'   $��Hidden=�6L   $��
10,10,0,10q�6q   $	��403��6�   $��84��6�   .��5<      �� -
   5        $ panelAmigos��5<   )   $ 
Horizontal=�6>   6Y   5=      5>      5?      �� 5@      -   5        $ panelRetosPadre��5@      $ Vertical=�66   $��4��6M   $��	0,5,10,58q�6Z   $y�	Collapsed=�6m   $��2��6�   .+�5A      �� $��RETOS:��6   $��Italic$�6-   $
��Bold"�6@   $��16(�6R   $��10,5,0,0q�6`   6t   �� 5B      $��Disabled=�6#   $
��Auto=�6J   $��49��6o   $	��398��6{   .��5C      �� $ 
Horizontal=�6%   .+�5D      �� -   5        $ botonAddReto��5D   %   $��54��6;   $��55��6G   $��0q�6R   $��0,0,0,0q�6f   ��5E   "   �� 5F   &   $ /Images/mas.png��61   5H      �� 5I      -   5        $ 
panelRetos��5I   )   $ 
Horizontal=�6=   5J      5K      5L      5M      �� 5N      $ 
Horizontal=�6   $��5��66   $��Right=�6C   .+�5O      �� -   5        $ botonAddAmigo��5O      $��Agregar a amigos��64   $��Italic$�6O   $
��Bold"�6b   $��20(�6t   $��0,0,20,0q�6�   ���	#FF51370C
�������$��40��6�   $	��180��6�   $y�	Collapsed=�6�   6  �� 5P      -   5        $ botonVolver��5P      $��Volver��62   $��Italic$�6C   $
��Bold"�6V   $��20(�6h   $��0,0,20,0q�6v   ���	#FF51370C
�������$��40��6�   $	��153��6�   6�   5Q      5R      5S      5T      5U      