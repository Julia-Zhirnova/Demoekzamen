   M S B A M L   `   `   `  ����J  FAMONIC.Airlines, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AMONIC.AirlinesAMONIC.Airlines  5   	   $    AMONIC.Airlines.ScheduleWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AMONIC.Airlines     5   	     � Title$  ScheduleWindow��5   	   $	��450��6    $	��800��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��	Filter by��5      $��3��5      
���   �$��1q�5      .��5      �  5      �� 5      �� 5       5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      .+�5&      �� From6"   �� 5'      -   5        $��CmbFrom��5'   :   $
��Auto��6    �� SelectedIndex$ 0��6(   $��1��6I      DefaultComboBox#��[  6Y    �� DisplayMemberPath$ IATACode��6�   6�   �� 5(      $��2��6   To60   �� 5)      -   5        $��CmbTo��5)   :   $
��Auto��6   $ 0��6(   $��3��6G   #��[  6W   $ IATACode��6�   6�   �� 5*      $��4��6   	Sort by66   �� 5+      -   5        $��	CmbSortBy��5+   :   $
��Auto��6   $ 0��6(   $��5��6K   #��[  6[    6�   �� 6�   �� 5,      $��1��6   
Outbound64   (  "System.Windows.Controls.DatePicker  5-      -   5        $��
DpOutbound��5-      $��1��6/   $��1��6<   6O   �� 5.      $��1��6   $��2��6)   Flight Number6I   �� 5/      -   5        $��TbFlightNumber��5/      $��3��60   $��1��6@   6O   �� 50      -   5        $��BtnApply��50      $��4��6B   $��2��6R   $��1��6f   .��6s   Apply6z   51      52      &   System.Windows.Controls.DataGrid  53   
   -   5        $��SchedulesGrid��59      $��1��54      $��3��55         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 56         AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5:      	   RowStyle	 5;      �� 5<      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6    �� Triggers 5=      �� 5>       �� Binding 6&   �� *	Confirmed+ �� Value	 False6D   .a�5?      ��  �� Property � �� �� Value
 �  ��6I   5@      5B         Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Date+ �� StringFormat$ 
dd/MM/yyyy��6f     5F      $
 Time��6%    63   �� *Time+6N     5G      $
 From��6%    63   �� *Routes.Airports.IATACode+6b     5H      $ To��6%    61   �� *Routes.Airports1.IATACode+6a     5I      $ Flight number��6%    6<   �� *FlightNumber+6_     5J      $ Aircraft��6%    67   �� *Aircrafts.Name+6\     5K      $ Economy Price��6%    6<   �� *EconomyPrice+$ ${0:N0}��6v     5L      $ Business price��6%    6=   �� *BusinessPrice+$ ${0:N0}��6x     5M      $ First class price��6%    6@   �� *FirstClassPrice+$ ${0:N0}��6}   5O      �� 5P   
   -   5        $��	BtnCancel��5P      $��2��6<   .��6I   Cancel6Q   �� 5Q   
   -	   5        $��BtnEdit��5Q      $��2��69   $��1��6F   .��6V   Edit Flight6c   �� 5R   
   -
   5        $��	BtnImport��5R      $��2��6=   $��2��6J   $��Right=�6Z   .��6v   Import Changes6�   5S      5T      