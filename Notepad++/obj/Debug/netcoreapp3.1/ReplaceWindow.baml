   M S B A M L   `   `   `  ����D  @Notepad++, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Notepad__	Notepad__  5   	       Notepad__.ReplaceWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Notepad__     5   	     � Title$  ReplaceWindow��5      $	��180��6#   $	��316��60   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $��80 �6   �� 5      $	��100 �6   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��	Replace: ��6   $��14(�6$   $	��Top=�62   $��1��5      $��1��6   �� 5   
   -   5        $��replaceTextBox��5   7   $��80��6   $��16(�6   $��20��6+   $	��top=�6M   $��1��5      $��2��6   �� 5   
   $��With: ��6   $��14(�6!   $��Bottom=�6/   $��1��5      $��1��6   �� 5   
   -   5        $��withTextBox��5   7   $��80��6   $��16(�6   $��20��6+   $��Bottom=�6J   $��1��5      $��2��6   �� 5   
   -   5         ��Name$ allFiles��5   '   $��	All files��6   $��Center=�69   $��Center=�6W    J� RenderTransformOrigin$ 0.455,1.009&�5       $��2��67   $��1��6D   �� 5!   
   -   5        $��Replace��5!      
 � Tag$ replace��6#   $��20��62   $	��Top=�6\   $��1��5"      $��3��6   �� 5#   
   -   5        $��
ReplaceAll��5#      $ 
replaceAll��6&   $��20��68   $��Bottom=�6e   $��1��5$      $��3��6   5%      5&      