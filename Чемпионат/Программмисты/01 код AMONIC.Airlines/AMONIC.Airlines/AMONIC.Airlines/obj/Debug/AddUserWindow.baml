   M S B A M L   `   `   `  ����J  FAMONIC.Airlines, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AMONIC.AirlinesAMONIC.Airlines  5   	   #    AMONIC.Airlines.AddUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AMONIC.Airlines     5   	     � Title$  AddUserWindow��5   	      DefaultWindow#��[  5	   	    � WindowStartupLocation$ CenterScreen=�60   $	��400��5
   	   $	��600��6   $	��400��5   	   $	��600��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Email address��6     RightSideTextBlock#��[ 6)   6W   �� 5   
   $��
First name��6   $��1��6&   #��[ 63   6a   �� 5   
   $��	Last name��6   $��2��6%   #��[ 62   6`   �� 5   
   $��Office��6   $��3��6"   #��[ 6/   6]   �� 5    
   $��	Birthdate��6   $��4��6%   #��[ 62   6`   �� 5!   
   $��Password��6   $��5��6$   #��[ 61   6_   �� 5#   
   -   5        $��TbEmail��5#   "   $��1��6   ��61   �� *Email+6J   �� 5$   
   -   5        $��TbFirstName��5$   /   $��1��6   $��1��6"   ��6B   �� *	FirstName+6_   �� 5%   
   -   5        $��
TbLastName��5%   /   $��1��6   $��2��6"   ��6A   �� *
LastName+6]   �� 5&   
   -   5        $��
CmbOffices��5&   0   $��1��6   $��3��6#     DefaultComboBox#��[ 6B    �� DisplayMemberPath$ Title��5'       �� SelectedItem 6-   �� *	Offices+6P   (  "System.Windows.Controls.DatePicker  5(   
   -   5        $��DpBirthdate��5(   2   $��1��6   $��4��6%      SelectedDate 6E   �� *	Birthdate+6j   G� 5)   
   -   5        $��
PbPassword��5)   3   $��1��6   $��5��6&   6G   �� 5*   
   -   5        $��BtnSave��5*      $
��Save��6    $��6��6/   6T   �� 5+   
   -   5        $��	BtnCancel��5+      $��Cancel��6"   $��6��63   $��1��6@   6j   5,      5-      