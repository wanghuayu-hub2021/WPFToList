   M S B A M L   `   `   `  ����F  BWPFToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFToDoList.ViewModelWPFToDoList.ViewModel  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       WPFToDoList.View.TaskView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFToDoList.ViewModel     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -   5          �Name$  taskView��5   	    � Title$ 猫嘟清单��5	   	   $	��600��6   $
��1000��6#      MyWindowStyle#���   5
   
    � 	Resources 5      /   )WPFToDoList.ViewModel.PageNumberConverter  PageNumberConverter �� 
TargetType �� Property �� Value  MyButtonStyle �� Triggers P� Property P� Value  myWrapPanelStyle  myTextBlockStyle  myColumnHeader��%�  &	       &	       &	 d    &	     &	 �    &	 r      5   
   6$   �� 5   
   " �6&   .�5      ��  �@�WindowStyle$
 None=�6,   �� 5       �@�AllowsTransparency$
 True��63   �� 5       � ��
 �����6+   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ 12(�6)   �� 5       � ��$ 5q�60   6<   �� 5       � ��
 �����6B   5      �� 5   
   " ��6&   .�5      ��  � �� �#2a89a46+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ 20 10q�6(   �� 5       � ��$ 16(�6)    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �OO/�63   5       P� 5!       � ��$
 True��6/   . �5"      ��  � �� �#2a89a463   5#      5%      �� 5&   
   " �6   .�5'      ��  � ��$ Stretch=�62   6D   �� 5(       � ��$ Stretch=�62   6D   �� 5)       �@�Orientation$ 
Horizontal=�6,   6A   5*      �� 5+   
   " ��6   .�5,      ��  � ��$ 12(�6)   66   �� 5-       � ��$ Normal$�6*   6;   �� 5.       � ��$ 4q�6'   63   5/      �� 50   
   " ��6   .�51      ��  � ��
 �   �6+   �� 52       � ��$
 Bold"�6+   �� 53       � ��$ 5q�6(   �� 54       � ��$ 12(�6)   66   �� 55       � ��$
 Bold"�6+   56      57      .��59      � 	 � RowDefinitions	 5:   
   �� 5;      $
��auto �6   6,   �� 5<      $
��auto �6   6,   �� 5=      $
��250* �6   6,   
 � ColumnDefinitions
 5?   
   �� 5@      $
��100* �6   6.   �� 5A      $
��300* �6   6.   .+�5C   
   � $��0��6   $��0��6!   #���  61   .+�5D      ��  �� Orientation$ 
Horizontal=�6   .+�5E      A� -   5         A�Name$ 	tarvarPic��5E      $��60��6-   $��60��69   $��Center=�6D   $
��Left=�6_   ��5F      �� 5G       �� ImageSource$ /Resources/avatar8.jpg��6%    j� Stretch$ Uniform=�6J   5I      �� 5J      .+�5K      �� -   5         ��Name$ 
lbUserName��5K   A   #���  6U   ��6    �� *CurrentUserName+6�   �� 5L      -   5        $ lbDayOfWeek��5L   ;   #���  6P   ��6    �� *	DayOfWeek+6}   �� 5M      -   5        $ tbCurrentTime��5M   =   #���  6T   ��6    �� *CurrentTime+6�   5N      �� 5O      $��60��6   $��60��6'   ��5P      �� 5Q      $ /Resources/weather5.jpg��6%   $ Uniform=�6K   5S      5T      5U      � 5V   
   $��1��6   $��0��6!   #���  61   .+�5W      &   System.Windows.Controls.Calendar  $��Stretch=�6   $��Stretch=�63   5X      � 5Y   
   -   5         �Name$
 wpl3��5Y   1   $��2��6   $��0��6!   #���  6?   .+�5Z      �� $ Vertical=�6   $	��Top=�60   $��Center=�6H   .+�5[      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=�5\   !   $	��280��5^   !   ��5]   !   �� *ActualWidth+ �� ElementName$
 wpl3��   Series 5_   !   �� *SeriesCollection+   AxisX 5a        LiveCharts.Wpf.Axis     Labels 6#   �� *XAxisLabels+5c      �� 5d      $��Center=�6?   $��Center=�6Z   $
��Bold"�5e      
���   ���5d      �� *ShowTotalMessage+5e   .   �� 5f      $��Center=�6?   $��Center=�6Z   $
��Bold"�5g      
����  ���5f      �� *ShowTotalMessage0+5g   /   �� 5h      $��Center=�6?   $��Center=�6Z   $
��Bold"�5i      
��� �����5h      �� *ShowTotalMessage1+5i   .   �� 5j      $��Center=�6?   $��Center=�6Z   $
��Bold"�5k      
��� d ���5j      �� *ShowTotalMessage2+5k   .   5m      5n      �� 5o   
   -   5         ��Name$	 sp1��5p      $��0��5o      $��1��6"   $ 
Horizontal=�62   $��Stretch=�5p   "   $��Stretch=�6>   .+�5q      �� -   5         ��Name$ btnAll��5q      $��50��6%   $	��100��61   $��10q�6=   #���  5r   7   ��6   �� *QueryCommand+.��6_   全部6c   �� 5s      -	   5        $ btnUndo��5s      $��50��6&   $	��100��62   $��10q�6>   #���  5t   ;   ��6   �� *QueryCommandUndo+.��6c   	未开始6h   �� 5u      -
   5        $ btnDoing��5u      $��50��6'   $	��100��63   $��10q�6?   #���  5v   <   ��6   �� *QueryCommandDoing+.��6d   	进行中6i   �� 5w      -   5        $ btnDone��5w      $��50��6&   $	��100��62   $��10q�6>   #���  5x   ;   ��6   �� *QueryCommandDone+.��6c   	已完成6h   �� 5y      -   5        $ 
btnKeepAtn��5y      $��50��6)   $	��100��65   $��10q�6A   #���  6M   .��6u   专注6y   5z      � 5|   
   -   5        $	 wp5��5|   B   $��1��6   $��2��6!   $��1��62    � Orientation$ Vertical=�6O   #���  6f   .+�5}      �� -   5         ��Name$ lvTask��5}      $��Stretch=�6'   $��Stretch=�6E   ��5~      �� $	 wp5�� �� Path$ ActualWidth���5      �� *Items+ �� SelectedItem 65   �� *
SelectTask+ �� View 5�      �� 5�      -   5        
gvTask��.P�5�      ��  �� Width$
 auto��6)   $��任务描述��66    �� HeaderContainerStyle# �  6D    �� DisplayMemberBinding 6|   �� *TaskDescription+�� 5�      $
 auto��6)   $��开始时间��66   # �  6D    6|   �� *	StartDate+�� 5�      $
 auto��6)   $��结束时间��66   # �  6D    6|   �� *	EndDate+�� 5�      $
 auto��6)   $��标签分类��66   # �  6D    6|   �� *Tags+�� 5�      $
 auto��6)   $��完成时间��66   # �  6D    6|   �� *CompletionDate+�� 5�      $ 60��6)   $��任务状态��64   # �  6B    6z   �� *
TaskStatus+5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��1��6@   $��	第一页��6U   $��80��6c   $��5q�6n   ��6   �� *PageChangedCommand+6n   �� 5�      $��80��6@   $��	上一页��6K   $��5q�6Y   ��6   �� *PageChangedCommand+��5�      `� 5�        `� 	Converter#  [ 6'   .1�5�      �� $ CurrentPageNumber�6&   �� 5�      ! �� Source$! -1��6&   5�      5�      �� 5�      $	��第��6   $��Center=�6%   $��5q�6@   �� 5�      $��5q�6L   $��Center=�6W   ��6   �� *CurrentPageNumber+" �� Mode$" TwoWay=�6W   �� 5�      $	��页��6   $��Center=�6%   $��5q�6@   �� 5�      $��80��5�      $��	下一页��6$   $��5q�62   ��5�      �� *PageChangedCommand+��5�      `� 5�      #  [ 6'   .1�5�      �� $ CurrentPageNumber�6&   �� 5�      $! +1��6&   5�      5�      �� 5�      $��80��5�      $��	最后页��6$   $��5q�62   ��5�      �� *PageChangedCommand+��6@   �� *
TotalPages+5�   2   �� 5�      $��页面条数��6   $��Center=�6(   $��5q�6C   �� 5�      -   5        # ��Name$# 
tbPageSize��5�   5   $��Center=�6   $��80��6I   .��6}   ��5�      �� 5�      $ PageSize�6"   $ �� UpdateSourceTrigger$$ PropertyChanged=�62   % �� ValidationRules% 5�      /   )WPFToDoList.ViewModel.RangeValidationRule  5�   "   
&   Min$& 1��6<   
'   Max$' 20��6D   5�      .��5�   $   5�      5�      � 5�      $��5q�6   .+�5�      �� $ 
Horizontal=�6Z   ( � DataContext( 6   �� $ lvTask��$ SelectedItem�.+�5�      �� $��任务描述��6   $��5q�6+   68   �� 5�      -   5        $��tbSelectTaskDsp��5�   V   $��80��6?   $��5q�6K   ��6   �� *TaskDescription+6o   �� 5�      $��标签��6   $��5q�6)   66   �� 5�      $��80��64   $��5q�6@   ��6   �� *Tags+6M   �� 5�      $��状态��6   $��5q�6)   66   �� 5�      $��80��6   ��6*   �� $ tbSelectTaskDsp��$ ActualHeight�) �� SelectedIndex) 6k   �� *
TaskStatus+.@�5�      �� $��	未开始��6'   67   �� 5�      $��	进行中��6'   67   �� 5�      $��	已完成��6'   67   5�      5�      �� 5�      $��保存��6   $��80��6&   $��5q�62   ��6=   �� *SaveCommand+6_   �� 5�      $��删除��6   $��80��6&   $��5q�62   ��6=   �� *DeleteCommand+6a   5�      � 5�      $��5q�6   .+�5�      �� $��新增��6   $��80��6&   $��5q�61   ��6<   �� *
AddCommand+6]   �� 5�      $��查询��6   $��80��6&   $��5q�61   ��6<   �� *QueryCommand+6_   (  "System.Windows.Controls.DatePicker  5�      *   Text$* 日期��6   $��80��6'   $��5q�62   6?   5�      5�      5�      5�      