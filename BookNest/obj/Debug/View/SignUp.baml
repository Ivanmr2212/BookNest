   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.SignUp   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  SignUp��5   	   $	��650��6   $	��450��6%    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6    j� Stretch$
 None=�6>   6O   ._�5   
   �� $ 25��6   ���#ddd5c1���#b3964f$��5q�6O    J� Opacity$
 0.90Q�6c   ._�5      � 	 � RowDefinitions	 5      �� 5      
 � ColumnDefinitions
 5      �� 5      $
��0.3* �6'   �� 5      �� 5      $
��0.3* �6'   .+�5      ��  �� Orientation$ Vertical=�6   $��1��64   ���	#FFB3964F.+�5      �� $ 
Horizontal=�6!   $��0,20,0,0q�6:   $��Center=�6L   $	��242��6i   .+�5       �� $��/Images/logo.png��6    $��51��6:    J� OpacityMask
 �����6[   �� 5!      $
��Bold"�6    
�������$��Center=�6E   $��34(�6b   .��5"      �� $��BookNest��6(   $��	Underline{�68   5#      5$      �� 5%      $��Registro de usuario��6   $��16(�6:   
�������$��Center=�6[   $��0,10,0,0q�6x   6�   �� 5&      $ Vertical=�6!   $��0,60,0,0q�68   $��Center=�6J   .+�5'      �� $��Correo electrónico:��6    $��20(�6>   
�������$	��266��6_   6m   �� 5(      -   5         ��Name$ txtCorreoSign��5(   "   $��13(�69   $��Medium"�6G   $��
Montserrat)�6[   
������  �� 
CaretBrush
 �   �
���   �$��0,0,0,1q�6�   $��28��6�   $��Center=�6�   $��0,0,0,0q�6�   6  �� 5)      $��Usuario:��6    $��20(�63   
�������$	��266��6T   $��0,30,0,0q�6`   6t   �� 5*      -   5        $ txtUsuarioSign��5*   "   $��13(�6:   $��Medium"�6H   $��
Montserrat)�6\   
������ 
 �   �
���   �$��0,0,0,1q�6�   $��28��6�   $��Center=�6�   $��0,0,0,0q�6�   6  �� 5+      $��Contraseña:��6    $��20(�66   
�������$	��261��6W   $��0,30,0,0q�6c   6w   G� 5,      -   5         G�Name$ txtPassSign��5,   &   $��13(�6;   $��Medium"�6I   $��
Montserrat)�6]   
������  G� 
CaretBrush
 �   �
���   �$��0,0,0,1q�6�   $��28��6�   $��Center=�6�   6�   �� 5-      -   5        $ txtVerPassSign��5-   "   $��13(�6:   $��Medium"�6H   $��
Montserrat)�6\   
������ 
 �   �
���   �$��0,0,0,1q�6�   $��28��6�   $��Center=�6�   $y�	Collapsed=�6�   6  �� 5.      -   5         ��Name$ checkBoxMostrarSign��5.   #   $��Mostrar contraseña��6@   $��0,10,0,0q�6]   
�������6�   5/      �� 50      $ 
Horizontal=�6!   $��0,40,0,0q�6:   $��Center=�6L   .+�51      �� -   5         ��Name$ botonCancelar��51   !   $��Cancelar��68   ���	#FF51370C
�������$��30(�6u   $��0,0,5,0q�6�   $	��120��6�   6�   �� 52      -   5        $ botonRegistrarUsuario��52   !   $��Aceptar��6@   ���	#FF51370C
�������$��30(�6|   $��5,0,0,0q�6�   $	��120��6�   6�   53      54      55      56      57      58      