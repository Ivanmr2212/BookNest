   M S B A M L   `   `   `  ����B  >MyReads, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyReads.ViewMyReads.View  5   	       MyReads.View.seeReviews   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MyReads.View     5   	   -   5          � Title$  
seeReviews��5   	   $	��650��6   $	��450��6)    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ Manual=�5   	    � Left$ 50��5   	   
 � Top$	 110��6   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6   	 j� Stretch$
	 None=�6>   6O   ._�5   
   �� $ 25��6   ���#ddd5c1���#b3964f$��15q�6O   
 J� Opacity$

 0.90Q�6d   ._�5      � -   5         �Name$ gridPrincipal��5      ���	#FFEDE5D1$��0,0,-5,0q�6A    � RowDefinitions 5      �� 5      $��0.12* �6$   �� 5      �� 5      $��0.12* �6$   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��66   ���#b3964f.+�5      �� -   5         ��Name$ labelTitulo��5      $��REVIEWS��61   $
��Bold"�6C   
�������$��30(�6h   ���	#FFB39F4F$��0��6�   $��Center=�6�   $��Center=�6�   $��30,0,0,0q�6�   5      �� 5      $ Vertical=�6   $��1��64   .+�5      �� $
��Auto=�6#   $��Hidden=�6F   $	��456��6m   $��20,20,20,20q�6z   .��5       �� -   5         ��Name$ panelReviews��5    %   5!      5"      �� 5#      $ 
Horizontal=�6   $��2��66   $��Center=�6C   .+�5$      �� -   5         ��Name$ botonVolver��5$      $��Volver��62   $��Italic$�6C   $
��Bold"�6V   $��20(�6h   ���	#FF51370C
�������$	��150��6�   $��40��6�   6�   5%      5&      5'      5(      5)      