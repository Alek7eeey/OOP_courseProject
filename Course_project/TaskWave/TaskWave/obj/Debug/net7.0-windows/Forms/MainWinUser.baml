   M S B A M L   `   `   `  ����C  ?TaskWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskWave.FormsTaskWave.Forms  5   	        TaskWave.Forms.MainWinUser   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskWave.Forms     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  
winManager��5	   	    � Title$ MainWinUser��5
   	   $	��670��6   $
��1000��6-    � Icon$ /Forms/logo.png��6=   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *CommandOpenTasks+   CommandParameter 5   0   ��  �� ElementName$ MyTasks��5      .��5      � ���#3F4B60	 � ColumnDefinitions	 5   
   �� 5      $	��180��6   $	��190 �6.   $	��280��6:   �� 5      
 � RowDefinitions
 5   
   �� 5      $��75 �6   �� 5      .+�5   
    � -   5          �Name$ FraimMainInAcc��5         
FraimStyle#��[  6(     � NavigationUIVisibility$ Hidden=�6L   �� 5   
     SPInMain#��[ 6   $��2��67   �� 5   
   #��[ 6   $��2��67   �� 5    
   $��TaskWave��6     NameTaskWave#��[ 6$     OxaniumRegular#��[ 6J   �� 5"   
   $��Center=�6   $
��Left=�6/   $��5 0 0 0q�6J   A� 5#      $��30��6   $��30��6!   $��0 0 0 -5q�6-   $��Center=�6?   $
��Left=�6Z   ��5$      �� 5%      -   5        imgBrush�� j� Stretch$ UniformToFill=�5%   Q    �� ImageSource 63   �� *Image+6Q   5'       �� 5)      -   5         ��Name$ NameBl��5)        nameAcc#��[ 6(   ��6I   �� *Name+ �� Mode$ TwoWay=� �� 5*      $��/Forms/img/settings.png��6     IconSet#��[ 65    5+        5,      $ 	MouseDown��6%   . 5-         60   �� *CommandOpenAccountSet+ 5.   0   �� $ avatar��5/      51      52      �� 54   
   $��	4 15 0 0 q�6   $��2��6)   $��0��66   .+�55      �� $��0 10 0 0q�6   $
��Wrap=�6*     cur � Cursor# [ 6>   �� 56        IconNearMenu#��[ 6   $��/Forms/img/task.png��6>   $
��Fill=�6[    �� 57      -   5        $ MyTasks��57      $��Мои задачи��6-     MenuText#��[ 6?    58        59      $ 	MouseDown��6%   . 5:         60   �� *CommandOpenTasks+ 5;   0   �� $ MyTasks��5<      5>      �� 5@      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=   �� 5A      $��/Forms/img/Projects.png��6   #��[ 6:    �� 5B      -   5        $ pr��5B      $��Мои проекты��6*   #��[ 6=    5C        5D      $ 	MouseDown��6%   . 5E         60   �� *OpenProject+ 5F   0   �� $ pr��5G      5I      �� 5J      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=   �� 5K      $"��/Forms/img/groupProjects.png��6   #��[ 6>    �� 5L      -   5        $ teamPr��5L      $'��!Командные проекты��6,   #��[ 6E    5M        5N      $ 	MouseDown��6%   . 5O         60   �� *OpenTeamProject+ 5P   0   �� $ teamPr��5Q      5S      5T      �� 5V   
   $��
4 130 0 0 q�6   $��2��6*   $��0��67   .+�5W      �� $
��Wrap=�6   # [ 6,    5X        5Y      $ 	MouseDown��6%   . 5Z         60   �� *OpenCreatePr+ 5[   0   �� $ createNewPr��5\      �� 5^      #��[ 6   $��/Forms/img/add.png��6>    �� 5_      -   5        $ createNewPr��5_      $,��&Создать новый проект��62   #��[ 6N   5`      5a      �� 5c   
   $��
4 186 0 0 q�6   $��2��6*   $��0��67   .+�5d      �� $
��Wrap=�6   # [ 6,    5e        5f      $ 	MouseDown��6%   . 5g         60   �� *
OpenTask+ 5h   0   �� $ 	readytask��5i      �� 5k      #��[ 6   $��/Forms/img/completed.png��6>    �� 5l      -	   5        $ 	readytask��5l      $)��#Выполненные задачи��60   #��[ 6J   5m      �� 5n      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=    5o        5p      $ 	MouseDown��6%   . 5q         60   �� *OpenSendTask+ 5r   0   �� $ sendTask��5s      �� 5u      #��[ 6   $��/Forms/img/send.png��6>    �� 5v      -
   5        $ sendTask��5v      $+��%Отправленные задачи��6/   #��[ 6J   5w      5x      �� 5z   
   $��
4 260 0 0 q�6   $��2��6*   $��0��67   .+�5{      �� $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=    5|        5}      $ 	MouseDown��6%   . 5~         60   �� *
openStat+ 5   0   �� $
 stat��5�      �� 5�      $��/Forms/img/statistic.png��6   #��[ 6:    �� 5�      -   5        $
 stat��5�      $��Статистика��6+   #��[ 6=   5�      �� 5�      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=    5�        5�      $ 	MouseDown��6%   . 5�         60   �� *OpenNotifications+ 5�   0   �� $ notif��5�      �� 5�      #��[ 6   $%��/Forms/img/notification-384.png��6>    �� 5�      -   5        $ notif��5�      $��Уведомления ��6+   #��[ 6?   5�      5�      �� 5�   
   $��Bottom=�6   $��4 0 0 20q�60   $��2��6B   $��0��6O   .+�5�      �� -   5        $
 exit��5�      # [ 6&    5�        5�      $ 	MouseDown��6%   . 5�         60   �� *ExitCommand+ 5�   0   �� $ 
winManager��5�      �� 5�      #��[ 6   $��/Forms/img/exit.png��6:    �� 5�      $'��!Выйти из аккаунта ��6   #��[ 62   5�      5�      �� 5�   
    	 splitterGrid#��[	 6   �� 5�   
    
 
FooterWrap#��[
 6   �� 5�      $5��//Forms/img/copyright-all-rights-reserved-96.png��6   $��15��6M    �� 5�        FooterTB#��[ 6   5�      5�      5�      