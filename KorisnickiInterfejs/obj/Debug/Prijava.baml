   M S B A M L   `   `   `  ����N  JKorisnickiInterfejs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KorisnickiInterfejsKorisnickiInterfejs  5   	   !    KorisnickiInterfejs.Prijava   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KorisnickiInterfejs     5   	   -   5        ���#040049  � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ Prijava��5   	   $	��450��6   $	��450��6&   .��5      �� $��Center=�6   $��Center=�6.   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��/images/usernameIcon.jpg��6$   $��30��6F   �� 5      -   5        $��tbKorisnickoIme��5   &   $��1��6   $��0 0 0 5q�6=   $��18(�6N   $��0q�6\    �� TextAlignment$ Center=�6p   $��2q�6�   $	��200��6�   $��30��6�    �� CharacterCasing$ Lower=�6�   .��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      �� 6   6sys&clr-namespace:System;assembly=mscorlib     6    �� 
TargetType" ��6O    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY	 j� Stretch
 !� Visual��%�   &	        !� 5      $
 Left=�6A   $ Center=�6S   $
	 None=�6g   
 5   "   �� 5   &   $)��#          Unesite korisnicko ime...��6,   
�������6Z   5      5       �� Triggers 5      P� 5       P� Property � �� �� Empty P� Value# Z 66   . �5   "   ��  �� Property � �� �� Value# [  6?   5       P� 5!       � �� 66   Z� . �5"   "   ��  � ��# [  6?   5#      P� 5$       �@J�IsKeyboardFocused . . �5%   "   ��  � ��
 �����6?   5&      5(      .��5)   !   5*      5+      �� 5-   
   $��1��6   
�������$	��200��61   $��	50 0 0 20q�6=   � 5.   
    5/      �� 50      $��* �6#   �� 51      $��* �6#   .+�54      �� $��0��6   $��Stretch=�6$   $��Stretch=�6B   $��/images/passwordIcon.jpg��6^   $��30��6�   �� 55      -   5        $��	tbLozinka��55   &   $��1��6   $��0 0 0 5q�67   $��18(�6H   $��0q�6V   $ Center=�6j   $	��200��6�   $��2q�6�   $��30��6�   $ Lower=�6�   .��6�   ��56      1&clr-namespace:System;assembly=mscorlibSystem 57      �� 6   6sys&clr-namespace:System;assembly=mscorlib     6   " ��6O    58      ��%�   &	        !� 59      $
 Left=�6A   $ Center=�6S   $
	 None=�6g   
 5:   "   �� 5;   &   $)��#                 Unesite lozinku...��6,   
�������6Z   5=      5>       5?      P� 5@       � ��# Z 66   . �5A   "   ��  � ��# [  6?   5B      P� 5C       � �� 66   Z� . �5D   "   ��  � ��# [  6?   5E      P� 5F       �@J�IsKeyboardFocused . . �5G   "   ��  � ��
 �����6?   5H      5J      .��5K   !   5L      5M      �� 5O   
   $��1��6   
�������$	��200��61   $��	50 0 0 15q�6=   �� 5k   
   -   5        $��btnPrijaviSe��5k      $��
Prijavi se��6A   $��18(�6V   $
��Bold"�6d   $��40��6v   $	��200��6�   $��3q�6�   $��	50 0 0 20q�6�   �� 5m   
   -   5        $��btnZaboravljenaLozinka��5m   6   $��Zaboravljena lozinka?��6T   ���#040049
�������$��0q�6�   $��Oblique$�6�   $��14(�6�   $��50 0 0 0q�6�   �� 5o   
   -   5        $��btnPropusnica��5o   -   $��
Propusnica��6B   ���#040049
�������$��0q�6�   $��Oblique$�6�   $��14(�6�   $��50 0 0 0q�6�   5p      5q      