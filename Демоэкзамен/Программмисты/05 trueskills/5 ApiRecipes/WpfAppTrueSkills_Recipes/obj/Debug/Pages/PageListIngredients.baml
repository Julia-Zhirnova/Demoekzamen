   M S B A M L   `   `   `  ����S  OWpfAppTrueSkills_Recipes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WpfAppTrueSkills_Recipes.PagesWpfAppTrueSkills_Recipes.Pages  5      8    2WpfAppTrueSkills_Recipes.Pages.PageListIngredients   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:WpfAppTrueSkills_Recipes.Pages     5        N� Title$+  %Список ингредиентов��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5        $��LblTotalQuantity��5      $��20(�6(   .��66   %#Всего наименований6J   �� 5   
   -   5        $��LblTotalSum��5      $��Right=�6#   $��14(�6?   $��Center=�6M   .��6h   ,*Запасов в холодильнике6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DGridIngredients��5      $��1��6+      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 68      
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$5 /Наименование ингредиента��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Name+6b   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Теги��6)      CellTemplate 5      �� 5      .R�5      �� ��6+   �� *Tags+��5    "   �� 5!   &   .R�5"   *   � 66   5#   '   ��5%   "   �� 5&   &   .R�5'   *   �� 	 �� CornerRadius$	 7��61   $	��2,1q�6c   ��6B   �� *	BackColor+._�5(   .   �� $��2q�6�   ��68   �� *	FontColor+��6Y   �� *Name+
 �� StringFormat$

 #{0}��6�   5)   +   5*   '   5,      5-      5/        50      $ Цена��6%      	CellStyle 51      �� 52       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�53      ��  �� Property � �� �� Value 6;   �� *
PriceColor+6Z   54       56      `� 57      $!
 {0:N0} руб. за {1} {2}��6'   .1�58      ��  �� Path$
 Cost�6&   64   �� 59      $ CostForCount�6&   6<   �� 5:      $ 	Unit.Name�6&   69   5;      5=        5>      $ В наличии��6%    5?      `� 5@      $
 {1} {0}��6'   .1�5A      �� $ 	Unit.Name�6&   69   �� 5B      $ AvailableCount�6&   6>   5C      5E        5F      $ Действия��6)    5G      �� 5H      .R�5I      �� ��6)   �� *
PriceColor+.+�5J   "   �� $��	10,10,0,2q�6,   �� 5K   &    �Name$ LinkEdit��6B   -   5        
����  �.�5K   i   Редактировать6x   5L   #   �� 5M   "   $��	10,2,0,10q�6,   �� 5N   &   $ 
LinkDelete��6A   -   5        
���  ��.�5N   l   Удалить6u   5O   #   5P      5Q      5S      5U      �� 5W   
   $��2��6    �� Orientation$ 
Horizontal=�6"    � 	Resources 5X         BaseOliveButton �� BasedOn��%�   '��       7   �� 5Y      " ��6   8   .�5Z      ��  � ��$ 28��6.   6;   �� 5[       � ��$ 3q�6/   6;   5\      5]      .+�5^      �� -   5        $��BtnFirstPage��5^      $��<<��6D   6Y   �� 5_      -   5        $��BtnPreviousPage��5_      $��<��6J   6[   �� 5`      -   5        $��LblPages��5`      $��Center=�6$   $��16(�6?   $��16,10q�6M   .��6\   4/56a   �� 5a      -	   5        $��BtnNextPage��5a      $��>��6B   6S   �� 5b      -
   5        $��BtnLastPage��5b      $��>>��6B   6W   5c      �� 5e   
   -   5         ��Name$ SPanelPages��5e      $ 
Horizontal=�6*   $��2��6C   $��Center=�6P   6o   �� 5g   
   -   5         ��Name$ 
BorderPlus��5g       �� Padding$ 0q�6Z   $	 15��6f   $��2��6x   $��30��6�   $��30��6�     
MainPurple#��[ 6�   $��2q�6�   
���   �$��Right=�6�   ._�5h      �� $��30(�6   $��
-2,-14,0,0q�6"   $
��Bold"�66   .��6H   +6K   5i      5j      5k      