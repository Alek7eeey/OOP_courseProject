   M S B A M L   `   `   `  ����C  ?TaskWave, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TaskWave.Pages.Admin.UsersListTaskWave.Pages.Admin.UsersList  5      2    ,TaskWave.Pages.Admin.UsersList.ListWithUsers   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TaskWave.Pages.Admin.UsersList     5        N� Title$  ListWithUsers��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Auto=�6   $
��Auto=�6:   $��5 5 5 20q�6_   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
peopleGrid��5   I      AutoGenerateColumns$ False��6      CanUserAddRows$
 True��63   ���#3F4B60   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6I      
IsReadOnly$
 True��6T   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *id+6T     5      $ Login��6C   $	 100 6R   	 6)   �� *login+6R     5      $ Password��6F   $	 110 6X   	 6)   �� *
password+6X     5      $
 Name��6B   $	 100 6P   	 6)   �� *name+6P     5      $
 Type��6B   $ 70 6P   	 6)   �� *type+6P     5      $ Telegram��6I   $	 123 6[   	 6)   �� *telegramURL+6[     5      $ Gmail��6F   $	 123 6U   	 6)   �� *
gmailURL+6U     5      $ Birthday��6F   $ 80 6X   	 6)   �� *
birthday+6X     5      $ Company��6E   $ 80 6V   	 6)   �� *	company+6V   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 	isRegistr��6K   $ 80 6^   	 6-   �� *	isRegistr+6^   5       5!      �� 5"   
   $��Center=�6   $��1��62   �� 5#      -   5        
 ��Name$
 deleteButton��5#   7      StartBtn#��[  6   $��Удалить��6M   ��6_   �� *Delete+ �� 5$      -   5        $
 
saveButton��5$   7   #��[  6   $��Сохранить��6K   ��6_   �� *Save+5%      5&      5'      