   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD  5          CRUD.Agents   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:CRUD     5        N� Title$  Agents��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DGridCRUDagents��5         AutoGenerateColumns .  $��0��6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)      CellTemplate 5      �� 5      .R�5      �� $	��100��6$   $��0��60   $��0��6A   $��UniformToFill=�6N   $��Center=�6f   $��5q�6�   ��5   "   �� 5   &    �� Path$ 	PhotoPath�6.    �� TargetNullValue 5   *   ��5   .   /img/picture.png��6L   5   '   5      5      5!      0  *System.Windows.Controls.DataGridTextColumn  5"         Header$ Имя риелтора��6%   $
 auto 6Y   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *	FirstName+6f     5$      $% Фамилия риелтора��6%   $
 auto 6^   
 6?   �� *
MiddleName+6^     5%      $&  Отчеcтво риелтора��6%   $
 auto 6]   
 6@   �� *
LastName+6]     5&      $$ Доля от комиссии��6%   $
 auto 6]   
 6?   �� *	DealShare+6]     5'      $ Фотография��6%   $
 auto 6W   
 69   �� *	PhotoPath+6W     5(      $
 auto 6)    5)      �� 5*      .R�5+      �� $��BtnEditAgent��6%   -   5        $
��auto��5+   9   $ ��Редактировать��6F   $
��10 5q�6^   $
��10 5q�6m   6{   5,      5.      4  .System.Windows.Controls.DataGridComboBoxColumn  5/      -   5        ComboBoxColumn��$ Position��5/   A      DisplayMemberPath$ 	FirstName��6~      SelectedItemBinding 6T   �� *	DealShare+6~   52      � 53   
   $��2��6   .+�54      �� -   5        $��BtnAddAgent��54      $'��!Добавить риелтора��6(   $	��200��6D   $
��10 0q�6P   $
��Left=�6x   �� 55      -   5        $��BtnSaveAgent��55      $)��#Сохранить риелтора��6)   $	��200��6F   $
��10 0q�6R   $
��Left=�6{   �� 56      -   5        $��BtnDelAgent��56      $%��Удалить риелтора��6(   $	��200��6C   $
��10 0q�6O   $��Right=�6w   57      58      59      