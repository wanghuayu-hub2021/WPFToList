   M S B A M L   `   `   `  ����F  BWPFToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFToDoList.ViewWPFToDoList.View  5   	       WPFToDoList.View.WinTest   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPFToDoList.View     5   	     � Title$  WinTest��5   	   $	��450��6   $	��800��6&    � 	Resources 5	       �� 
TargetType   listBoxStyle �� Property �� Value �� Triggers P� Property P� Value :� RoutedEvent	 g� Duration
 �� TargetProperty	 W� To��%�  &	        �� 5
   
   " ��6   .�5      ��  �@J�Opacity$	 0.5Q�6(   �� 5       � ��$ 75��6*   �� 5       � ��
 ��  �6:    5      P� 5       �@��
IsSelected$
 True��60    �5      �� 5       �@J�Opacity$	 1.0Q�64   �� 5       � ��
 ��ح�67   �� 5       � ��
 �����67   5      :� 5      $ MouseLeftButtonDown��6   [�5      �� 5      .��5      �� .��5   "   W� $	 0:0:0.2D�5      $
 	MaxHeight�5       905      5      5      5!      :� 5"      $ Mouse.MouseLeave��6   [�5#      �� 5$      .��5%      �� .��5&   "   W� $	 0:0:1D�5'      $
 	MaxHeight�5(      5)      5*      5,      5.      50      .��51      � .+�52   
   �� .+�53      �� -   5         ��Name$ listBox��53      .@�54      �� $��午餐��6   #���   6'   6P   �� 55      $��跑步��6   6)   �� 56      $��吃饭��6   6)   �� 57      $��约会��6   6)   58      �� 59   
   $��Click Me��6   ��5:      �� 5;      " ��6    5<      :� 5=      $ Button.Click��6'   [�5>      �� 5?   "   .��5@   &   �� .��5A   *   W� $
 FontSize�6:    245B   2   $	 0:0:1D�5C   2   5D   '   5E   #   5G      5I      5K      5L      5M      5N      