   M S B A M L   `   `   `  ����C  ?TaskWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:TaskWave.Pages.Manager.CreateTeamProjects.CreatePart25TaskWave.Pages.Manager.CreateTeamProjects.CreatePart2  5      F    @TaskWave.Pages.Manager.CreateTeamProjects.CreatePart2.CreateTask   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      UlocalCclr-namespace:TaskWave.Pages.Manager.CreateTeamProjects.CreatePart2     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6Y     N� Title$  
CreateTask��5	      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Unloaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LostPageCommand+5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.7* �6   �� 5       � RowDefinitions 5   
   �� 5      $	��520 �6   .+�5   
   �� $%��Создание проекта��6      SetAccountH1#��[  6,   $
��Left=�6R   $��10 10 10 10q�6m   �� 5   
   -   5         ��Name$ 
mainPanell��5      ���#5E687C$	��430��6>   $	��Top=�6K   $��0 60 0 0q�6c   .+�5      �� $'��!Добавление задачи��6   #��[  61   $
��Left=�6W   $
��10 5q�6r   $��18(�6�   �� 5      -   5         ��Name$ nameTask��5        inputTextInSet#��[ 6C   $��10 10 150 0q�6l   ��6(   �� *	nameTask2+.��6�    5        5      $ GotFocus��6%   . 5          60   �� *InputFocusCommand+	   CommandParameter	 5!   $   �� 
 �� ElementName$
 nameTask��5"        5#      $ 	LostFocus��6%   . 5$         60   �� *InputLostFocus+	 5%   $   �� $
 nameTask��5&      .��5'   *   5(      �� 5)      -   5        $ 	DateCompl��5)      #��[ 6C   $��10 10 150 0q�6k   ��6)   �� *
DateEnd2+.��6�    5*        5+      $ GotFocus��6%   . 5,         60   �� *InputFocusCommand+	 5-   $   �� $
 	DateCompl��5.        5/      $ 	LostFocus��6%   . 50         60   �� *InputLostFocus+	 51   $   �� $
 	DateCompl��52      .��53   *   54      �� 55      -   5        $ nameExecutor��55      #��[ 6K   $��10 10 150 0q�6t   ��6,   �� *loginExecutor+.��6�    56        57      $ GotFocus��6%   . 58         60   �� *InputFocusCommand+	 59   $   �� $
 nameExecutor��5:        5;      $ 	LostFocus��6%   . 5<         60   �� *InputLostFocus+	 5=   $   �� $
 nameExecutor��5>      .��5?   *   5@      �� 5A      -   5        $ comments��5A      " �� VerticalScrollBarVisibility$
 Auto=�6F    �� TextWrapping$
 Wrap=�6i    �� AcceptsReturn$
 True��6}   #��[ 6�   $��
10 10 80 0q�6�   $	��190��6�   ��6(   �� *Description2+.��6�    5B        5C      $ GotFocus��6%   . 5D         60   �� *InputFocusCommand+	 5E   $   �� $
 comments��5F        5G      $ 	LostFocus��6%   . 5H         60   �� *InputLostFocus+	 5I   $   �� $
 comments��5J        5K      $ DataContextChanged��6%   . 5L         60   �� *InputLostFocus+	 5M   $   �� $
 comments��5N      .��5O   *   5P      �� 5Q      $��Center=�6   $��0 10 0 0q�65   
�������$��Malgun Gothic Semilight)�6Z   �� 5R      $+��%Добавить фотографии��6     cur � Cursor# [ 67    5S        5T      $ 	MouseDown��6%   . 5U         60   �� *AddPh2+5V      5X       �� 5Y      ��6   �� *
countPh2+5Z      �� 5[        StartBtn#��[ 6   $��Добавить��67   ��6J   �� *	AddTask+5\      �� 5^   
   $
��Auto=�6   $��1��6:   $	��Top=�6J   $��
10 60 10 0q�6b   $	��430��6w   .��5_      �� ���#5E687C.+�5`      �� $��Список задач��6   #��[  60   $
��Left=�6V   $��5q�6q   $��18(�6|   �� 5a      -   5        $ 	TaskPanel��5a      5d      5e      5f      �� 5g   
   $��Bottom=�6   $��0 0 0 -5q�6/   $��2��6A   $��Center=�6U   �� 5h      #��[ 6   ��67   �� *	textBtn+��6S   �� *SavePr+5i      5j      5k      