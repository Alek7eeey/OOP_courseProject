   M S B A M L   `   `   `  ����C  ?TaskWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Fclr-namespace:TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart28TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart2  5      O    ITaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart2.CreateTaskInProj   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      XlocalFclr-namespace:TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart2     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6\     N� Title$  CreateTaskInProj��5	      .  (System.Windows.Interactivity.Interaction   Triggers 5
      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Unloaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LostPageCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.7* �6   �� 5       � RowDefinitions 5   
   �� 5      $	��520 �6   �� 5      .+�5   
   �� $%��Создание проекта��6      SetAccountH1#��[  6,   $
��Left=�6R   $��10 10 10 10q�6m   �� 5      -   5         ��Name$ 
mainPanell��5      ���#5E687C$	��400��6B   $	��Top=�6O   $��0 60 0 0q�6g   .+�5      �� $'��!Добавление задачи��6   #��[  65   $
��Left=�6[   $
��10 5q�6v   $��18(�6�   �� 5      -   5         ��Name$ nameTask��5        inputTextInSet#��[ 6C   $��10 10 150 0q�6l   ��6(   �� *	nameTask2+.��6�    5        5      $ GotFocus��6%   . 5         60   �� *InputFocusCommand+	   CommandParameter	 5    $   �� 
 �� ElementName$
 nameTask��5!        5"      $ 	LostFocus��6%   . 5#         60   �� *InputLostFocus+	 5$   $   �� $
 nameTask��5%      .��5&   *   5'      �� 5(      -   5        $ 	DateCompl��5(      #��[ 6C   $��10 10 150 0q�6k   ��6)   �� *
DateEnd2+.��6�    5)        5*      $ GotFocus��6%   . 5+         60   �� *InputFocusCommand+	 5,   $   �� $
 	DateCompl��5-        5.      $ 	LostFocus��6%   . 5/         60   �� *InputLostFocus+	 50   $   �� $
 	DateCompl��51      .��52   *   53      �� 54      -   5        $ comments��54      " �� VerticalScrollBarVisibility$
 Auto=�6F    �� AcceptsReturn$
 True��6j    �� TextWrapping$
 Wrap=�6�   #��[ 6�   $��
10 10 80 0q�6�   $	��190��6�   ��6(   �� *Description2+.��6�    55        56      $ GotFocus��6%   . 57         60   �� *InputFocusCommand+	 58   $   �� $
 comments��59        5:      $ 	LostFocus��6%   . 5;         60   �� *InputLostFocus+	 5<   $   �� $
 comments��5=        5>      $ DataContextChanged��6%   . 5?         60   �� *InputLostFocus+	 5@   $   �� $
 comments��5A      .��5B   *   5C      �� 5D      $��Center=�6   $��0 10 0 0q�69   
�������$��Malgun Gothic Semilight)�6^   �� 5E      $+��%Добавить фотографии��6     cur � Cursor# [ 67    5F        5G      $ 	MouseDown��6%   . 5H         60   �� *AddPh2+5I      5K       �� 5L      ��6   �� *
countPh2+5M      �� 5N        StartBtn#��[ 6   $��Добавить��67   ��6J   �� *	AddTask+5O      �� 5Q      $
��Auto=�6   $��1��6>   $	��Top=�6N   $��
10 60 10 0q�6f   $	��400��6{   .��5R      �� ���#5E687C.+�5S      �� $��Список задач��6    #��[  64   $
��Left=�6Z   $��5q�6u   $��18(�6�   �� 5T      -   5        $ 	TaskPanel��5T   !   5W      5X      5Y      �� 5Z   
   $��Bottom=�6   $��0 0 0 20q�6/   $��2��6A   $��Center=�6U   �� 5[      #��[ 6   ��67   �� *	textBtn+��6S   �� *SavePr+5\      5]      5^      