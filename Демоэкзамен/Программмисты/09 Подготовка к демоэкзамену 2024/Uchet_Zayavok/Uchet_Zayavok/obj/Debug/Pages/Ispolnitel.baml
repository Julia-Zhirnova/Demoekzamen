   M S B A M L   `   `   `  ����H  DUchet_Zayavok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Uchet_Zayavok.PagesUchet_Zayavok.Pages  5      $    Uchet_Zayavok.Pages.Ispolnitel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Uchet_Zayavok.Pages     5        N� Title$  
Ispolnitel��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6-   �� 5      $
��Auto �6   6-   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   � -   5        $��Dannye��5      $��0��6   .+�5      �� -   5        $��LblTotalQuantity��5      $��20(�6,   .��6:   :8Количество выполненных заявок6Y   �� 5   
   -   5        $��LblTotalSum��5      $��Right=�6#   $��14(�6?   $��Center=�6M   .��6h   =;Среднее время выполнения заявки6�   5      � 5   
   -   5        $��
Sortirovka��5      $��1��6&   $��Center=�63   .+�5      �� $��10q�6   .+�5      �� $\��VВведите номер заявки или параметры для поиска: ��6   $��14(�6O   �� 5      -   5        $��	SearchBox��5      6'   �� 5      -   5        $��	BtnSearch��5      $��
Поиск��6&   66   5      �� 5      $��10q�6   .+�5      �� $:��4Выберите тип неисправности: ��6   $��14(�6<   �� 5      -   5        $��	ComboType��5      6(   �� 5      -   5        $��BtnReset��5      $��Применить��6&   6;   5       �� 5!      -	   5        $��x��5!      $��1��6!   $�� ��6.   5"      &   System.Windows.Controls.DataGrid  5#   
   -
   5        $��	DGZayavka��5#       $��2��6      AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Visible=�5%         
IsReadOnly .    Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заявки��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ID+6R     5(      $0 *Дата добавления заявки��6%   $
 auto 6a    6E   �� *	DataAdd+6a     5)      $L FОборудование, которое требует ремонта��6%   $
 auto 6z    6T   �� *Oborud.NameOborud+6z     5*      $' !Тип неисправности��6%   $
 auto 6d    6@   �� *Neisp.TypeNeisp+6d     5+      $' !Описание проблемы��6%   $
 auto 6d    6@   �� *OpisanieProblem+6d     5,      $: 4Клиент, который подал заявку��6%   $
 auto 6q    6K   �� *Client.NameClient+6q     5-      $ Статус заявки��6%   $
 auto 6e    6<   �� *Status.StatusZayavki+6e     5.      $ Исполнитель��6%   $
 auto 6h    6:   �� *Ispolnitel.NameIspolnitel+6h     5/      $ Комментарий��6%   $
 auto 6V    6:   �� *	Comment+6V     50      $ Материалы��6%   $
 auto 6U    68   �� *
Material+6U     51      $ Стоимость��6%   $
 auto 6Q    68   �� *Cost+6Q     52      $/ )Причина неисправности��6%   $
 auto 6d    6D   �� *ReasonNeisp+6d     53      $% Оказанная помощь��6%   $
 auto 6`    6?   �� *OpisanieHelp+6`     54      $ Запчасти��6%   $
 auto 6a    67   �� *Zapchast.NameZapchact+6a     55      $0 *Дата выполнения заявки��6%   $
 auto 6a    6E   �� *	DataEnd+6a   4  .System.Windows.Controls.DataGridTemplateColumn  58      $ Кнопка��6)   $
 auto 69   	   CellTemplate	 59      �� 5:      .R�5;      �� $��BtnEditAgent��6%   -   5        $
��auto��5;   9   $ ��Редактировать��6F   6^   5<      5>        5B      $&  Путь к фотографии��6%   $
 auto 6^    6@   �� *	PhotoPath+6^     5C      $
 auto 6)   $ Фотография��66   	 5D      �� 5E      .R�5F      �� $��50��6$   $��0��6/   $��0��6@   $��UniformToFill=�6M   $��Center=�6e   $��5q�6�   ��5G   "   �� 5H   &   
 �� Path$
 	PhotoPath�6.    �� TargetNullValue 5I   *   ��5J   .   /Images/service_logo.png��6T   5L   '   5N      5O      5Q      5T      �� 5U   
   -   5        $��3��5U      .��6*   Удалить63   5V      5W      