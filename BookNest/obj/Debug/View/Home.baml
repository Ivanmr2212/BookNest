   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.Home   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$
  Home��5   	   $	��550��6   $	��800��6#    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency . .��5      �� ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6    j� Stretch$
 None=�6>   6O   ._�5   
   ��  �� CornerRadius$ 0��6   ���#ddd5c1���#b3964f$��5q�6N    J� Opacity$
 0.95Q�6b   ._�5      � 	 � RowDefinitions	 5      �� 5      $��30 �6$   �� 5      $	��510 �6$   .+�5      � 
 � ColumnDefinitions
 5      �� 5      �� 5      $��0.08* �6+   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��1��6:   .+�5      �� -   5         ��Name$ BotonMinimizar��5   !   ���#b3964f$��0q�6N   $��-��6b   
���   �$��20(�6�   $��
Montserrat)�6�    � Cursor$
 Hand��6�   $��0��6�   $��0,0,0,0q�6�   $��30��6�   6�   �� 5       -   5        $ BotonCerrar��5    !   ���#b3964f$��0q�6L   $��X��6`   
���   �$��20(�6   $��
Montserrat)�6�   $
 Hand��6�   $��1��6�   $��30��6�   $��Center=�6�   $��3��6�   $��0,0,0,0q�6�   $��30��6)  67  5!      5"      � 5#      $��1��6   
 5$      �� 5%      $
��0.3* �6+   �� 5&      .+�5(      �� $ Vertical=�6!   $��0��68   ���	#FFB3964F$��	0,-31,0,0q�6_   .+�5)      �� $
��Bold"�6    
�������$��Center=�6E   $��34(�6b   .��5*      �� $��BookNest��6(   $��	Underline{�68   5+      �� 5,      $ Vertical=�6%   $��	0,10,0,20q�6<   .+�5-      �� -   5        $ botonBusqueda��5-   %   $��BUSCAR��6<   $
��Bold"�6M   $��30(�6_   
������ 
�������$��0q�6�   $��0,20,0,0q�6�   6�   �� 5.      -   5        $ botonLibreria��5.   %   $��
BIBLIOTECA��6<   $
��Bold"�6Q   $��30(�6c   
������ 
�������$��0q�6�   $��0,20,0,0q�6�   6�   �� 5/      -   5        $ 
botonClubs��5/   %   $��CLUBS��69   $
��Bold"�6I   $��30(�6[   
������ 
�������$��0q�6�   $��0,20,0,0q�6�   6�   �� 50      -   5        $ botonUsuarios��50   %   $��USUARIOS��6<   $
��Bold"�6O   $��30(�6a   
������ 
�������$��0q�6�   $��0,20,0,0q�6�   6�   �� 51      -   5        $ botonPerfil��51   %   $��PERFIL��6:   $
��Bold"�6K   $��30(�6]   
������ 
�������$��0q�6�   $��0,20,0,0q�6�   6�   �� 52      -	   5        $ 
botonSalir��52   %   $��SALIR��69   $
��Bold"�6I   $��30(�6[   
������ 
�������$��0q�6�   $��0,20,0,0q�6�   6�   53      54      �� 55      $
��Left=�6    $��2��6;   $	��572��6O   $��182,-46,0,0q�6\   
���   �$	��Top=�6�   $��2��6�    �� RadiusY$ 5��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��2��6�   z�56      V� 57      .~�58   "   ��  �� ScaleX$ -1Q�61   �� 59   "   �� 5:   "   T� 5;   "   5<      5>      �� 5?      $��2��6!   $ Vertical=�61   .+�5@      �� $ 
Horizontal=�6%   $��0,20,0,0q�6>   .+�5A      �� -
   5         ��Name$ labelBienvenida��5A   $   $��24(�6=   $
��Bold"�6K   $��20,0,0,0q�6]   5B      �� 5C      $&�� Descubre lo que hacen tus amigos��6    $��24(�6K   $
��Bold"�6Y   $��0,0,0,0q�6k   $	��568��6|   �� 5D      $
��Auto=�6'   $
��Auto=�6L   $	��337��6o   $	��540��6|   $��	20,20,0,0q�6�   .��5E      �� -   5         ��Name$ panelNovedades��5E   )   5F      5G      5H      5I      5J      5K      5L      5M      