   M S B A M L   `   `   `  ����C  ?TaskWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:TaskWave.Pages.SnadartUser.pageWithInfAboutTask/TaskWave.Pages.SnadartUser.pageWithInfAboutTask  5      =    7TaskWave.Pages.SnadartUser.pageWithInfAboutTask.InfTask   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:TaskWave.Pages.SnadartUser.pageWithInfAboutTask     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6S     N� Title$  InfTask��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value   cur��%  '��       7   �� 5   
   " ��6   .�5      ��  � ��$ 70��6&   �� 5       � ��$ 8��6'   �� 5       � ��
 �����6+   �� 5       � ��
 �����6+   �� 5       � ��$ 	0 5 0 -10q�6'   �� 5       �@�Cursor8   6'   5      5      .��5      ��   
BorderTask#��[ 6   ._�5   
   �� $
��Auto=�6   .��5   
   �  � RowDefinitions 5      �� 5      �� 5      $
��0.7* �6    .+�5      �� -   5         ��Name$ mainPanelInProject��5      $��
10 10 10 0q�69   $��0��6M   .+�5      ��  	 TB_H1#��[ 6:   ��6    �� *
NameTask+6:   �� 5      $��Center=�6    �� 5       	 TB_H2#��[ 6<   ��6$   �� *DayEnd+6<   5       �� 5"      .+�5#      �� $
��Left=�6%   .+�5$      �� �� 5%   "     TB_H3TypePr#��[ 6J   ��6,   �� *GroupPrOrNot+6J    �� 5&   "     TB_H3TypePrValue#��[ 6D   ��6,   �� *namePr+6D   5'      5(      �� 5*        
rightPanel#��[ 6%   .+�5+      �� �� 5,      $)��#Задача поставлена: ��6(   #��[ 6C    �� 5-      #��[ 6@   ��6(   �� *dateOt+6@   5.      �� 5/      �� 50      $4��.Необходимо выполнить до: ��6(   #��[ 6I    �� 51      #��[ 6@   ��6(   �� *dateTo+6@   52      53      54      �� 56      .  (System.Windows.Interactivity.Interaction   Triggers 57      /  )System.Windows.Interactivity.EventTrigger  58         	EventName$ 	MouseDown��6-   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 59   "   6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 68   �� *
seeAddPh+5:      �� 5=        
iconAttach#��[ 6    �� 5>      $:��4Просмотр прикреплённых фото��6      TB_SeePhoto#��[ 6C   $��	-2 -3 0 0q�6h    � Cursor# [  6{   5?      5A      �� 5C       	 ScrollViewer#��[	 6   .��5D      ��  
 
TBWithOpis#��[
 6    ��6D   �� *description+5E      �� 5G      -   5         ��Name$ 
tbWithFile��5G        	 TBBut#��[ 64   �� 5H        
iconAddDoc#��[ 6    $��15��6D   $��15��6O   $��1��6[    �� 5I      $#��Прикрепить файл��6$   #��[ 6;   # [  6`    5J        5K      $ 	MouseDown��6-   .	 5L   "     
 68   �� *AddDoc+5M      5O       �� 5P      -   5         ��Name$ sv��5P   '   $
��Auto=�63   $
��Auto=�6V   $��0 -15 136 0q�6{   # [  6�   .��5Q      �� -   5        $ sc��5Q   B    �� Orientation$ 
Horizontal=�6)   6B   5R      5T      �� 5W        ScrollViewer2#��[ 6   .��5X      �� -   5         ��Name$ comments��5X        
addComment#��[ 6N   ��60   �� *DescResponse+.��6r    5Y        5Z      $ GotFocus��6-   .	 5[   "     
 68   �� *
InputFocus+   CommandParameter 5\   $   ��  �� ElementName$ comments��5]        5^      $ 	LostFocus��6-   .	 5_   "     
 68   �� *InputLostFocus+ 5`   $   �� $ comments��5a      .��5b   2   5c      5d      �� 5e      $��1��6     StartBtn#��[ 6&   $��Bottom=�6�   $��0 0 0 8q�6�   ��6H   �� *groupOrNotBtn+��6j   �� *CompleteOrSendCommand+6�   5f      5g      5h      5i      