   M S B A M L   `   `   `  ����C  ?TaskWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TaskWave.Forms.MainWinAdminTaskWave.Forms.MainWinAdmin  5   	   .    (TaskWave.Forms.MainWinAdmin.MainWinAdmin   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:TaskWave.Forms.MainWinAdmin     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6A   -   5          �Name$  
mainWinMan��5   
    � Title$ MainWindowManager��5	   	   $	��670��6#   $
��1000��63    	  curSt � Cursor# [  6C   .  (System.Windows.Interactivity.Interaction   Triggers 5
      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *CommandOpenTasks+   CommandParameter 5   0   ��  �� ElementName$ MyTasks��  5       6$   �� *openListWithUsers+ 5   0   �� $ Users��5      .��5      � ���#3F4B60	 � ColumnDefinitions	 5   
   �� 5      $	��200��6   $	��200 �6.   $	��280��6:   �� 5      
 � RowDefinitions
 5   
   �� 5      $��75 �6   �� 5      .+�5   
    � -   5          �Name$ FraimMainInAcc��5        
FraimStyle#��[ 6(     � NavigationUIVisibility$ Hidden=�6L   # [  6l   �� 5   
     SPInMain#��[ 6   $��2��67   �� 5   
   #��[ 6   $��2��67   �� 5    
   $��TaskWave��6     NameTaskWave#��[ 6$     OxaniumRegular#��[ 6J   �� 5"   
   $��Center=�6   $
��Left=�6/   $��5 0 0 0q�6J   A� 5#      $��30��6   $��30��6!   $��0 0 0 -5q�6-   $��Center=�6?   $
��Left=�6Z   ��5$      �� 5%      -   5        imgBrush�� j� Stretch$ UniformToFill=�5%   Q    �� ImageSource 63   �� *Image+6Q   5'       �� 5)      -   5         ��Name$ NameBl��5)        nameAcc#��[ 6(   ��6I   �� *Name+ �� Mode$ TwoWay=� �� 5*      $��/Forms/img/settings.png��6     IconSet#��[ 65    5+        5,      $ 	MouseDown��6%   . 5-         60   �� *CommandOpenAccountSet+ 5.   0   �� $ avatar��5/      51      52      �� 54   
   $��	4 15 0 0 q�6   $��2��6)   $��0��66   .+�55      �� $��0 10 0 0q�6   $
��Wrap=�6*     cur# [ 6>   �� 56        IconNearMenu#��[ 6   $&�� /Forms/MainWinAdmin/users-64.png��6>   $
��Fill=�6h    �� 57      -   5        $ Users��57      $-��'Список пользователей��6+    	 MenuText#��[	 6G    58        59      $ 	MouseDown��6%   . 5:         60   �� *openListWithUsers+ 5;   0   �� $ Users��5<      5>      �� 5@      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=   �� 5A      $.��(/Forms/MainWinAdmin/list-of-parts-96.png��6   #��[ 6K    �� 5B      -   5        $ pr��5B      $#��Список проектов��6*   #��[	 6A    5C        5D      $ 	MouseDown��6%   . 5E         60   �� *openPrAdmin+ 5F   0   �� $ pr��5G      5I      �� 5K      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=   �� 5L      $"��/Forms/MainWinAdmin/task.png��6   #��[ 6?    �� 5M      -   5        $	 tsk��5M      $��Список задач��6*   #��[	 6>    5N        5O      $ 	MouseDown��6%   . 5P         60   �� *OpenTaskAdmin+ 5Q   0   �� $	 tsk��5R      5T      �� 5V      $
��Wrap=�6   $��0 7 0 0q�6,   # [ 6=   �� 5W      $-��'/Forms/MainWinAdmin/registration-90.png��6   #��[ 6I    �� 5X      -   5        $ request��5X      $0��*Запросы на регистрацию��6-   #��[	 6K    5Y        5Z      $ 	MouseDown��6%   . 5[         60   �� *OpenRequestRegister+ 5\   0   �� $ request��5]      5_      5`      �� 5c   
   $��Bottom=�6   $��4 0 0 20q�60   $��2��6B   $��0��6O   .+�5d      �� -	   5        $
 exit��5d      # [ 6&    5e        5f      $ 	MouseDown��6%   . 5g         60   �� *ExitCommand+ 5h   0   �� $ 
mainWinMan��5i      �� 5k      #��[ 6   $��/Forms/img/exit.png��6:    �� 5l      $'��!Выйти из аккаунта ��6   #��[	 62   5m      5n      �� 5p   
    
 splitterGrid#��[
 6   �� 5r   
     
FooterWrap#��[ 6   �� 5s      $5��//Forms/img/copyright-all-rights-reserved-96.png��6   $��15��6M    �� 5t        FooterTB#��[ 6   5u      5w      5x      