   M S B A M L   `   `   `  ����D  @Notepad++, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Notepad__	Notepad__  5   	       Notepad__.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Notepad__     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      � ���#E5F9E0 � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   o� 
�������$��0��5      $��2��5      ��5      �� 5      .R�5      ]� $��Stretch=�6    5      .@�5      m� $
��File��6   ���#A3F7B5$��0,1,0,0q�5   ,   $��66��6=   .@�5       m� -   5        $	��New��5        m� Command 5!      ��  �� Path$	 New�m� 5"      -   5        $��Open...��5"       5#      �� $
 Open�m� 5$      -   5        $
��Save��5$       5%      �� $
 Save�m� 5&      -   5        $��Save As��5&       5'      �� $ SaveAs�m� 5(      -   5        $
��Exit��5(       5)      �� $
 Exit�5*      m� 5+      $��Search��6   ���#A3F7B5$��60��5,   ,   .@�5-      m� -   5        $��Find...��5-       5.      �� $
 Find�m� 5/      -   5        $��
Replace...��5/       50      �� $ Replace�m� 51      -	   5        $��Replace All...��51       52      �� $ 
ReplaceAll�53      m� 54      $
��Help��6   ���#A3F7B5.@�56      m� -
   5        $��About��56       57      �� $ About�58      m� 59      $
��Edit��6   ���#A3F7B5.@�5;      m� -   5        $��To Uppercase��5;      61   m� 5<      -   5        $��To Lowercase��5<      61   m� 5=      -   5        $��Remove Empty Lines��5=      67   5>      5?      R� 5@   
   -   5         R�Name$ 
FolderView��5@      $��1��5A      $��2��5B      
������� � 	Resources 5E       �� 
TargetType �� Property	 �� Value
 �� Orientation �� RelativeSource �� Mode �� AncestorType   Notepad__.ImageConverter   Instance �� 	Converter��%?  'Q�       �� 5G      " Q�6   .�5H      ��  � ��	 5I      �� 5J      .R�5K   "   �� $
 
Horizontal=�6-   .+�5L   &   �� $��20��6,   $��3q�67   ��5M   )   ��  �� $ FindAncestor=�" Q�$	 Tag�# Z �� 5Q   &   $��Center=�60   ��6K   �� 5R   #   5S      5U      5W      5Y      5Z      �� 5\   
   -   5        $��
tabControl��5^      $��3��5\      $��2��5]      ��5_      �� ��5`      �� 5a       �� DataType   Notepad__.Tab"  6   .R�5b      �� $
 
Horizontal=�6!   .+�5c      �� ��6$   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=�5e      �� 5f      -   5        $��12��5f   !   $��12��6-   $��Center=�68   $��Center=�6U   $��
5, 3, 0, 0q�5g   !   
 � Tag 6N   �� *
FilePath+.��5h      �� $��img/close 30.png��6$   5i      5j      5k       �� ContentTemplate 5m      �� 5n      "  6   .R�5o      �� $��textBoxName��5q      $��0q�5p      $ �� HorizontalScrollBarVisibility$
 Auto=�5r      " �� VerticalScrollBarVisibility$
 Auto=�5s       �� AcceptsReturn$
 True��5t       �� 
AcceptsTab$
 True��5u      * �� #IsInactiveSelectionHighlightEnabled$
 True��5v       �� SelectionBrush
 �   ���5o      �� *	Content+$ PropertyChanged=�$ TwoWay=�.��5w   5   ��5x      �� 5y      " ��6$   .�5z   "   ��  �@��
IsReadOnly$	 False��6?    �� Triggers 5{   "   �� 5|   &    �� Binding 62   �� *
IsReadOnly+$ PropertyChanged=� �� Value True6v   .a�5}   *   ��  �@��
IsReadOnly$
	 True��6G   5~   '   5�      .��5�   )   5�      5�      5�      5�      5�      