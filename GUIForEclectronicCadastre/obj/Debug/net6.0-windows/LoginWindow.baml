   M S B A M L   `   `   `  ����T  PGUIForEclectronicCadastre, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GUIForEclectronicCadastreGUIForEclectronicCadastre  5   	   +    %GUIForEclectronicCadastre.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:GUIForEclectronicCadastre     5   	   -   5          � Title$  Electronic Cadastre��5   	   $	��600��6%   $	��600��62    � WindowStyle$ 
ToolWindow=�6>    � WindowStartupLocation$ CenterScreen=�6t   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��213* �6   6.   �� 5      $
��374* �6   6.   �� 5      $
��213* �6   6.    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ UsernameTextBox��5       �� TextWrapping$
 Wrap=�6+   $��Username��6?   $��Center=�6O   $��1��6j   $��1��6w   $��20(�6�   $��1��6�    �� TextAlignment$ Center=�6�   6�   �� 5   
   -   5        $ PasswordTextBox��5      $
 Wrap=�6+   $��Password��6?   $��Center=�6O   $��2��6j   $��1��6w   $��20(�6�   $��2��6�   $ Center=�6�   6�   �� 5   
   -   5        $ DatabaseNameTextBox��5      $
 Wrap=�6/   $��Database Name��6C   $��Center=�6X   $��3��6s   $��1��6�   $��20(�6�   $��3��6�   $ Center=�6�   6�   G� 5   
   -   5         G�Name$ UserPasswordBox��5      $y�Hidden=�6/   $��Center=�6C   $��2��6^   $��1��6k   $��20(�6{   $��2��6�   $��Center=�6�   �� 5   
   -   5        	 ��Name$	 LoginButton��5      $��Login��6'   $��4��67   $��1��6D   $��Center=�6T   $��Center=�6o   $��4��6�   $��20(�6�   6�   5      5      