   M S B A M L   `   `   `  ����N  JKorisnickiInterfejs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:KorisnickiInterfejsKorisnickiInterfejs  5   	       KorisnickiInterfejs.Odmor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:KorisnickiInterfejs     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Odmor��5
   	   $	��300��6   $	��600��6$   .��5      ��  �� Padding$ 15q�6   ._�5   
   �� $��Center=�6   .+�5      � $
��0 10q�6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��2* �6'   �� 5      $��* �6'   �� 5      $��2* �6'   .+�5      �� $��0��6   $��10q�6,   $��
Datum od: ��68   $��14(�6J   $��Center=�6X   (  "System.Windows.Controls.DatePicker  5      -   5        $��	dpDatumOd��5   -   $��1��6   $��12(�6>   $��2q�6L   $	��170��6X   $��25��6d   $
��Left=�6p      BlackoutDates 5      /  )System.Windows.Controls.CalendarDateRange  5         Start$ 
12.31.2019��6,   
   End$ 
01.10.2020��6?   5      �� 5      $��2��6   $��10q�6,   $��
Datum do: ��68   $��14(�6J   $��Center=�6X     5      -   5        $��	dpDatumDo��5   -   $��3��6   $��12(�6>   $��2q�6L   $	��170��6X   $��25��6d   $
��Left=�6p    5        5      $ 
12.31.2019��6,   $ 
01.10.2020��6?   5!      5"      �� 5/      -   5        $��btnSacuvajOdmor��5/   4   $��Sacuvaj odmor��6K   $��13(�6c   $
��Bold"�6q   $��30��6�   $	��150��6�   $��Center=�6�   $��
0 100 50 0q�6�   50      51      52      